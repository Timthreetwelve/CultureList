// Copyright (c) Tim Kennedy. All Rights Reserved. Licensed under the MIT License.

namespace CultureList.ViewModels;

/// <summary>
/// ViewModel for the MainPage class.
/// </summary>
internal sealed class MainViewModel
{
    #region Populate the collection with Culture Information
    /// <summary>
    /// Loads the culture info into the collection depending on which CultureTypes is set.
    /// </summary>
    private static List<CultureInfo> LoadData()
    {
        CultureTypes types = CheckCultureType(UserSettings.Setting!.SelectedCultures);
        List<CultureInfo> infos = [.. CultureInfo.GetCultures(types).OrderBy(x => x.Name)];
        _log.Debug($"Loaded {infos.Count} {UserSettings.Setting.SelectedCultures} items.");
        return infos;
    }
    #endregion Populate the collection with Culture Information

    #region Collection of Culture Information
    private static List<CultureInfo>? _cultures;

    /// <summary>
    /// Static List of culture information.
    /// </summary>
    public static List<CultureInfo> Cultures
    {
        get
        {
            _cultures = new List<CultureInfo>(LoadData());
            return _cultures;
        }
    }
    #endregion Collection of Culture Information

    #region Get additional details for the selected culture
    [RelayCommand]
    private static void GetDetail(CultureInfo cu) => MainPage.Instance!.DetailsGrid.ItemsSource = DetailsHelper.GetDetails(cu);
    #endregion Get additional details for the selected culture

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
