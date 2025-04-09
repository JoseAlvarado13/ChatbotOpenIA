using Microsoft.Extensions.Configuration;

namespace Settings.Commons
{    
    #region Enums 
    /// <summary>        
    /// AM-001
    /// Author: José Andrés Alvarado Matamoros 
    /// Enum for baseAPISettingsType. Here, you add the name of all the properties 
    /// that will be in the appsettings for this entity, using them as keys. 
    /// </summary>
    public enum BaseAPISettingsType
    {
       InternalErrorMessage,
       HostName
    }
    #endregion

    /// <summary>
    /// AM-001
    /// Author: José Andrés Alvarado Matamoros
    /// 
    /// This class manages the retrieval of configuration values from the application's settings 
    /// based on dynamic keys and profiles.
    /// </summary>
    public class BaseAPISettingsCfg : BaseSettings
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
        public BaseAPISettingsCfg()
        {
            _configuration = this.GetConfiguration();
        }
        #endregion

        #region Get 
        /// <summary>        
        /// AM-001
        /// Author: José Andrés Alvarado Matamoros 
        /// Method to get the configuration value  in appsetting file using baseAPISettingsType enum as a key.  
        /// </summary>
        /// <param name="baseAPISettingsType">Represents a set of keys located in appsetting.</param> 
        public string Get(BaseAPISettingsType baseAPISettingsType)
        {
            // Get the active profile from the configuration
            string profile = _configuration["Profile"];

            // Search for the configuration in the active profile and all defined profiles
            string value = GetFromProfile(profile, baseAPISettingsType);

            // If the value is not found in the active profile, search in all profiles (without explicit ifs)
            if (string.IsNullOrEmpty(value))
            {
                value = _configuration.GetChildren()
                    .Where(section => section.Key != "Profile") // Exclude "Profile" from the list
                    .Select(section => GetFromProfile(section.Key, baseAPISettingsType))
                    .FirstOrDefault(val => !string.IsNullOrEmpty(val)); // Get the first non-null value
            }

            // If no value is found, throw an exception
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception($"The property {baseAPISettingsType} was not found in any profile.");
            }

            return value;
        }
        #endregion

        #region GetFromProfile 
        /// <summary>        
        /// AM-001
        /// Author: José Andrés Alvarado Matamoros 
        /// Method to get the configuration value in the appsetting file using baseAPISettingsType enum as a key.
        /// </summary>
        /// <param name="baseAPISettingsType">Represents a set of keys located in appsetting.</param>  
        /// <param name="profile">Here came key of profile of appsettings.</param>  
        private string GetFromProfile(string profile, BaseAPISettingsType baseAPISettingsType)
        {
            // Get the section corresponding to the profile
            var section = _configuration.GetSection(profile);

            // Get the name of the current class dynamically using reflection
            string className = this.GetType().Name;

            // Build the dynamic property name based on the class name and authorization type
            string propertyName = $"{className}{baseAPISettingsType}";

            // Search for the value corresponding to the dynamic property name
            return section[propertyName];
        }
        #endregion
    }
}
