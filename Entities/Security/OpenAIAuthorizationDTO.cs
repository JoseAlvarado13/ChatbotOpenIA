
using EntitiesInterfaces.Security;
using Settings.Security;

namespace Entities.Security
{
    //We separate our code in different DTO, this holds the specific config for the Bearer Auth -> API KEY, we need so send to the OpenAI API
    public class OpenAIAuthorizationDTO : IOpenAIAuthorizationDTO
    {
        public OpenAIAuthorizationDTO()
        {
            this.ApiKey = new OpenAIAuthorizationCfg().Get(OpenAIAuthorizationType.ApiKey);
        }
        public string ApiKey { get; set; }
    }
}
