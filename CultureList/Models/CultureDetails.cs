// Copyright (c) Tim Kennedy. All Rights Reserved. Licensed under the MIT License.

namespace CultureList.Models;

/// <summary>
/// This class is a subset of the System.Globalization.CultureInfo class.
/// </summary>
internal partial class CultureDetails : ObservableObject
{
    #region Properties
    [ObservableProperty]
    private string? _amDesignator;

    [ObservableProperty]
    private string? _decimalSeparator;

    [ObservableProperty]
    private string? _displayName;

    [ObservableProperty]
    private string? _englishName;

    [ObservableProperty]
    private string? _firstDayOfWeek;

    [ObservableProperty]
    private string? _ietfLanguageTag;

    [ObservableProperty]
    private string? _languageCode;

    [ObservableProperty]
    private int _lcid;

    [ObservableProperty]
    private string? _longDate;

    [ObservableProperty]
    private string? _longTime;

    [ObservableProperty]
    private string? _nativeName;

    [ObservableProperty]
    private string? _numberGroupSeparator;

    [ObservableProperty]
    private string? _pmDesignator;

    [ObservableProperty]
    private string? _shortDate;

    [ObservableProperty]
    private string? _shortTime;

    [ObservableProperty]
    private string? _threeLetterIsoName;

    [ObservableProperty]
    private string? _threeLetterWindowsName;

    [ObservableProperty]
    private string? _twoLetterIsoName;
    #endregion Properties
}
