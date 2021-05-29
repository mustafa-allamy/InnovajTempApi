using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using InnovajTempApi.Dtos;
using InnovajTempApi.ResponseHelpers;
using InnovajTempApi.Services.Interfaces;
using Newtonsoft.Json;

namespace InnovajTempApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherForecastController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ClientResponse<Coordination>), 200)]
        [ProducesResponseType(typeof(ClientResponse<string>), 400)]
        [ProducesResponseType(typeof(void), 204)]
        public async Task<IActionResult> GetCoordination([Required]string cityName)
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
