// Copyright (c) Tim Kennedy. All Rights Reserved. Licensed under the MIT License.

namespace CultureList.Converters;

/// <summary>
/// Converter that changes Spacing to GridLength for Row Height
/// </summary>
internal sealed class RowHeightConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is Spacing spacing)
        {
            switch (spacing)
            {
                case Spacing.Compact:
                    return new GridLength(20);
                case Spacing.Comfortable:
                    return new GridLength(26);
                case Spacing.Wide:
                    return new GridLength(30);
            }
        }
        return new GridLength(30);
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return Binding.DoNothing;
    }
}
