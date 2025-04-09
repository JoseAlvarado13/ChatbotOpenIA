using EntitiesInterfaces.Base;

namespace BusinessLogicInterfaces.Commons
{
    /// <summary>
    /// AM-001
    /// Author: José Andrés Alvarado Matamoros
    /// This interface manage exchange rate  to public hacienda of Costa Rica services.
    /// </summary>
    public interface IExchangeRateBL
    {
        #region Get
        /// <summary>
        /// AM-001
        /// José Andres Alvarado Matamoros.
        /// Method handle of get exchange rate to public hacienda of Costa Rica services.
        /// </summary>
        /// <param></param> 
        /// <returns>A string containing the exchange rate response.</returns>
        IResponseDTO Get();
        #endregion
    }
}
