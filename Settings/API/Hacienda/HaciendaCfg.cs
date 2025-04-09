using Microsoft.Extensions.Configuration;
using Settings.Commons;

namespace Settings.API.Hacienda
{
    #region Enums 
    /// <summary>        
    /// AM-001
    /// Author: José Andrés Alvarado Matamoros 
    /// Enum for HaciendaType. Here, you add the name of all the properties 
    /// that will be in the appsettings for this entity, using them as keys. 
    /// </summary>
    public enum HaciendaType
    {
        Host,
        ExchangeRate
        
    }
    #endregion

    /// <summary>
    /// AM-001
    /// Author: José Andrés Alvarado Matamoros
    /// 
    /// This class manages the hacienda api services configuration online values from the application's settings.
    /// based on dynamic keys and profiles.
    /// </summary>
    public class HaciendaCfg : BaseSettings
    {
        #region Global Data 
        /// <summary>        
        /// AM-001
        /// Author: José Andrés Alvarado Matamoros 
        /// Here you can find instances or global variables.
        /// </summary>    
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor 
        /// <summary>        
        /// AM-001
        /// Author: José Andrés Alvarado Matamoros 
        /// Constructor for initializing the class with the configuration object.
        /// </summary>
        /// <param name="configuration">Represents a set of key/value application configuration properties.</param> 
        public HaciendaCfg()
        {
            _configuration = this.GetConfiguration();
        }
        #endregion

        #region Get 
        /// <summary>        
        /// AM-001
        /// Author: José Andrés Alvarado Matamoros 
        /// Method to get the configuration value  in appsetting file using HaciendaType enum as a key.  
        /// </summary>
        /// <param name="haciendaType">Represents a set of keys located in appsetting.</param> 
        public string Get(HaciendaType haciendaType)
        {
            // Get the active profile from the configuration
            string profile = _configuration["Profile"];

            // Search for the configuration in the active profile and all defined profiles
            string value = GetFromProfile(profile, haciendaType);

            // If the value is not found in the active profile, search in all profiles (without explicit ifs)
            if (string.IsNullOrEmpty(value))
            {
                value = _configuration.GetChildren()
                    .Where(section => section.Key != "Profile") // Exclude "Profile" from the list
                    .Select(section => GetFromProfile(section.Key, haciendaType))
                    .FirstOrDefault(val => !string.IsNullOrEmpty(val)); // Get the first non-null value
            }

            // If no value is found, throw an exception
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception($"The property {haciendaType} was not found in any profile.");
            }

            return value;
        }
        #endregion

        #region GetFromProfile 
        /// <summary>        
        /// AM-001
        /// Author: José Andrés Alvarado Matamoros 
        /// Method to get the configuration value in the appsetting file using HaciendaType enum as a key.
        /// </summary>
        /// <param name="haciendaType">Represents a set of keys located in appsetting.</param>  
        /// <param name="profile">Here came key of profile of appsettings.</param>  
        private string GetFromProfile(string profile, HaciendaType haciendaType)
        {
            // Get the section corresponding to the profile
            var section = _configuration.GetSection(profile);

            // Get the name of the current class dynamically using reflection
            string className = this.GetType().Name;

            // Build the dynamic property name based on the class name and authorization type
            string propertyName = $"{className}{haciendaType}";

            // Search for the value corresponding to the dynamic property name
            return section[propertyName];
        }
        #endregion
    }
}
