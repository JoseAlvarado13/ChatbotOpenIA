using BusinessLogic.API;
using BusinessLogic.Base;
using BusinessLogicInterfaces.API;
using BusinessLogicInterfaces.Commons;
using Entities.API;
using Entities.Base;
using EntitiesInterfaces.API;
using EntitiesInterfaces.Base;
using EntitiesInterfaces.Commons.Enums;

namespace BusinessLogic.Commons
{
    /// <summary>
    /// AM-001
    /// Author: José Andrés Alvarado Matamoros
    /// Class manage exchange rate  to public hacienda of Costa Rica services.
    /// </summary>
    public class ExchangeRateBL : BaseCommonsSettingsBL , IExchangeRateBL
    {
        #region Global Data 
        /// <summary>        
        /// AM-001
        /// Author: José Andrés Alvarado Matamoros 
        /// Here you can find instances or global variables.
        /// </summary>    
        private IApiConfigurationBL apiConfigurationBL;
        private IHaciendaDTO haciendaDTO;
        #endregion

        #region Constructor 
        /// <summary>        
        /// AM-001
        /// Author: José Andrés Alvarado Matamoros 
        /// Constructor for initializing the class with the configuration object.
        /// </summary>
        /// <param></param>
        public ExchangeRateBL()
        {
          
            haciendaDTO = new HaciendaDTO();
        }
        #endregion

        #region Get
        /// <summary>
        /// AM-001
        /// José Andres Alvarado Matamoros.
        /// Method handle of get exchange rate to public hacienda of Costa Rica services.
        /// </summary>
        /// <param></param> 
        /// <returns>A string containing the exchange rate response.</returns>
        public IResponseDTO Get()
        {
            IResponseDTO Response= new ResponseDTO();
            try
            {
                apiConfigurationBL = new ApiConfigurationBL
                {
                    Url = haciendaDTO.Host + haciendaDTO.ExchangeRate,
                    Method = HttpMethod.Get
                };

                Response.Value = apiConfigurationBL.Call();
            }
            catch (Exception ex)
            {
                Response = ManageException(
                    new ExceptionDTO {                        
                        Class  = this.GetType().Name,
                        Method = Method.Get.ToString(),
                        Error = ex.ToString(),                        
                    });                    
            }           
            return Response;
        }
        #endregion
    }
}
