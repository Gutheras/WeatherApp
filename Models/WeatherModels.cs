namespace WeatherApp.Models;

public record WeatherViewModel
{
    public required CurrentWeather Current { get; init; }
    public required List<ForecastDay> Forecast { get; init; }
    public required string Units { get; init; }
}

public record CurrentWeather
{
    public required string City { get; init; }
    public double Temperature { get; init; }
    public required string Description { get; init; }
    public required string Icon { get; init; }
    public int Humidity { get; init; }
    public double WindSpeed { get; init; }
}

public record ForecastDay
{
    public DateTime Date { get; init; }
    public double TempMin { get; init; }
    public double TempMax { get; init; }
    public required string Description { get; init; }
    public required string Icon { get; init; }
}

public record CurrentWeatherResponse
{
    public required string Name { get; init; }
    public required MainInfo Main { get; init; }
    public required List<WeatherInfo> Weather { get; init; }
    public required WindInfo Wind { get; init; }
}

public record ForecastResponse
{
    public required List<ForecastItem> List { get; init; }
}

public record ForecastItem
{
    public long Dt { get; init; }
    public required MainInfo Main { get; init; }
    public required List<WeatherInfo> Weather { get; init; }
}

public record MainInfo
{
    public double Temp { get; init; }
    public int Humidity { get; init; }
    public double TempMin { get; init; }
    public double TempMax { get; init; }
}

public record WeatherInfo
{
    public required string Description { get; init; }
    public required string Icon { get; init; }
}

public record WindInfo
{
    public double Speed { get; init; }
}

public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}

