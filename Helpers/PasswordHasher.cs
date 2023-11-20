using System.Security.Cryptography;

namespace BancaApi.Helpers
{
    public class PasswordHasher
    {
        private static RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        private static readonly int SaltSize = 16;
        private static readonly int HashSize = 20;
        private static readonly int Iterations = 10000;

        public static string HashPassword(string password)
        {
            byte[] salt;
            rng.GetBytes(salt = new byte[SaltSize]);
            var key = new Rfc2898DeriveBytes(password, salt, Iterations);
            var hash = key.GetBytes(HashSize);

            var hashBytes = new byte[SaltSize * HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            var base64Hash = Convert.ToBase64String(hashBytes);

            return base64Hash;
        }

        public static bool VerifyPassword(string password, string base64Hash)
        {
            try
            {
                var hashbytes = Convert.FromBase64String(base64Hash);
                var salt = new byte[SaltSize];
                Array.Copy(hashbytes, 0, salt, 0, SaltSize);

                var key = new Rfc2898DeriveBytes(password, salt, Iterations);
                byte[] hash = key.GetBytes(HashSize);

                for (var i = 0; i < HashSize; i++)
                {
                    if (hashbytes[i + SaltSize] != hash[i])
                    {
                        Console.WriteLine($"Mismatch at position {i}. Expected: {hash[i]}, Actual: {hashbytes[i + SaltSize]}");
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception during password verification: {ex}");
                return false;
            }
        }


    }
}
