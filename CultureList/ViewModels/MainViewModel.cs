// Copyright (c) Tim Kennedy. All Rights Reserved. Licensed under the MIT License.

namespace CultureList.ViewModels;

/// <summary>
/// ViewModel for the MainPage class.
/// </summary>
internal sealed class MainViewModel
{
    #region Constructor
    public MainViewModel()
    {
        if (Cultures is null)
        {
            LoadData();
        }
    }
    #endregion Constructor

    #region Populate the collection with Culture Information
    /// <summary>
    /// Loads the culture info into the collection depending on which CultureTypes is set.
    /// </summary>
    internal static void LoadData()
    {
        CultureTypes types = CheckCultureType(UserSettings.Setting!.SelectedCultures);
        Cultures = new List<CultureInfo>([.. CultureInfo.GetCultures(types).OrderBy(static x => x.Name)]);
        if (MainPage.Instance != null)
        {
            MainPage.Instance.CultureGrid.ItemsSource = Cultures;
        }
        _log.Debug($"Loaded {Cultures.Count} {UserSettings.Setting.SelectedCultures} items.");
    }
    #endregion Populate the collection with Culture Information

    #region Collection of Culture Information
    public static List<CultureInfo>? Cultures { get; private set; }
    #endregion Collection of Culture Information

    #region Verify culture type
    /// <summary>
    /// Several of the values in the CultureTypes enum are marked deprecated or obsolete.
    /// This will verify that the selected culture type is indeed a valid value.
    /// </summary>
    /// <param name="culture">The culture type value from settings</param>
    /// <returns>A valid CultureTypes enum.</returns>
    private static CultureTypes CheckCultureType(Cultures culture)
    {
        switch (culture)
        {
            case Models.Cultures.SpecificCultures:
            case Models.Cultures.NeutralCultures:
            case Models.Cultures.AllCultures:
                return (CultureTypes)culture;
            default:
                UserSettings.Setting!.SelectedCultures = (Cultures)CultureTypes.AllCultures;
                return CultureTypes.AllCultures;
        }
    }
    #endregion Verify culture type
}
