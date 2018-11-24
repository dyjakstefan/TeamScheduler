using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using TeamScheduler.Infrastructure.Extensions;
using TeamScheduler.Infrastructure.Services.Abstract;

namespace TeamScheduler.Infrastructure.Services
{
    public class Encrypter : IEncrypter
    {
        private static readonly int DeriveBytesIterationsCount = 10000;
        private static readonly int SaltSize = 40;

        public string GetSalt(string value)
        {
            if (value.Empty())
            {
                throw new ArgumentException("Can not generate salt from an empty value.", nameof(value));
            }

            var random = new Random();
            var saltBytes = new byte[SaltSize];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);

            return Convert.ToBase64String(saltBytes);
        }

        public string GetHash(string values, string salt)
        {
            if (values.Empty())
            {
                throw new ArgumentException("Can not generate hash from an empty value.", nameof(values));
            }

            if (salt.Empty())
            {
                throw new ArgumentException("Can not use an empty salt for hashing value.", nameof(values));
            }

            var pbkdf2 = new Rfc2898DeriveBytes(values, GetBytes(salt), DeriveBytesIterationsCount);

            return Convert.ToBase64String(pbkdf2.GetBytes(SaltSize));
        }

        private static byte[] GetBytes(string value)
        {
            var bytes = new byte[value.Length * sizeof(char)];
            Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
    }
}
