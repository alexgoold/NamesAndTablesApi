
using NamesAndTablesApi.Middlewares;

namespace NamesAndTablesApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			var configurationBuilder = builder.Configuration.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
				.AddJsonFile("Properties/appsettings.json")
				.AddJsonFile($"Properties/appsettings.{builder.Environment.EnvironmentName}.json")
				.AddEnvironmentVariables()
				.Build();

			// Add services to the container.

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

			app.UseMiddleware(typeof(ExceptionMiddleware));
			app.Use(async (context, next) => await ControllerExceptionMiddleware.HandleControllerExceptions(context, next));
			
			app.MapControllers();

			app.Run();
		}
	}
}