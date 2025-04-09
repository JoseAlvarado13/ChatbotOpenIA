using EntitiesInterfaces.API;
using Settings.API.Hacienda;

namespace Entities.API
{
    /// <summary>
    /// AM-001
    /// Author: José Andrés Alvarado Matamoros
    /// Class manage the hacienda properties to call diferents endpoint in the API Services.
    /// </summary>
    public class HaciendaDTO : IHaciendaDTO
    {
        public HaciendaDTO()
        {
            this.Host = new HaciendaCfg().Get(HaciendaType.Host);
            this.ExchangeRate = new HaciendaCfg().Get(HaciendaType.ExchangeRate);
        }
        public string Host { get; set; }
        public string ExchangeRate { get ; set ; }
        
    }
}
