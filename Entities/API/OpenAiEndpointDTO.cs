using EntitiesInterfaces.API;
using Settings.API.Hacienda;
using Settings.API.OpenAI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.API
{
    public class OpenAiEndpointDTO : IOpenAiEndpointDTO
    {
        public OpenAiEndpointDTO()
        {
            var cfg = new OpenAIEndpointCfg();

            this.Host = cfg.Get(OpenAIEndpointType.Host);
            this.Completions = cfg.Get(OpenAIEndpointType.Completions);
        }
        public string Completions { get; set; }
        public string Host { get; set; }
    }
}
