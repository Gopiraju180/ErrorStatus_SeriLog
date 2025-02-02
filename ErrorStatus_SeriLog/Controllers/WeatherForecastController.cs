using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ErrorStatus_SeriLog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            List<WeatherForecast> result1 = new List<WeatherForecast>();
            try
            {

                Log.Information("WeatherForecastController.GetApi method Execution Started");
                string result = "a" + "b" + "Hyderabad";
                Log.Debug("WeatherForecastController.Sample Result is:" + result);
                Log.Information("WeatherForecastController.GetApi method Execution Completed");

               // throw new Exception("Not a valid exception");
                return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
              .ToArray();
            }
            catch (Exception ex)
            {

                Log.Error("Custom Failure: {@RequestName}, {@Error}, {@DateTimeUtc}",
                    "WeatherForecastController Get Method", ex, DateTime.Today);
            }
            return result1;
        }
    }
}
