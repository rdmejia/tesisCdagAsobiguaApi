using System;
using System.Security.Cryptography;
using System.Text;

namespace tesisCdagAsobiguaApi.Extensions
{
    public static class EncryptionExtensions
    {
        public static byte[] EncryptString(this string value)
        {
            var data = Encoding.UTF8.GetBytes(value);
            var sha512Managed = new SHA512Managed();
            return sha512Managed.ComputeHash(data);
        }

        public static string ToByteArrayString(this byte[] value) => BitConverter.ToString(value);
    }
}
