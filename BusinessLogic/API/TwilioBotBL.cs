using BusinessLogic.Commons;
using BusinessLogicInterfaces.API;
using BusinessLogicInterfaces.Commons;
using Entities.Base;
using EntitiesInterfaces.Base;
using Microsoft.AspNetCore.Mvc;
using Twilio.TwiML;

namespace BusinessLogic.API
{
    /// <summary>
    /// AM-002
    /// Author: José Andrés Alvarado Matamoros
    /// Class manage the twilio conecction API  
    /// </summary>
    public class TwilioBotBL : ITwilioBotBL
    {
        private ICompletionsBL completionsBL;
        #region Constructor 
        /// <summary>
        /// AM-002
        /// Author: José Andrés Alvarado Matamoros
        /// Initializes the basic authentication API configuration.
        /// </summary>
        public TwilioBotBL()
        {
            completionsBL = new CompletionsBL();
        }
        #endregion
        #region Get
        /// <summary>
        /// AM-002
        /// José Andres Alvarado Matamoros.
        /// Method handle of get message that I sent from Whatsapp.
        /// </summary>
        /// <param name="Body"> Here came the question from Whatsapp</param> 
        /// <param name="From"> Here came the number of Whatsapp from  who sent a message

        public IActionResult Get([FromForm] string Body, [FromForm] string From)
        {
            ContentResult Response;
            try
            {
               var response = new MessagingResponse();                
               IResponseDTO responseDTO = completionsBL.Post(Body);
               string answer = responseDTO.Value.ToString();

                response.Message(answer);

                Response = new ContentResult
                {
                    Content = response.ToString(),
                    ContentType = "application/xml",
                    StatusCode = 200
                };

            }
            catch (Exception ex)
            {
                Response = new ContentResult
                {
                    Content = "Ha ocurrido un error al momento de consultar su pregunta, pongase en contacto con el departamento de soporte",
                    ContentType = "application/xml",
                    StatusCode = 400
                };
            }
            return Response;
        }
        #endregion        
    }
}
