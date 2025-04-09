using BusinessLogicInterfaces.Security;
using Entities.Security;
using EntitiesInterfaces.Commons;
using EntitiesInterfaces.Security;

namespace BusinessLogic.Security
{
    /// <summary>
    /// AM-001
    /// Author: José Andrés Alvarado Matamoros
    /// Class to manage authorization methods to loggin in this api services.
    /// </summary>
    public class AuthorizationBL : IAuthorizationBL
    {
        #region Global Data 
        /// <summary>        
        /// AM-001
        /// Author: José Andrés Alvarado Matamoros 
        /// Here you can find instances or global variables.
        /// </summary>    
        private IAuthorizationDTO authorizationDTO;
        #endregion

        #region Constructor 
        /// <summary>        
        /// AM-001
        /// Author: José Andrés Alvarado Matamoros 
        /// Constructor for initializing the class with the configuration object.
        /// </summary>
        /// <param></param>
        public AuthorizationBL() 
        {
            authorizationDTO = new AuthorizationDTO(); 
        }
        #endregion 

        #region  Get
        /// <summary>
        /// AM-001
        /// Author: José Andrés Alvarado Matamoros
        /// Method to validate credential sent of the other application.
        /// </summary>
        /// <param name="User">Here came user sent to another external application and also here came password sent to another external application.</param> 
        /// <@Return>This method return true if the credential are diferent ,other hand the method'll return false if both credential are de same .</param> 
        public bool Get(IUserDTO User)
        {
            if (User.UserName != authorizationDTO.UserName || User.Password != authorizationDTO.Password) 
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
