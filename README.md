# 🌦 Weather Forecast Application
**Overview**
- This Weather Forecast Application is a web-based platform that provides real-time and forecasted weather data for any location. Built with C# and ASP.NET Core MVC, the app integrates with weather APIs to deliver accurate weather information in a user-friendly interface.

**Features***
- 🔍 Search Weather by City or Location: Search for any city or location to view weather details.
- 🌡 Current Weather: Displays temperature, humidity, wind speed, and other weather parameters.
- 🌍 Geolocation: Automatically detects the user's current location to show weather data.
- 🔄 Unit Conversion: Easily switch between Celsius and Fahrenheit.

**How It Works**
- The app fetches weather data by integrating with a third-party weather API (API key required to enable functionality).
- Users can search for cities manually or allow the app to use geolocation services.
- The weather data is displayed in a clean, intuitive format with the option to toggle between units.

**Setup Instructions**
- Clone the Repository
- ```git clone https://github.com/Gutheras/WeatherApp  ```
  

**Configure the Weather API**
- Obtain an API key from a weather service (e.g., OpenWeatherMap or WeatherStack).
- Add your API key to the project configuration file in appsettings.json.
- Example in appsettings.json:
-  ```     
          "WeatherAPI": {  
              "BaseUrl": "https://api.weatherprovider.com/data",  
              "ApiKey": "your_api_key_here"  
          }  
      }  ```

**Tools and Technologies Used**
- C# with ASP.NET Core MVC
- Third-party Weather APIs (API key required)
- HTML5, CSS3, JavaScript
- Bootstrap for responsive design


