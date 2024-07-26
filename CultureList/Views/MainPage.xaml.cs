// Copyright (c) Tim Kennedy. All Rights Reserved. Licensed under the MIT License.

namespace CultureList.Views;
/// <summary>
/// Interaction logic for MainPage.xaml
/// </summary>
public partial class MainPage : UserControl
{
    #region MainPage Instance
    public static MainPage? Instance { get; private set; }
    #endregion MainPage Instance

    #region Constructor
    public MainPage()
    {
        InitializeComponent();
        Instance = this;
    }
    #endregion Constructor

    #region Filter text changed
    /// <summary>
    /// Text changed event for the filter textbox
    /// </summary>
    private void TbxSearch_TextChanged(object sender, TextChangedEventArgs e)
    {
        FilterTheGrid(sender);
    }
    #endregion Filter text changed

    #region Filter the datagrid
    /// <summary>
    /// Filters the grid by showing only the rows that match the filter text.
    /// If the filter text begins with "!" the filter is inverted.
    /// </summary>
    private void FilterTheGrid(object sender)
    {
        if (sender is TextBox filterBox)
        {
            string filter = filterBox.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(CultureGrid.ItemsSource);
            if (filter.Length == 0)
            {
                cv.Filter = null;
            }
            else if (filter.StartsWith('!'))
            {
                filter = filter[1..].TrimStart(' ');
                cv.Filter = o =>
                {
                    CultureInfo? cu = o as CultureInfo;
                    return !cu!.Name.Contains(filter, StringComparison.OrdinalIgnoreCase) &&
                           !cu.NativeName.Contains(filter, StringComparison.OrdinalIgnoreCase) &&
                           !cu.DisplayName.Contains(filter, StringComparison.OrdinalIgnoreCase);
                };
            }
            else
            {
                cv.Filter = o =>
                {
                    CultureInfo? cu = o as CultureInfo;
                    return cu!.Name.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
                           cu.NativeName.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
                           cu.DisplayName.Contains(filter, StringComparison.OrdinalIgnoreCase);
                };
            }

            if (CultureGrid.Items.Count == 1)
            {
                SnackbarMsg.ClearAndQueueMessage(GetStringResource("MsgText_FilterOneRowShown"), 2000);
            }
            else
            {
                SnackbarMsg.ClearAndQueueMessage(string.Format(
                    GetStringResource("MsgText_FilterRowsShown"), CultureGrid.Items.Count), 2000);
            }
        }
    }
    #endregion Filter the datagrid
}
