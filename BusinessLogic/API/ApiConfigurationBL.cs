using BusinessLogicInterfaces.API;
using System.Text;

namespace BusinessLogic.API
{
    /// <summary>
    /// AM-001
    /// José Andres Alvarado Matamoros.
    /// Class that defines the structure and methods required for configuring and 
    /// executing API calls. This class standardizes the properties and operations 
    /// needed to perform HTTP requests consistently.
    /// </summary>
    public class ApiConfigurationBL : IApiConfigurationBL
    {
        public string Url { get; set; }
        public HttpMethod Method { get; set; }
        public object Content { get; set; }
        public string BaseAuthentication { get; set; }
        private static readonly HttpClient client = new HttpClient();

        #region Constructor 
        /// <summary>
        /// AM-001
        /// Author: José Andrés Alvarado Matamoros
        /// Initializes the basic authentication API configuration.
        /// </summary>
        public ApiConfigurationBL()
        {
            // Ensure default headers are cleared before adding a new Authorization header.
            client.DefaultRequestHeaders.Clear();
        }
        #endregion

        #region Get
        /// <summary>
        /// AM-001
        /// José Andres Alvarado Matamoros.
        /// Generates and configures an HttpRequestMessage object based on 
        /// the current property values, including URL, method, content, and 
        /// authentication. This method prepares the request for sending.
        /// </summary>
        /// <returns>An HttpRequestMessage object ready to send the HTTP request.</returns>
        public HttpRequestMessage Get()
        {
            if (string.IsNullOrEmpty(Url))
                throw new ArgumentException("URL must not be null or empty.");

            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(Url),
                Method = Method
            };

            if (!string.IsNullOrEmpty(BaseAuthentication))
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + BaseAuthentication);
            }

            // Add content only for methods like POST or PUT
            if ((Method == HttpMethod.Post || Method == HttpMethod.Put) && Content != null)
            {
                string jsonContent = Content is string ? Content.ToString() : System.Text.Json.JsonSerializer.Serialize(Content);
                request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            }

            return request;
        }
        #endregion

        #region Call
        /// <summary>
        /// AM-001
        /// José Andres Alvarado Matamoros.
        /// Executes the API call using the configured values and 
        /// returns the response as a string. This method handles 
        /// the entire interaction with the API server.
        /// </summary>
        /// <returns>A string containing the server's response.</returns>
        public string Call()
        {
            try
            {
                HttpRequestMessage request = Get();
                HttpResponseMessage response = client.Send(request);

                string responseContent = response.Content.ReadAsStringAsync().Result;

                // Log or handle non-successful responses
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {responseContent}");
                }

                return responseContent;
            }
            catch (Exception ex)
            {
                // Log exception or rethrow
                throw new Exception("An error occurred while making the API call.", ex);
            }
        }
        #endregion
    }

}
    