using Application;
using Endpoints;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
Console.WriteLine("GOOGLE_APPLICATION_CREDENTIALS: " + Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS"));


app.MapAllEndpoints();

app.Run();
