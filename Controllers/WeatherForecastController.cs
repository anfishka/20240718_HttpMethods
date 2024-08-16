using Microsoft.AspNetCore.Mvc;

namespace _20240718_HttpMethods.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private static List<int> numbers = new List<int>() { 1, 2, 3 };
      
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetNumbers")]
        public List <int> Get()
        {
            return numbers;
        }

        [HttpPost(Name = "PostNumbers")]
        public IActionResult Post(int value)
        {
            numbers.Add(value);
            return Ok();
        }

        [HttpPut(Name = "PutNumbers")]
        public IActionResult Put(int newValue, int oldVal = 0)
        {
            int index = numbers.FindIndex(x => x == oldVal);
            if(index < 0) { return BadRequest(); }
            numbers[index] = newValue; ;
            return Ok();
        }

        [HttpDelete(Name = "DeleteNumbers")]
        public IActionResult Delete(int value)
        {
            int index = numbers.FindIndex(x => x == value);
            if(index < 0) { return BadRequest(); }
            numbers.RemoveAt(index);
            return Ok();
        }
    }
}
