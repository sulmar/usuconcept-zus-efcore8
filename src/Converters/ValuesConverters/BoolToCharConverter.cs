using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Converters.CustomConverters
{
    public class BoolToCharConverter : ValueConverter<bool, char>
    {
        public BoolToCharConverter(char falseValue, char trueValue) : base(
            v => v ? trueValue : falseValue,   // Convert from bool to char
            v => v == trueValue         // Convert from char to bool
        )
        { }
    }
}
