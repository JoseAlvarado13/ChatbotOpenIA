namespace EntitiesInterfaces.Commons
{
    /// <summary>
    /// AM-001
    /// Author: José Andrés Alvarado Matamoros
    /// Interface manage the user properties.
    /// </summary>
    public interface IUserDTO
    {      
        string UserName { get; set; }
        string Password { get; set; }
    }
}
