using SWAP42.Core.Contracts.Helpers;
using SWAP42.Core.Contracts.Repositories;
using SWAP42.Core.Contracts.Services;
using SWAP42.Repositories;
using SWAP42.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Single instance dependencies
builder.Services.AddSingleton<IBikeSearchUrlHelper, BikeIndexSearchUrlHelper>();
builder.Services.AddSingleton<IConfigReader, ConfigReader>();
// Instance per request dependencies
builder.Services.AddScoped<IBikeService, BikeService>();
builder.Services.AddScoped<IBikeRepository, BikeRepository>();
builder.Services.AddScoped<IHttpRequestExecutor, HttpRequestExecutor>();

builder.Services.AddHttpClient<IHttpRequestExecutor, HttpRequestExecutor>();

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
