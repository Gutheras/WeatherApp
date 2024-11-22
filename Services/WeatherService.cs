using System.Net.Http.Json;
using WeatherApp.Models;

namespace WeatherApp.Services;

public interface IWeatherService
{
    Task<WeatherViewModel> GetWeatherDataAsync(string city, string units);
}

public class WeatherService : IWeatherService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly ILogger<WeatherService> _logger;

    public WeatherService(IHttpClientFactory httpClientFactory, IConfiguration configuration, ILogger<WeatherService> logger)
    {
        _httpClient = httpClientFactory.CreateClient("OpenWeatherMap");
        _apiKey = configuration["OpenWeatherMap:ApiKey"] ?? throw new InvalidOperationException("OpenWeatherMap API key is not configured.");
        _logger = logger;
    }

    public async Task<WeatherViewModel> GetWeatherDataAsync(string city, string units)
    {
        var currentWeatherUrl = $"weather?q={city}&units={units}&appid={_apiKey}";
        var forecastUrl = $"forecast?q={city}&units={units}&appid={_apiKey}";

        try
        {
            var currentWeatherResponse = await _httpClient.GetFromJsonAsync<CurrentWeatherResponse>(currentWeatherUrl);
            var forecastResponse = await _httpClient.GetFromJsonAsync<ForecastResponse>(forecastUrl);

            if (currentWeatherResponse is null || forecastResponse is null)
            {
                throw new HttpRequestException("Failed to deserialize weather data.");
            }

            return new WeatherViewModel
            {
                Current = new CurrentWeather
                {
                    City = currentWeatherResponse.Name,
                    Temperature = currentWeatherResponse.Main.Temp,
                    Description = currentWeatherResponse.Weather[0].Description,
                    Icon = currentWeatherResponse.Weather[0].Icon,
                    Humidity = currentWeatherResponse.Main.Humidity,
                    WindSpeed = currentWeatherResponse.Wind.Speed
                },
                Forecast = forecastResponse.List
                    .Where((item, index) => index % 8 == 0)
                    .Take(5)
                    .Select(item => new ForecastDay
                    {
                        Date = DateTimeOffset.FromUnixTimeSeconds(item.Dt).DateTime,
                        TempMin = item.Main.TempMin,
                        TempMax = item.Main.TempMax,
                        Description = item.Weather[0].Description,
                        Icon = item.Weather[0].Icon
                    })
                    .ToList(),
                Units = units
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching weather data for {City}", city);
            throw;
        }
    }
}