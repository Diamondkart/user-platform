using BCrypt.Net;
using PasswordGenerator;
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
        public static (string, string) GetSecurePassword(string password, string salt=null)
        {
            
            salt = salt ?? BCrypt.Net.BCrypt.GenerateSalt();
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);
            var base64pwd = Convert.ToBase64String(Encoding.UTF8.GetBytes(hashedPassword));
            return (base64pwd, salt);
        }
        

        public static string GetFullToken(List<string> tokenList)
        {
            var token = string.Empty;
            tokenList.ForEach(t =>
            {
                token += t.Replace("-", "").Replace("/", "").Replace("$","").Replace(".","");
            });
            return token;
        }

        public static string GenerateRandomPassword(int length = 6)
        {
            var pwd = new Password(includeLowercase: true, includeUppercase: true, includeNumeric: true, includeSpecial: true, passwordLength: length);
            var password = pwd.Next();
            return password;
        }
    }
}