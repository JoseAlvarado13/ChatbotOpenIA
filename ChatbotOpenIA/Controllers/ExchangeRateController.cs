using BusinessLogic.Commons;
using BusinessLogicInterfaces.Commons;
using EntitiesInterfaces.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuideStructureAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")] 
    /// <summary>
    /// AM-001
    /// Author: José Andrés Alvarado Matamoros
    /// Contoller manage exchange rate  to public hacienda of Costa Rica services.
    /// </summary>
    public class ExchangeRateController : Controller
    {
        #region Get
        [HttpGet]
        /// <summary>
        /// AM-001
        /// José Andres Alvarado Matamoros.
        /// Method handle of get exchange rate to public hacienda of Costa Rica services.
        /// </summary>
        /// <param></param> 
        /// <returns>A string containing the exchange rate response.</returns>
        public IResponseDTO Get()
        {
            IExchangeRateBL exchangeRateBL = new ExchangeRateBL();
            return exchangeRateBL.Get();
        }
        #endregion
    }
}
