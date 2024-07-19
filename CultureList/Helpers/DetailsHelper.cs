// Copyright (c) Tim Kennedy. All Rights Reserved. Licensed under the MIT License.

namespace CultureList.Helpers;

internal static class DetailsHelper
{
    #region Get details
    /// <summary>
    /// Get CultureInfo details.
    /// </summary>
    /// <param name="culture">CultureInfo of a single culture.</param>
    /// <returns>A Dictionary of culture details.</returns>
    public static Dictionary<string, string> GetDetails(CultureInfo culture)
    {
        CultureDetails cd = new()
        {
            DisplayName = culture.DisplayName,
            EnglishName = culture.EnglishName,
            LanguageCode = culture.Name,
            Lcid = culture.LCID,
            LongDate = culture.DateTimeFormat.LongDatePattern,
            LongTime = culture.DateTimeFormat.LongTimePattern,
            NativeName = culture.NativeName,
            ShortDate = culture.DateTimeFormat.ShortDatePattern,
            ShortTime = culture.DateTimeFormat.ShortTimePattern,
            ThreeLetterIsoName = culture.ThreeLetterISOLanguageName,
            ThreeLetterWindowsName = culture.ThreeLetterWindowsLanguageName,
            TwoLetterIsoName = culture.TwoLetterISOLanguageName,
            DecimalSeparator = culture.NumberFormat.NumberDecimalSeparator,
            NumberGroupSeparator = culture.NumberFormat.NumberGroupSeparator,
            AmDesignator = culture.DateTimeFormat.AMDesignator,
            PmDesignator = culture.DateTimeFormat.PMDesignator,
            FirstDayOfWeek = culture.DateTimeFormat.FirstDayOfWeek.ToString(),
            IetfLanguageTag = culture.IetfLanguageTag,
        };

        // The order of these statements will be the order that they appear in the datagrid.
        return new()
        {
            {GetStringResource("Details_DisplayName"), cd.DisplayName},
            {GetStringResource("Details_NativeName"), cd.NativeName},
            {GetStringResource("Details_EnglishName"), cd.EnglishName},
            {GetStringResource("Details_LanguageCode"), cd.LanguageCode},
            {GetStringResource("Details_IeftTag"), cd.IetfLanguageTag},
            {GetStringResource("Details_TwoLetterIsoLanguage"), cd.TwoLetterIsoName},
            {GetStringResource("Details_ThreeLetterIsoLanguage"), cd.ThreeLetterIsoName},
            {GetStringResource("Details_Lcid"), cd.Lcid.ToString()},
            {GetStringResource("Details_ShortTimePattern"), cd.ShortTime},
            {GetStringResource("Details_ShortDatePattern"), cd.ShortDate},
            {GetStringResource("Details_LongTimePattern"), cd.LongTime},
            {GetStringResource("Details_LongDatePattern"), cd.LongDate},
            {GetStringResource("Details_FirstDayOfWeek"), cd.FirstDayOfWeek},
            {GetStringResource("Details_AmDesignator"), cd.AmDesignator},
            {GetStringResource("Details_PmDesignator"), cd.PmDesignator},
            {GetStringResource("Details_DecimalSeparator"), FormatSeparator(cd.DecimalSeparator)},
            {GetStringResource("Details_NumberGroupSeparator"), FormatSeparator(cd.NumberGroupSeparator)},
        };
    }
    #endregion Get details

    #region Format the separator string
    /// <summary>
    /// Replaces "blank" characters with descriptive text.
    /// </summary>
    /// <param name="separator">The separator.</param>
    /// <returns>Descriptive text as needed.</returns>
    private static string FormatSeparator(string separator)
    {
        byte[] ba = Encoding.Default.GetBytes(separator);
        return BitConverter.ToString(ba).Replace("-", "") switch
        {
            "C2A0" => "non-breaking space",
            "E280AF" => "narrow non-breaking space",
            "20" => "space",
            _ => separator,
        };
    }
    #endregion Format the separator string
}
