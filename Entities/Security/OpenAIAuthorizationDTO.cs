
using EntitiesInterfaces.Security;
using Settings.Security;

namespace Entities.Security
{
    public class OpenAIAuthorizationDTO : IOpenAIAuthorizationDTO
    {
        public OpenAIAuthorizationDTO()
        {
            this.ApiKey = new OpenAIAuthorizationCfg().Get(OpenAIAuthorizationType.ApiKey);
        }
        public string ApiKey { get; set; }
    }
}
