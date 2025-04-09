namespace EntitiesInterfaces.API
{
    /// <summary>
    /// AM-001
    /// Author:  José Andrés Alvarado Matamoros.
    /// Interface manage entities handle Api response.
    /// </summary>
    public interface IApiResponseDTO
    {
        int StatusCode { get; set; }
        string Status { get; set; }
        string Message { get; set; }
        string Timestamp { get; set; }
        string Data { get; set; } 
    }
}
