using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tesisCdagAsobiguaApi.Extensions;

namespace tesisCdagAsobiguaApi.Converters
{
    public class PasswordEncryptionConverter : ValueConverter<string, byte[]>
    {
        public PasswordEncryptionConverter(ConverterMappingHints mappingHints = null) : base(EncryptExpression, PasswordToStringExpression, mappingHints)
        {
        }

        static Expression<Func<string, byte[]>> EncryptExpression = value => value.EncryptString();
        static Expression<Func<byte[], string>> PasswordToStringExpression = value => value.ToByteArrayString();
    }
}
