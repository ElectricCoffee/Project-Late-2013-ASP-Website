using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace BookingSite.Utils
{
    public enum HashType { MD5, SHA512, SHA256 }

    public static class TextHasher
    {
        public static string Hash(this string input, HashType hash)
        {
            Func<HashAlgorithm, string> hashFunction = alg => HashingHelper(input, alg);

            switch (hash)
            {
                case HashType.MD5   : return hashFunction(MD5.Create());
                     
                case HashType.SHA256: return hashFunction(SHA256.Create());

                case HashType.SHA512: return hashFunction(SHA512.Create());

                default: return "error"; // unreachable
            }
        }

        private static string HashingHelper(string text, HashAlgorithm algorithm)
        {
            Func<string, byte[]> getHash = input => algorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            var sb = new StringBuilder();
            Array.ForEach(getHash(text), b => sb.Append(b.ToString("X")));

            return sb.ToString();
        }
    }
}