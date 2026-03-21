using ScalableRestApi.Application.Common;
using ScalableRestApi.Infrastructure.DependencyInjection;
using ScalableRestApi.Api.Middleware;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Dependency Injection
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration); // this method now requires IConfiguration configuration
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandlingMiddleware>();
//app.UseHttpsRedirection();

app.MapControllers();

app.Run();

public partial class Program { }
