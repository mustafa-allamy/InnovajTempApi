using InnovajTempApi.Dtos;
using InnovajTempApi.ResponseHelpers;
using InnovajTempApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace InnovajTempApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ClientResponse<Coordination>), 200)]
        [ProducesResponseType(typeof(ClientResponse<string>), 400)]
        [ProducesResponseType(typeof(void), 204)]
        public async Task<IActionResult> GetCoordination([Required] string cityName)
        {
            var serviceResponse = await _weatherService.GetCityCoordination(cityName);
            if (serviceResponse.Error != null)
            {
                return BadRequest(new ClientResponse<string>(true,
                    serviceResponse.Error.Message));
            }
            return Ok(new ClientResponse<Coordination>(serviceResponse.Value, serviceResponse.TotalCount));
        }
        [HttpGet]
        [ProducesResponseType(typeof(ClientResponse<WeatherDetails>), 200)]
        [ProducesResponseType(typeof(ClientResponse<string>), 400)]
        [ProducesResponseType(typeof(void), 204)]
        public async Task<IActionResult> GetCityWeatherDetails([Required] string cityName)
        {
            var serviceResponse = await _weatherService.GetCityWeatherDetails(cityName);
            if (serviceResponse.Error != null)
            {
                return BadRequest(new ClientResponse<string>(true,
                    serviceResponse.Error.Message));
            }
            return Ok(new ClientResponse<WeatherDetails>(serviceResponse.Value, serviceResponse.TotalCount));
        }
    }
}
