using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SQSTestProject.S3Publisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class S3Controller : ControllerBase
    {
        private const string bucketName = "test-bucket-vadym";
        private readonly IAmazonS3 _s3Client;


        public S3Controller(IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
        }

        [HttpPost]
        public async Task<IActionResult> Post(IFormFile form)
        {
            var request = new PutObjectRequest
            {
                BucketName = bucketName,
                Key = $"files/{Guid.NewGuid().ToString()}{Path.GetExtension(form.FileName)}",
                InputStream = form.OpenReadStream(),
                StorageClass = S3StorageClass.Standard
            };

            var response = await _s3Client.PutObjectAsync(request);
            return Ok(response.HttpStatusCode);
        }
    }
}
