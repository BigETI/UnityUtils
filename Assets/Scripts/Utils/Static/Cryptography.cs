using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Utilities namespace
/// </summary>
namespace Utils
{
    /// <summary>
    /// Cryptography
    /// </summary>
    public static class Cryptography
    {
        /// <summary>
        /// SHA 256
        /// </summary>
        /// <param name="text">Text</param>
        /// <returns>Result</returns>
        public static string SHA256(string text)
        {
            StringBuilder ret = new StringBuilder();
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            foreach (byte b in hash)
            {
                ret.Append(string.Format("{0:x2}", b));
            }
            return ret.ToString();
        }

        /// <summary>
        /// SHA 512
        /// </summary>
        /// <param name="text">Text</param>
        /// <returns>Result</returns>
        public static string SHA512(string text)
        {
            StringBuilder ret = new StringBuilder();
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA512Managed hashstring = new SHA512Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            foreach (byte b in hash)
            {
                ret.Append(string.Format("{0:x2}", b));
            }
            return ret.ToString();
        }
    }
}
