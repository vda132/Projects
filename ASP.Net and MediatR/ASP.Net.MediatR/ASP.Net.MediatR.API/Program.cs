using ASP.Net.MediatR.API.Extensions;
using ASP.Net.MediatR.CRUD.Result;
using ASP.Net.MediatR.DAL;
using ASP.Net.MediatR.DAL.Repositories;
using ASP.Net.MediatR.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"),
        b => b.MigrationsAssembly("ASP.Net.MediatR.DAL")));

builder.Services.AddRepositories();
builder.Services.AddServices();

var allowResources = "AllowResources";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowResources,
        builder => builder
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
});

builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(UserRepository).Assembly);
builder.Services.AddMediatR(typeof(Program).Assembly, typeof(UserRepository).Assembly);

builder.Services.AddMemoryCache();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvcCore().ConfigureApiBehaviorOptions(opts => 
{
    opts.InvalidModelStateResponseFactory =
                  (context => new BadRequestObjectResult(new ExecResult 
                  {
                     HasErrors = true,
                     IsSystemError = false,
                     Errors = context.ModelState.Values.SelectMany(el => el.Errors.Select(e => e.ErrorMessage)).ToList()
                  }));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(allowResources);

app.UseHttpsRedirection();

app.UseErrorMiddleware();

app.UseAuthorization();

app.MapControllers();

app.InitDB().Run();
