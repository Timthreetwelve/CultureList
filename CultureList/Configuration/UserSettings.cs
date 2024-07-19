// Copyright (c) Tim Kennedy. All Rights Reserved. Licensed under the MIT License.

namespace CultureList.Configuration;

[INotifyPropertyChanged]
public partial class UserSettings : ConfigManager<UserSettings>
{
    #region Properties (some with default values)
    /// <summary>
    /// Used to determine which culture types are listed.
    /// Valid values are: NeutralCultures = 1, SpecificCultures = 2, AllCultures = 7.
    /// All other values are deprecated.
    /// </summary>
    [ObservableProperty]
    private Cultures _selectedCultures = Cultures.AllCultures;

    /// <summary>
    ///  Used to determine if Debug level messages are included in the application log.
    /// </summary>
    [ObservableProperty]
    private bool _includeDebug = true;

    /// <summary>
    /// Keep window topmost.
    /// </summary>
    [ObservableProperty]
    private bool _keepOnTop;

    /// <summary>
    /// Enable language testing.
    /// </summary>
    [ObservableProperty]
    private bool _languageTesting;

    /// <summary>
    /// Accent color.
    /// </summary>
    [ObservableProperty]
    private AccentColor _primaryColor = AccentColor.Blue;

    /// <summary>
    /// Vertical spacing in the data grids.
    /// </summary>
    [ObservableProperty]
    private Spacing _rowSpacing = Spacing.Comfortable;

    /// <summary>
    /// Show Exit in the navigation menu.
    /// </summary>
    [ObservableProperty]
    private bool _showExitInNav = true;

    /// <summary>
    /// Show Decimal Separator in the grid.
    /// </summary>
    [ObservableProperty]
    private bool _showDecimalSep;

    /// <summary>
    /// Show Display Name in the grid.
    /// </summary>
    [ObservableProperty]
    private bool _showDisplayName = true;

    /// <summary>
    /// Show English Name in the grid.
    /// </summary>
    [ObservableProperty]
    private bool _showEnglishName;

    /// <summary>
    /// Show Group Separator in the grid.
    /// </summary>
    [ObservableProperty]
    private bool _showGroupSep;

    /// <summary>
    /// Show LCID in the grid.
    /// </summary>
    [ObservableProperty]
    private bool _showLCID;

    /// <summary>
    /// Show Long Format date and time in the grid.
    /// </summary>
    [ObservableProperty]
    private bool _showLongFormat;

    /// <summary>
    /// Show Group Separator in the grid.
    /// </summary>
    [ObservableProperty]
    private bool _showNativeName;

    /// <summary>
    /// Option start with window centered on screen.
    /// </summary>
    [ObservableProperty]
    private bool _startCentered;

    /// <summary>
    /// Defined language to use in the UI.
    /// </summary>
    [ObservableProperty]
    private string _uILanguage = "en-US";

    /// <summary>
    /// Amount of UI zoom.
    /// </summary>
    [ObservableProperty]
    private MySize _uISize = MySize.Default;

    /// <summary>
    /// Theme type.
    /// </summary>
    [ObservableProperty]
    private ThemeType _uITheme = ThemeType.System;

    /// <summary>
    /// Use the operating system language (if one has been provided).
    /// </summary>
    [ObservableProperty]
    private bool _useOSLanguage;

    /// <summary>
    /// Height of the window.
    /// </summary>
    [ObservableProperty]
    private double _windowHeight = 650;

    /// <summary>
    /// Position of left side of the window.
    /// </summary>
    [ObservableProperty]
    private double _windowLeft = 100;

    /// <summary>
    /// Position of the top side of the window.
    /// </summary>
    [ObservableProperty]
    private double _windowTop = 100;

    /// <summary>
    /// Width of the window.
    /// </summary>
    [ObservableProperty]
    private double _windowWidth = 1300;
    #endregion Properties (some with default values)
}
