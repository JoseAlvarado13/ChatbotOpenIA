using EntitiesInterfaces.Security;
using Settings.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Security
{
    public class OpenAIAuthorizationDTO : IOpenAIAuthorizationDTO
    {
        public OpenAIAuthorizationDTO()
        {
            this.ApiKey = new OpenAIAuthorizationCfg().Get(AuthorizationType.ApiKey);
        }
        public string ApiKey { get; set; }
    }
}
