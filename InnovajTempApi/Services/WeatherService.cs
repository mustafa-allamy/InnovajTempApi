using InnovajTempApi.Dtos;
using InnovajTempApi.ResponseHelpers;
using InnovajTempApi.Services.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace InnovajTempApi.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IHttpClientHelper _clientHelper;
        private readonly string _baseUrl;
        private readonly string _appId;
        public WeatherService(IHttpClientHelper clientHelper, IOptions<WeatherCridintals> weather)
        {
            _clientHelper = clientHelper;
            _baseUrl = weather.Value.Url;
            _appId = weather.Value.AppId;

        }

        public async Task<ServiceResponse<Coordination>> GetCityCoordination(string cityName)
        {
            var response = await _clientHelper.Get($"data/2.5/weather?q={cityName}&appid={_appId}", _baseUrl);
            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<Coordination>(null)
                {
                    Error = new ResponseError("Request failed")
                };
            }

            var res = JsonConvert.DeserializeObject<WatherApiResult>(await response.Content.ReadAsStringAsync());
            if (res == null)
            {
                return new ServiceResponse<Coordination>(null)
                {
                    Error = new ResponseError("Could not translate response")
                };
            }

            return new ServiceResponse<Coordination>(res.coord);
        }
        public async Task<ServiceResponse<WeatherDetails>> GetCityWeatherDetails(string cityName)
        {
            var response = await _clientHelper.Get($"data/2.5/weather?q={cityName}&appid={_appId}", _baseUrl);
            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<WeatherDetails>(null)
                {
                    Error = new ResponseError("Request failed")
                };
            }

            var res = JsonConvert.DeserializeObject<WatherApiResult>(await response.Content.ReadAsStringAsync());
            if (res == null)
            {
                return new ServiceResponse<WeatherDetails>(null)
                {
                    Error = new ResponseError("Could not translate response")
                };
            }

            var details = new WeatherDetails()
            {
                CityName = res.name,
                FeelsLike = res.main.feels_like - 273.15,
                Humidity = res.main.humidity,
                Temperature = res.main.temp - 273.15,
                WindSpeed = res.wind.speed,
            };
            return new ServiceResponse<WeatherDetails>(details);
        }
    }
}