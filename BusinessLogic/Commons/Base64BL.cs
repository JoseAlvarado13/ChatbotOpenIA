using BusinessLogicInterfaces.Commons;
using System.Text;

namespace BusinessLogic.Commons
{
    /// <summary>
    /// AM-002
    /// Author: José Andrés Alvarado Matamoros
    /// This class implements Base64 encoding and decoding functionalities.
    /// </summary>
    public class Base64BL : IBase64BL
    {
        #region Encode
        /// <summary>
        /// AM-002
        /// José Andrés Alvarado Matamoros.
        /// Encodes a plain text string into Base64 format using UTF-8 encoding.
        /// </summary>
        /// <param name="plainText">The plain text to encode.</param>
        /// <returns>A Base64 encoded string.</returns>
        public string Encode(string plainText)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(bytes);
        }
        #endregion

        #region Decode
        /// <summary>
        /// AM-002
        /// José Andrés Alvarado Matamoros.
        /// Decodes a Base64 encoded string back into plain text using UTF-8 encoding.
        /// </summary>
        /// <param name="base64Text">The Base64 encoded string to decode.</param>
        /// <returns>The decoded plain text string.</returns>
        public string Decode(string base64Text)
        {
            byte[] bytes = Convert.FromBase64String(base64Text);
            return Encoding.UTF8.GetString(bytes);
        }
        #endregion
    }
}
