using Microsoft.AspNetCore.Mvc;

namespace BusinessLogicInterfaces.API
{
    /// <summary>
    /// AM-002
    /// Author: José Andrés Alvarado Matamoros
    /// Interface manage the twilio conecction API  
    /// </summary>
    public interface ITwilioBotBL
    {
        #region Get
        /// <summary>
        /// AM-002
        /// José Andres Alvarado Matamoros.
        /// Method handle of get message that I sent from Whatsapp.
        /// </summary>
        /// <param name="Body"> Here came the question from Whatsapp</param> 
        /// <param name="From"> Here came the number of Whatsapp from  whom sent message</param> 
        /// <returns>A string containing the OpenIA response.</returns>    
        IActionResult Get([FromForm] string Body, [FromForm] string From);
        #endregion
    }
}
