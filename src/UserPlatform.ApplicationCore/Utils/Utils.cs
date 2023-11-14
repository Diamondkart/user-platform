using BCrypt.Net;
using PasswordGenerator;
using System.Text;
using UserPlatform.ApplicationCore.Models;

namespace UserPlatform.ApplicationCore.Utils
{
    public static class Utils
    {
        /// <summary>
        /// Return Password and salt
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static PasswordModel GetSecurePassword(string password, string salt=null)
        {
            
            salt = salt ?? BCrypt.Net.BCrypt.GenerateSalt();
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);
            var base64pwd = Convert.ToBase64String(Encoding.Unicode.GetBytes(hashedPassword));
            return new PasswordModel { Password=base64pwd, Salt=salt };
        }
        public static PasswordModel GenerateToken(string password)
        {
            return GetSecurePassword(password);
        }
        

        public static string GenerateFullToken(List<string> tokenList)
        {
            var token = string.Empty;
            var random = new Random();
            tokenList.ForEach(t =>
            {
                token += t;
            });
            var base64Token = token.Replace("=", "").ToArray();
            for (var i=0;i<base64Token.Length;i++)
            {
                var index=random.Next(base64Token.Length);
                var charAtIndex = base64Token[index];
                base64Token[index] = charAtIndex;
                base64Token[i] = charAtIndex;
            }
            return new string(base64Token);
        }

        public static string GenerateRandomPassword(int length = 6)
        {
            var pwd = new Password(includeLowercase: true, includeUppercase: true, includeNumeric: true, includeSpecial: true, passwordLength: length);
            var password = pwd.Next();
            return password;
        }
    }
}