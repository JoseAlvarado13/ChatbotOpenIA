using BusinessLogic.Commons;
using BusinessLogicInterfaces.Commons;
using EntitiesInterfaces.Base;
using Microsoft.AspNetCore.Mvc;

namespace ChatbotOpenIA.Controllers
{
    [ApiController]
    [Route("ChatBot/[controller]")]
    public class CompletionsContrsoller : Controller
    {
        [HttpPost("Ask")]
        public  IResponseDTO Post([FromBody] string prompt)
        {
            ICompletionsBL completionsBL = new CompletionsBL();
            return  completionsBL.Post(prompt);
        }
    }
}
