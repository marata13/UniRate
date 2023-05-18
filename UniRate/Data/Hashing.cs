using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;

namespace UniRate.Data
{
    public class Hashing
    {
        private static readonly string pepper = "901A27086541F6F438BF6C87C03DB39B";

        //private static readonly DatabaseSettings _databaseSettings;

        //public Hashing(IOptions<DatabaseSettings> options)
        //{
        //    _databaseSettings = options.Value;
        //}

        public static string HashPasword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(64);

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password + pepper),
                salt,
                1_000_000,
                HashAlgorithmName.SHA512,
                64);

            return Convert.ToHexString(hash);
        }

        public static bool VerifyPassword(string password, string hash, byte[] salt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password + pepper, salt, 1_000_000, HashAlgorithmName.SHA512, 64);

            return hashToCompare.SequenceEqual(Convert.FromHexString(hash));
        }
    }

    //public class DatabaseSettings
    //{
    //    public string Pepper { get; set; }
    //}
}
