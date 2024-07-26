// Copyright (c) Tim Kennedy. All Rights Reserved. Licensed under the MIT License.

namespace CultureList.Helpers;

internal static class EnumHelpers
{
    /// <summary>
    /// Gets the enum description attribute.
    /// </summary>
    /// <param name="enumObj">The enum.</param>
    /// <returns>The enum description attribute as a string.</returns>
    internal static string GetEnumDescription(Enum enumObj)
    {
        FieldInfo? field = enumObj.GetType().GetField(enumObj.ToString());
        object[] attrArray = field!.GetCustomAttributes(false);

        if (attrArray.Length > 0)
        {
            DescriptionAttribute? attribute = attrArray[0] as DescriptionAttribute;
            return attribute!.Description;
        }
        else
        {
            return enumObj.ToString();
        }
    }
}
