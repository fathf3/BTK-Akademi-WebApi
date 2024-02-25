using BookDemo.Utilities.Formatters;
using Microsoft.Extensions.DependencyInjection;


namespace Entities.Exceptions
{
	public static class IMvcBuilderExtensions
	{
		public static IMvcBuilder AddCustomCvsFormatter(this IMvcBuilder builder)
		=>	builder.AddMvcOptions(config => 
			config.OutputFormatters
			.Add(new CsvOutputFormatter()));
		
	}
}
