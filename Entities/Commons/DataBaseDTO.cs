using EntitiesInterfaces.Commons;
using Settings.Commons;

namespace Entities.Commons
{

    /// <summary>
    /// AM-001
    /// Author: José Andrés Alvarado Matamoros
    /// This class manages way to get the default data base connection properties.
    /// </summary>
    public class DataBaseDTO : IDataBaseDTO
    {
        public DataBaseDTO()
        {
            this.DefaultConnection = new DataBaseCfg().Get(DataBaseType.DefaultConnection);            
        }        
        public string DefaultConnection { get; set; }
    }
}
