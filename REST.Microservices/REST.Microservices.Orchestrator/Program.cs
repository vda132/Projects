using Polly;
using Polly.Contrib.WaitAndRetry;
using REST.Microservices.Orchestrator.Clients;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUserClient, UserClient>();

builder.Services.AddHttpClient("UserClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("UserUrl"));
})
    .AddTransientHttpErrorPolicy(policy => 
        policy.WaitAndRetryAsync(Backoff.DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(1), 4)));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
