using Entities.DataTransferObjects.Book;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Presentation.ActionFilters;
using Repositories.Contracts;
using Repositories.EFCore;
using Services;
using Services.Contracts;
using static System.Net.Mime.MediaTypeNames;

namespace BookDemo.Extensions
{
	public static class ServicesExtensions
	{
		public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) => services.AddDbContext<RepositoryContext>(
			opt =>
			opt.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

		public static void ConfigureRepositoryManager(this IServiceCollection services) => services.AddScoped<IRepositoryManager, RepositoryManager>();

		public static void ConfigureServiceManager(this IServiceCollection services) =>
			services.AddScoped<IServiceManager, ServiceManager>();

		public static void ConfigureLoggerService(this IServiceCollection services)
			=> services.AddSingleton<ILoggerService, LoggerManager>();

		public static void ConfigureActionFilters(this IServiceCollection services)
		{
			services.AddScoped<ValidationFilterAttribute>();
			services.AddSingleton<LogFilterAttribute>();
		}

		public static void ConfigureCors(this IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy", builder =>
				builder.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader()
				.WithExposedHeaders("X-Pagination")
				);
			});
		}

		public static void ConfigureDataShaper(this IServiceCollection services)
		{
			services.AddScoped<IDataShaper<BookDto>, DataShaper<BookDto>>();
		}

		public static void AddCustomMediaTypes(this IServiceCollection services)
		{
			services.Configure<MvcOptions>(config =>
			{
				var systemTextJsonOutputFormatter = config
				.OutputFormatters
				.OfType<SystemTextJsonInputFormatter>()?.FirstOrDefault();
				if (systemTextJsonOutputFormatter is not null)
				{
					systemTextJsonOutputFormatter.SupportedMediaTypes
					.Add("application/vnd.btkadakemi.hateoas+json");

					systemTextJsonOutputFormatter.SupportedMediaTypes
					.Add("application/vnd.btkakademi.apiroot+json");
				}

				var xmlOutputFormatter = config
				.OutputFormatters
				.OfType<XmlDataContractSerializerInputFormatter>()?.FirstOrDefault();

				if (xmlOutputFormatter is not null)
				{
					xmlOutputFormatter.SupportedMediaTypes
					.Add("application/vnd.btkadakemi.hateoas+xml");
					xmlOutputFormatter.SupportedMediaTypes
				.Add("application/vnd.btkakademi.apiroot+xml");
				}


			});
		}

		public static void ConfigureVersioning(this IServiceCollection services)
		{
			services.AddApiVersioning(opt =>
			{
				opt.ReportApiVersions = true;
				opt.AssumeDefaultVersionWhenUnspecified = true;
				opt.DefaultApiVersion = new ApiVersion(1, 0);
			});
		}

		public static void ConfigureIdentity(this IServiceCollection services)
		{
			var builder = services.AddIdentity<User, IdentityRole>(
				opt => {
					opt.Password.RequireDigit = true;
					opt.Password.RequireLowercase = true;
					opt.Password.RequireUppercase = true;
					opt.Password.RequireNonAlphanumeric = false;
					opt.Password.RequiredLength = 6;
					opt.User.RequireUniqueEmail = true;
					})
				.AddEntityFrameworkStores<RepositoryContext>()
				.AddDefaultTokenProviders();

        }
	}
}
