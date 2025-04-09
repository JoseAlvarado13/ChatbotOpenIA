using EntitiesInterfaces.Commons;

namespace Entities.Commons
{
    /// <summary>
    /// AM-001
    /// Author: José Andrés Alvarado Matamoros
    /// Class manage the user properties.
    /// </summary>
    public class UserDTO : IUserDTO
    {        
        public string UserName { get ; set ; }
        public string Password { get ; set ; }
    }
}
