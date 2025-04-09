using EntitiesInterfaces.API;

namespace Entities.API
{
    /// <summary>
    /// AM-001
    /// Author:  José Andrés Alvarado Matamoros.
    /// Class manage entities handle Api response.
    /// </summary>
    public class ApiResponseDTO : IApiResponseDTO
    {
        public int StatusCode { get ; set ; }
        public string Status { get ; set ; }
        public string Message { get ; set ; }
        public string Timestamp { get ; set ; }
        public string Data { get ; set ; }
    }
}
