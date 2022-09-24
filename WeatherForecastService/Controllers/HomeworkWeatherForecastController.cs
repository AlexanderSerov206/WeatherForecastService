using Microsoft.AspNetCore.Mvc;
using WeatherForecastService.Models;

namespace WeatherForecastService.Controllers
{

    /*

 Написать свой контроллер и методы в нем, которые бы предоставляли следующую функциональность:
    • Возможность сохранить температуру в указанное время
    • Возможность отредактировать показатель температуры в указанное время
    • Возможность удалить показатель температуры в указанный промежуток времени
    • Возможность прочитать список показателей температуры за указанный промежуток времени

 */

    [Route("api/weather")]
    [ApiController]
    public class HomeworkWeatherForecastController : ControllerBase
    {
        private readonly WeatherForecastHolder _holder;

        public HomeworkWeatherForecastController(WeatherForecastHolder holder)
        {
            _holder = holder;
        }


        [HttpPost("add")]
        public IActionResult Add([FromQuery]  DateTime date, [FromQuery]  int temperatureC)
        {
            _holder.Add(date, temperatureC);
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult Update([FromQuery] DateTime date, [FromQuery] int temperatureC)
        {
            _holder.Update(date, temperatureC);
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] DateTime date)
        {            
            return Ok(_holder.Delete(date));
        }

        [HttpGet("get")]
        public IActionResult Get([FromQuery] DateTime dateFrom, [FromQuery] DateTime dateTo)
        {
            return Ok(_holder.Get(dateFrom, dateTo));
        }

    }
}
