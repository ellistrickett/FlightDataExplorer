using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using CsvHelper;

namespace FlightDataExplorer.CsvMappings
{
    public class NullableValueConverter<T> : DefaultTypeConverter where T : struct
    {
        public override object? ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (text == "\\N")
            {
                return null;
            }

            if (typeof(T) == typeof(double))
            {
                if (double.TryParse(text, out var result))
                {
                    return result;
                }
                return null;
            }

            if (typeof(T) == typeof(int))
            {
                if (int.TryParse(text, out var result))
                {
                    return result;
                }
                return null;
            }

            return base.ConvertFromString(text, row, memberMapData);

        }
    }
}
