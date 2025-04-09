using EntitiesInterfaces.Commons;
using EntitiesInterfaces.Security;

namespace BusinessLogicInterfaces.Security
{
    /// <summary>
    /// AM-001
    /// Author: José Andrés Alvarado Matamoros
    /// Interface to manage authorization methods to loggin in this api services.
    /// </summary>
    public interface IAuthorizationBL
    {
        #region  Get
        /// <summary>
        /// AM-001
        /// Author: José Andrés Alvarado Matamoros
        /// Method to validate credential sent of the other application.
        /// </summary>
        /// <param name="User">Here came user sent to another external application and also here came password sent to another external application.</param> 
        /// <@Return>This method return true if the credential are de same,  other hand the method'll return false .</param> 
        bool Get(IUserDTO User);
        #endregion
    }
}
