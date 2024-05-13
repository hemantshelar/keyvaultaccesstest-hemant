using keyvaultaccesstest_hemant.Services;
using Microsoft.AspNetCore.Mvc;

namespace keyvaultaccesstest_hemant.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class WeatherForecastController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<WeatherForecastController> _logger;
		private readonly IKVManager _kVManager;

		public WeatherForecastController(ILogger<WeatherForecastController> logger, IKVManager kVManager)
		{
			_logger = logger;
			_kVManager = kVManager;
		}

		[HttpGet(Name = "GetWeatherForecast")]
		public string Get()
		{
			var str = _kVManager.GetSecret("test");
			return str;
		}

		[HttpGet(Name = "GetSecreteFromEnvVariable")]
		public string GetSecreteFromEnvVariable()
		{
			var str = Environment.GetEnvironmentVariable("TESTENV");
			str = str ?? "No value found";
			return str;
		}
	}
}
