using InnovajTempApi.Dtos;
using InnovajTempApi.ResponseHelpers;
using System.Threading.Tasks;

namespace InnovajTempApi.Services.Interfaces
{
    public interface IWeatherService
    {
        Task<ServiceResponse<Coordination>> GetCityCoordination(string cityName);
        Task<ServiceResponse<WeatherDetails>> GetCityWeatherDetails(string cityName);
    }
}