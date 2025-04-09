using EntitiesInterfaces.Commons.Enums;

namespace EntitiesInterfaces.Base
{
    /// <summary>
    /// AM-001
    /// Author: José Andrés Alvarado Matamoros. 
    /// 
    /// Defines a standard structure for API response objects.
    /// </summary>
    public interface IResponseDTO: IBaseSettingDTO
    {
        /// <summary>
        /// Indicates the result of the operation (Success, Warning, Error).
        /// </summary>
        ActionResult Result { get; set; }
        /// <summary>
        /// A list of error messages associated with the operation.
        /// </summary>
        List<string> ErrorMessage { get; set; }
    }
}
