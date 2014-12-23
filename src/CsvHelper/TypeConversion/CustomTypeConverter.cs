using System;
#if NET_2_0
using CsvHelper.MissingFrom20;
#endif

namespace CsvHelper.TypeConversion
{
    internal sealed class CustomTypeConverter : ITypeConverter
    {
        private readonly Func<object, string> convertToExpression;
        private readonly Func<string, object> convertFromExpression;

        public CustomTypeConverter( Func<object, string> convertToExpression,
            Func<string, object> convertFromExpression )
        {
            this.convertToExpression = convertToExpression;
            this.convertFromExpression = convertFromExpression;
        }

        public string ConvertToString( TypeConverterOptions options, object value )
        {
            return convertToExpression.Invoke( value );
        }

        public object ConvertFromString( TypeConverterOptions options, string text )
        {
            return convertFromExpression.Invoke( text );
        }

        public bool CanConvertFrom( Type type )
        {
            return convertFromExpression != null;
        }

        public bool CanConvertTo( Type type )
        {
            return convertToExpression != null;
        }
    }
}
