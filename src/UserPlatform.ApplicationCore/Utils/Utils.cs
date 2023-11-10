using System.Text;

namespace UserPlatform.ApplicationCore.Utils
{
    public class Utils
    {
        /// <summary>
        /// Return Password and salt
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static (string, string) GetSecurePassword(string password)
        {
            var base64salt = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{BCrypt.Net.BCrypt.GenerateSalt(12)}.{Guid.NewGuid()}.{DateTime.UtcNow}"));
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, base64salt);
            var base64pwd = Convert.ToBase64String(Encoding.UTF8.GetBytes(hashedPassword));
            return (base64pwd, base64salt);
        }
    }
}