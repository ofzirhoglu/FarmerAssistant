using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public static class HashingHelper
    {
        // Parametre olarak aldığı 'password' değerinin geriye 'passwordHash' ile 'passwordSalt' ını döner
        public static void CreatePasswordHash(
            string password,
            out byte[] passwordHash,
            out byte[] passwordSalt
            )
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        // Parametre olarak aldığı 'passwordSalt' değerini kullanarak 'password'U yeniden hashler
        // ve parametre olarak aldığı 'passwordHash' değeri ile yeniden hashlediği password değerini (computedHash) karşılaştırır
        public static bool VerifyPasswordHash(
            string password,
            byte[] passwordHash,
            byte[] passwordSalt
            )
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}