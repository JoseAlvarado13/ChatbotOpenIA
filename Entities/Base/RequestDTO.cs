using EntitiesInterfaces.Base;

namespace Entities.Base
{
    /// <summary>
    /// AM-001
    /// Author:  José Andrés Alvarado Matamoros.
    /// Class is a versatile container class to store various types of data,
    /// including strings, JSON strings, integers, or other entities, this object is a Request class to manage in this base structure
    /// </summary>
    public class RequestDTO : IRequestDTO
    {
        #region Constructor 
        /// <summary>
        /// AM-001
        /// Author:  José Andrés Alvarado Matamoros.
        /// Constructor to initialize the container with any type of data.
        /// </summary>
        /// <param name="value">The data to store, which can be of any type.</param>     
        public RequestDTO(object value)
        {
            Value = value;
        }
        public RequestDTO()
        {
            
        }
        #endregion

        /// <summary>
        /// AM-001
        /// Author:  José Andrés Alvarado Matamoros.
        /// Stores data as a generic object, allowing any data type.
        /// </summary>
        public object Value { get; set; }        
        
    }
}
