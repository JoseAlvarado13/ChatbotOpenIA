using Microsoft.Extensions.Configuration;

namespace Settings.Commons
{
    /// <summary>
    /// AM-001
    /// Author: José Andrés Alvarado Matamoros
    /// 
    /// This class manages the base configuration to manage appsetting file that some special classes share with each other.
    /// </summary>
    public class BaseConfigurationAppSetting
    {
        #region GetConfiguration
        /// <summary>
        /// AM-001
        /// Author: José Andrés Alvarado Matamoros
        /// Method to initialize the configuration object for the class by loading settings from the appsettings.json file.
        /// </summary>
        /// <returns>IConfiguration object containing the application settings.</returns>
        protected IConfiguration GetConfiguration()
        {
            // Define the path to the appsettings.json
            string basePath = Directory.GetCurrentDirectory(); // Gets the output directory
            return new ConfigurationBuilder()
                .SetBasePath(basePath) // Set the base path
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // Load the file
                .Build();
        }
        #endregion
    }
}
