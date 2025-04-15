using EntitiesInterfaces.Base;

namespace BusinessLogicInterfaces.Commons
{
    /// <summary>
    /// AM-002
    /// Author: José Andrés Alvarado Matamoros
    /// This interface handles Base64 encoding and decoding operations.
    /// </summary>
    public interface IBase64BL
    {
        #region Encode
        /// <summary>
        /// AM-002
        /// José Andrés Alvarado Matamoros.
        /// Encodes a plain text string to Base64 format.
        /// </summary>
        /// <param name="plainText">The plain text to encode.</param>
        /// <returns>A Base64 encoded string.</returns>
        string Encode(string plainText);
        #endregion

        #region Decode
        /// <summary>
        /// AM-002
        /// José Andrés Alvarado Matamoros.
        /// Decodes a Base64 string to plain text.
        /// </summary>
        /// <param name="base64Text">The Base64 encoded string to decode.</param>
        /// <returns>The decoded plain text string.</returns>
        string Decode(string base64Text);
        #endregion
    }
}
