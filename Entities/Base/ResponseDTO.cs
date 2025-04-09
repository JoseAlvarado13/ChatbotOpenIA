using EntitiesInterfaces.Base;
using EntitiesInterfaces.Commons.Enums;

namespace Entities.Base
{
    /// <summary>
    /// AM-001
    /// Author: José Andrés Alvarado Matamoros. 
    /// 
    /// Defines a standard structure for API response objects.
    /// </summary>
    public class ResponseDTO : IResponseDTO
    {
        #region Constructor 
        /// <summary>
        /// AM-001
        /// Author:  José Andrés Alvarado Matamoros.
        /// Constructor to initialize the container with any type of data.
        /// </summary>         
        public ResponseDTO() 
        {
            this.Result = ActionResult.Success; 
        }
        #endregion

        /// <summary>
        /// Indicates the result of the operation (Success, Warning, Error).
        /// </summary>
        public ActionResult Result { get ; set ; }
        /// <summary>
        /// A list of error messages associated with the operation.
        /// </summary>
        public List<string> ErrorMessage { get ; set ; }
        /// <summary>
        /// Holds the response value from the API. It can be any type of data.
        /// </summary>
        public object Value { get ; set ; }

    }
}
