using UnityEngine;
using System.IO;

namespace WeatherApp.Config
{
    /// <summary>
    /// Configuration manager for API keys and settings
    /// Loads configuration from a local file that should NOT be committed to version control
    /// </summary>
    public static class ApiConfig
    {
        private static string _apiKey;
        private static bool _isLoaded = false;
        
        /// <summary>
        /// Get the OpenWeatherMap API key from configuration
        /// </summary>
        public static string OpenWeatherMapApiKey
        {
            get
            {
                if (!_isLoaded)
                {
                    LoadConfiguration();
                }
                return _apiKey;
            }
        }
        
        /// <summary>
        /// Load configuration from the config.json file
        /// </summary>
        private static void LoadConfiguration()
        {
            string configPath = Path.Combine(Application.streamingAssetsPath, "config.json");
            Debug.Log("configPath: " + configPath);
            
            if (File.Exists(configPath))
            {
                try
                {
                    string jsonContent = File.ReadAllText(configPath);
                    var config = JsonUtility.FromJson<ConfigData>(jsonContent);
                    _apiKey = config.openWeatherMapApiKey;
                    _isLoaded = true;
                    
                    Debug.Log("API configuration loaded successfully");
                }
                catch (System.Exception ex)
                {
                    Debug.LogError($"Failed to load API configuration: {ex.Message}");
                    _apiKey = "your_api_key_here";
                    _isLoaded = true;
                }
            }
            else
            {
                Debug.LogWarning($"Config file not found at {configPath}. Using placeholder API key.");
                Debug.LogWarning("Please create a config.json file in StreamingAssets folder with your API key.");
                _apiKey = "your_api_key_here";
                _isLoaded = true;
            }
        }
        
        /// <summary>
        /// Check if the API key is properly configured
        /// </summary>
        public static bool IsApiKeyConfigured()
        {
            return !string.IsNullOrEmpty(OpenWeatherMapApiKey) && 
                   OpenWeatherMapApiKey != "your_api_key_here";
        }
    }
    
    /// <summary>
    /// Data structure for the configuration JSON file
    /// </summary>
    [System.Serializable]
    public class ConfigData
    {
        public string openWeatherMapApiKey;
    }
}