using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace ecs_dev_server.Services
{
    public static class HashService
    {
        private const int SaltSize = 64; // Base64

        /// <summary>
        /// Generates salt
        /// </summary>
        /// <returns>The salt key.</returns>
        public static string CreateSaltKey()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] rand = new byte[SaltSize];
            rng.GetBytes(rand);

            return Convert.ToBase64String(rand);
        }

        /// <summary>
        /// Hashes salted password with SHA-256 algorithm.
        /// Returns hashed password with length 44 bits to include padding.
        /// </summary>
        /// <returns>The password with salt.</returns>
        /// <param name="password">Password.</param>
        /// <param name="salt">Salt.</param>
        public static string HashPasswordWithSalt(string password, string salt)
        {
            string saltedPassword = String.Concat(password, salt);

            UTF8Encoding encoder = new UTF8Encoding();
            SHA256Managed hasher = new SHA256Managed();
            byte[] hashedBytes = hasher.ComputeHash(encoder.GetBytes(saltedPassword));
            return Convert.ToBase64String(hashedBytes);
        }
    }
}