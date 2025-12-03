using System.Security.Cryptography;
using System.Text;

namespace TallerMolinaproyecto
{
    public static class Security
    {
        public static string Sha256(string text)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(text);
                byte[] hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }
}
