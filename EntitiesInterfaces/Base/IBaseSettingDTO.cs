namespace EntitiesInterfaces.Base
{
    /// <summary>
    /// AM-001
    /// Author:  José Andrés Alvarado Matamoros.
    /// This interface is a versatile container class to manage base setting.
    /// </summary>
    public interface IBaseSettingDTO
    {
        /// <summary>
        /// Holds the response value from the API. It can be any type of data.
        /// </summary>
        object Value { get; set; }
    }
}
