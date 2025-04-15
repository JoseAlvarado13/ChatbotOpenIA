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
    public class ExchangeRateController : Controller
    {
        #region Get
        [HttpGet]   
        public IResponseDTO Get()
        {
            IExchangeRateBL exchangeRateBL = new ExchangeRateBL();
            return exchangeRateBL.Get();
        }
        #endregion
    }
}
