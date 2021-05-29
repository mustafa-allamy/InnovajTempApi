using System.Threading.Tasks;
using InnovajTempApi.Dtos;
using InnovajTempApi.ResponseHelpers;

namespace InnovajTempApi.Services.Interfaces
{
    public interface IWeatherService
    {
        Task<ServiceResponse<Coordination>> GetCityCoordination(string cityName);
        Task<ServiceResponse<WeatherDetails>> GetCityWeatherDetails(string cityName);
    }
}