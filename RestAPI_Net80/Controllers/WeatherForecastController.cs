using Microsoft.AspNetCore.Mvc;

namespace RestAPI_Net80.Controllers
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
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        //[HttpPost(Name = "PostWeatherData")]

        //public async Task<ActionResult<WeatherForecast>> PostTodoItem(WeatherForecast todoItem)
        //{



        //    return Ok(todoItem);
        //}

        [HttpPost(Name = "SecondPostWeatherData")]
        public IActionResult Post([FromBody] WeatherForecast weatherData)
        {

            return Ok(weatherData);
        }

        [HttpDelete("{idBlabla}")]
        public IActionResult DeleteWeatherData(int id)
        {
            return BadRequest();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult PutWeatherData()
        {
            return Ok();
        }
    }
}
