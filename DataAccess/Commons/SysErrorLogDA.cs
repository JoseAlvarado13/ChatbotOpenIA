using DataAccess.DataModel.DracarysModel;
using DataAccessInterface.Commons;
using Entities.Commons;
using EntitiesInterfaces.Base;

namespace DataAccess.Commons
{
    /// <summary>
    /// AM-001
    /// Author: José Andrés Alvarado Matamoros
    /// 
    /// This class manages the syserrorlog CRUD.
    /// </summary>
    public class SysErrorLogDA : ISysErrorLogDA
    {
        #region Save 
        /// <summary>        
        /// AM-001
        /// Author: José Andrés Alvarado Matamoros 
        /// Method to save the system error log inside data base.  
        /// 
        /// To do: there are an error loading the  dracarys context, I have to review this code in this moment
        /// </summary>
        /// <param name="exceptionDTO">Here came the exception information about error.</param> 
        public int Save(IExceptionDTO exceptionDTO)
        {
            try
            {
                using (DracarysContext context = new DracarysContext(new DataBaseDTO()))
                {
                    return context.UspSaveSysErrorLog(exceptionDTO.HostName, exceptionDTO.Error, exceptionDTO.Class, exceptionDTO.Method, exceptionDTO.CurrentDate, exceptionDTO.IsEnable);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
                 
        }
        #endregion
    }
}
