using BusinessLogicInterfaces.API;
using Entities.Base;
using EntitiesInterfaces.Commons.Enums;
using Microsoft.AspNetCore.Mvc;
using Twilio.Http;
using Twilio.TwiML;
using Twilio.TwiML.Messaging;

namespace BusinessLogic.API
{
    /// <summary>
    /// AM-002
    /// Author: José Andrés Alvarado Matamoros
    /// Class manage the twilio conecction API  
    /// </summary>
    public class TwilioBotBL : ITwilioBotBL
    {
        #region Constructor 
        /// <summary>
        /// AM-002
        /// Author: José Andrés Alvarado Matamoros
        /// Initializes the basic authentication API configuration.
        /// </summary>
        public TwilioBotBL()
        {
            
            
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
                // to do: In this line I have to call the Ismael's method to call OPEN IA  Services
                string answer = ProcessMessage(Body);

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

        // to do: this method should be removed from here, and I must use the Ismael logict , this code is only for a test
        private string ProcessMessage(string body)
        {
            // Aquí puedes agregar lógica de IA o contexto
            if (body.ToLower().Contains("hola"))
                return "Esta es una respuesta del API .NET 6 HECHA POR Ismael y Jose ¡Hola! ¿En qué puedo ayudarte sobre programación?";
            else if (body.ToLower().Contains("principio solid"))
                return "SOLID es un conjunto de principios para escribir buen código orientado a objetos...";
            else
                return "Lo siento, no entendí tu mensaje. Prueba preguntando sobre SOLID o saludando.";
        }
    }
}
