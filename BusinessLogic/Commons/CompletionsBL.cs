using BusinessLogic.API;
using BusinessLogic.Base;
using BusinessLogicInterfaces.API;
using BusinessLogicInterfaces.Commons;
using Entities.API;
using Entities.Base;
using Entities.Security;
using EntitiesInterfaces.API;
using EntitiesInterfaces.Base;
using EntitiesInterfaces.Commons.Enums;
using EntitiesInterfaces.Security;
using System.Text.Json;

namespace BusinessLogic.Commons
{
    public class CompletionsBL : BaseCommonsSettingsBL, ICompletionsBL
    {
        private IApiConfigurationBL apiConfigurationBL;
        private IOpenAiSettingsDTO openAiSettingsDTO;
        private IOpenAIAuthorizationDTO openAiAuthorizationDTO;
        private IOpenAiEndpointDTO openAiEndpointDTO;
        private IBase64BL  base64BL;
        public CompletionsBL()
        {
            openAiSettingsDTO = new OpenAiSettingsDTO();
            openAiAuthorizationDTO = new OpenAIAuthorizationDTO();
            openAiEndpointDTO = new OpenAiEndpointDTO();
            base64BL = new Base64BL();
        }

        public IResponseDTO Post(string prompt)
        {
            IResponseDTO Response = new ResponseDTO();
            //In here we build the body of the request and 
            try
            {
                //Validation to know if we are using the sandbox
                if (openAiSettingsDTO.UseSandbox)
                {

                    Response.Result = ActionResult.Success;
                    Response.Value = "Simulación de respuesta en entorno Sandbox";
                    return Response;
                }

                var body = new
                {
                    model = openAiSettingsDTO.Model,
                    messages = new[]
                    {
                        new { role = "system", content = "Eres un asistente experto en TI y desarrollo de software. No puedes responder preguntas fuera de este dominio. Si se te hace una pregunta fuera de TI, responde: 'Lo siento, solo puedo responder consultas sobre tecnología y desarrollo de software.'" },
                        new { role = "user", content = prompt }
                    },
                    temperature = openAiSettingsDTO.Temperature,
                    max_tokens = openAiSettingsDTO.MaxTokens
                    
                };

                apiConfigurationBL = new ApiConfigurationBL
                {
                    Url = openAiEndpointDTO.Host + openAiEndpointDTO.Completions,
                    Method = HttpMethod.Post,
                    Content = body,
                    BaseAuthentication = base64BL.Decode(openAiAuthorizationDTO.ApiKey)
                };

                var result = apiConfigurationBL.Call();

                // Parse the JSON response to extract only the relevant data (the assistant's reply).
                using var doc = JsonDocument.Parse(result);

                // Access the "choices" array in the JSON response, which contains the model's reply.
                var content = doc.RootElement
                                 .GetProperty("choices")[0]          
                                 .GetProperty("message")             
                                 .GetProperty("content")             
                                 .GetString();                       

                Response.Result = ActionResult.Success;

                // Store the extracted response content (the assistant's reply) in the Value property.
                Response.Value = content?.Trim(); 

            }
            catch (Exception ex) {
                Response = ManageException(
                        new ExceptionDTO
                        {
                            Class  = this.GetType().Name,
                            Method = Method.Get.ToString(),
                            Error = ex.ToString(),
                        });
            }
            return Response;
        }
    }
}
