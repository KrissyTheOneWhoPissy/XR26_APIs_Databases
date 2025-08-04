using System;
using Newtonsoft.Json;

namespace WeatherApp.Data
{
    /// <summary>
    /// Main weather data structure matching OpenWeatherMap API response
    /// TODO: Students will complete the JsonProperty attributes
    /// </summary>
    [Serializable]
    public class WeatherData
    {
        // TODO: Add JsonProperty attribute for "main"
        [JsonProperty("main")]
        public MainWeatherInfo Main { get; set; }

        // TODO: Add JsonProperty attribute for "weather"
        [JsonProperty("weather")]
        public WeatherDescription[] Weather { get; set; }

        // TODO: Add JsonProperty attribute for "name"
        [JsonProperty("name")]
        public string CityName { get; set; }

        // TODO: Add JsonProperty attribute for "cod"
        [JsonProperty("cod")]
        public int StatusCode { get; set; }

        // Helper properties for easier data access
        public float TemperatureInCelsius => Main?.Temperature - 273.15f ?? 0f;
        public string PrimaryDescription => Weather?.Length > 0 ? Weather[0].Description : "Unknown";

        // Validation method
        public bool IsValid => StatusCode == 200 && Main != null && !string.IsNullOrEmpty(CityName);
    }

    /// <summary>
    /// Main weather information (temperature, humidity, etc.)
    /// TODO: Students will complete the JsonProperty attributes
    /// </summary>
    [Serializable]
    public class MainWeatherInfo
    {
        // TODO: Add JsonProperty attribute for "temp"
        [JsonProperty("temp")]
        public float Temperature { get; set; }

        // TODO: Add JsonProperty attribute for "feels_like"
        [JsonProperty("feels_like")]
        public float FeelsLike { get; set; }

        // TODO: Add JsonProperty attribute for "humidity"
        [JsonProperty("humidity")]
        public int Humidity { get; set; }

        // TODO: Add JsonProperty attribute for "pressure"
        [JsonProperty("pressure")]
        public int Pressure { get; set; }
    }

    /// <summary>
    /// Weather description information
    /// TODO: Students will complete the JsonProperty attributes
    /// </summary>
    [Serializable]
    public class WeatherDescription
    {
        // TODO: Add JsonProperty attribute for "main"
        [JsonProperty("main")]
        public string Main { get; set; }

        // TODO: Add JsonProperty attribute for "description"
        [JsonProperty("description")]
        public string Description { get; set; }

        // TODO: Add JsonProperty attribute for "icon"
        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
}
