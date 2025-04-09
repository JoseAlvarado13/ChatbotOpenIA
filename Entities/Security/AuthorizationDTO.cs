using EntitiesInterfaces.Security;
using Settings.Security;

namespace Entities.Security
{
    /// <summary>
    /// AM-001
    /// Author: José Andrés Alvarado Matamoros
    /// This class manages the authorization properties to loging in this API services.
    /// </summary>
    public class AuthorizationDTO : IAuthorizationDTO
    {
        public AuthorizationDTO() 
        {
            this.UserName = new AuthorizationCfg().Get(AuthorizationType.UserName);
            this.Password = new AuthorizationCfg().Get(AuthorizationType.Password);
        }
        public string UserName { get ; set ; }
        public string Password { get ; set ; }
    }
}
