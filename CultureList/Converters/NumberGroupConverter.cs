// Copyright (c) Tim Kennedy. All Rights Reserved. Licensed under the MIT License.

namespace CultureList.Converters;

/// <summary>
/// Converter that changes non-displayable separator characters to a descriptive string.
/// </summary>
internal sealed class NumberGroupConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is string separator)
        {
            byte[] ba = Encoding.Default.GetBytes(separator);
            return BitConverter.ToString(ba).Replace("-", "") switch
            {
                "C2A0" => GetStringResource("Details_NBSpaceChar"),
                "E280AF" => GetStringResource("Details_NNBSpaceChar"),
                "20" => GetStringResource("Details_SpaceChar"),
                _ => separator,
            };
        }
        return value!;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return Binding.DoNothing;
    }
}
