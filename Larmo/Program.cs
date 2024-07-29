using Larmo;
using Larmo.Core;
using Larmo.Domain;
using Larmo.Extension;
using Larmo.Infrastructure;
using Larmo.Infrastructure.Context;
using Larmo.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddCore();
builder.Services.AddCorsSetup();
builder.Services.AddDomain();
builder.Services.AddSingleton<ExceptionMiddleware>();

var app = builder.Build();

app.UseExceptionMiddleware();

app.UseAutomaticMigration<BaseContext>();
app.UseCorsSetup();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseExceptionMiddleware();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
