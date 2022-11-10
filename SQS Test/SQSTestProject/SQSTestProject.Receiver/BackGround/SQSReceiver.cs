using Amazon.S3;
using Amazon.S3.Util;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace SQSTestProject.Receiver.BackGround;

public class SQSReceiver : BackgroundService
{
    private readonly IAmazonS3 _s3Client;
    private readonly IAmazonSQS _sqs;

    private const string queueName = "s3-queue";
    private const string folderName = "files";
    private readonly string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads");

    public SQSReceiver(IAmazonSQS sqs, IAmazonS3 s3Client)
    {
        _sqs = sqs;
        _s3Client = s3Client;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var queueUrl = await _sqs.GetQueueUrlAsync(queueName, stoppingToken);
        var receiveRequest = new ReceiveMessageRequest
        {
            QueueUrl = queueUrl.QueueUrl,
        };


        while (!stoppingToken.IsCancellationRequested)
        {
            var messageResponse = await _sqs.ReceiveMessageAsync(receiveRequest, stoppingToken);
            foreach (var message in messageResponse.Messages)
            {
                var result = await ProcessMessageAsync(message, stoppingToken);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (var fileStream = File.Create(result.filePath))
                {
                    await result.response.CopyToAsync(fileStream, stoppingToken);
                    await _sqs.DeleteMessageAsync(queueUrl.QueueUrl, message.ReceiptHandle, stoppingToken);
                }
            }
        }
    }

    private async Task<(string filePath, Stream response)> ProcessMessageAsync(Message message, CancellationToken cancellationToken)
    {
        var @event = S3EventNotification.ParseJson(message.Body);
        var s3Info = @event.Records[0].S3;
        var file = await _s3Client.GetObjectAsync(s3Info.Bucket.Name, s3Info.Object.Key, cancellationToken);
        var response = file.ResponseStream;
        var fileName = s3Info.Object.Key.Split("/")[1];
        var filePath = Path.Combine(path, fileName);

        return (filePath, response);
    }
}
