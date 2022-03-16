using System;
using System.Security.Cryptography;
using System.Text;

namespace Heshlash.Api.Service.Services
{
    public class Heshshess
    {
        public string ComputeHash(string input, HashAlgorithm algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }
    }
}
