using EntitiesInterfaces.Base;

namespace DataAccessInterface.Commons
{
    /// <summary>
    /// AM-001
    /// Author: José Andrés Alvarado Matamoros
    /// 
    /// This interface manages the syserrorlog CRUD.
    /// </summary>
    public interface ISysErrorLogDA
    {
        #region Save 
        /// <summary>        
        /// AM-001
        /// Author: José Andrés Alvarado Matamoros 
        /// Method to save the system error log inside data base.  
        /// </summary>
        /// <param name="exceptionDTO">Here came the exception information about error.</param> 
        public int Save(IExceptionDTO exceptionDTO);
        #endregion
    }
}
