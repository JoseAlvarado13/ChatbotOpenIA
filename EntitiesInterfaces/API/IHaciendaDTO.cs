using EntitiesInterfaces.Commons;

namespace EntitiesInterfaces.API
{
    /// <summary>
    /// AM-001
    /// Author: José Andrés Alvarado Matamoros
    /// This interfaces manages the hacienda properties to call diferents endpoint in the API Services.
    /// </summary>
    public interface IHaciendaDTO: ICommonsSettingsDTO
    {        
        string ExchangeRate {  get; set; }
    }
}
