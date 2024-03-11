
using BookDemo.Extensions;
using Entities.Exceptions;
using Microsoft.AspNetCore.Mvc;
using NLog;
using Presentation.ActionFilters;
using Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// Add services to the container.
	
builder.Services.AddControllers(config =>
{
	config.RespectBrowserAcceptHeader = true;
	config.ReturnHttpNotAcceptable = true;
})
	.AddCustomCvsFormatter()
	.AddXmlDataContractSerializerFormatters()
	.AddApplicationPart(typeof(Presentation.AssemblyRefrence).Assembly)
	.AddNewtonsoftJson();



builder.Services.Configure<ApiBehaviorOptions>(options =>
{
	options.SuppressModelStateInvalidFilter = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureLoggerService();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.ConfigureActionFilters();
builder.Services.ConfigureCors();
builder.Services.ConfigureDataShaper();
builder.Services.AddCustomMediaTypes();
builder.Services.ConfigureVersioning();

builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();


var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerService>();
app.ConfigureExceptionHandler(logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
