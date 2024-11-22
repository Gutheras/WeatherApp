using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Controllers;

public class HomeController : Controller
{
    private readonly IWeatherService _weatherService;
    private readonly ILogger<HomeController> _logger;

    public HomeController(IWeatherService weatherService, ILogger<HomeController> logger)
    {
        _weatherService = weatherService;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> GetWeather(string city, string units = "metric")
    {
        try
        {
            var weatherData = await _weatherService.GetWeatherDataAsync(city, units);
            return View("Index", weatherData);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to fetch weather data for {City}", city);
            ViewBag.Error = "Failed to fetch weather data. Please try again.";
            return View("Index");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

