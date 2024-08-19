// Copyright (c) Tim Kennedy. All Rights Reserved. Licensed under the MIT License.

namespace CultureList.ViewModels;

internal sealed partial class NavigationViewModel : ObservableObject
{
    #region Constructor
    public NavigationViewModel()
    {
        if (CurrentViewModel == null)
        {
            NavigateToPage(NavPage.MainPage);
        }
    }
    #endregion Constructor

    #region MainWindow Instance
    private static readonly MainWindow? _mainWindow = Application.Current.MainWindow as MainWindow;
    #endregion MainWindow Instance

    #region Properties
    [ObservableProperty]
    private object? _currentViewModel;

    [ObservableProperty]
    private string? _pageTitle;

    [ObservableProperty]
    private static NavigationItem? _navItem;
    #endregion Properties

    #region List of navigation items
    public static List<NavigationItem> NavigationViewModelTypes { get; } =
    [
        new() {
            Name=GetStringResource("NavItem_CultureList"),
            NavPage = NavPage.MainPage,
            ViewModelType= typeof(MainViewModel),
            IconKind=PackIconKind.Globe,
            PageTitle=GetStringResource("NavTitle_CultureList")
        },
        new() {
            Name = GetStringResource("NavItem_Settings"),
            NavPage=NavPage.Settings,
            ViewModelType= typeof(SettingsViewModel),
            IconKind=PackIconKind.SettingsOutline,
            PageTitle = GetStringResource("NavTitle_Settings")
        },
        new() {
            Name = GetStringResource("NavItem_About"),
            NavPage=NavPage.About,
            ViewModelType= typeof(AboutViewModel),
            IconKind=PackIconKind.AboutCircleOutline,
            PageTitle = GetStringResource("NavTitle_About")
        },
        new() {
            Name = GetStringResource("NavItem_Exit"),
            IconKind=PackIconKind.ExitToApp,
            IsExit=true
        }
    ];
    #endregion List of navigation items

    #region Navigation Methods
    private void NavigateToPage(NavPage page)
    {
        Navigate(FindNavPage(page));
    }

    private static NavigationItem FindNavPage(NavPage page)
    {
        return NavigationViewModelTypes.Find(x => x.NavPage == page)!;
    }
    #endregion Navigation Methods

    #region Navigate Command
    [RelayCommand]
    private void Navigate(object param)
    {
        if (param is NavigationItem item)
        {
            if (item.IsExit == true)
            {
                Application.Current.Shutdown();
            }
            else if (item.ViewModelType is not null)
            {
                PageTitle = item.PageTitle;
                CurrentViewModel = null;
                CurrentViewModel = Activator.CreateInstance((Type)item.ViewModelType);
                NavItem = item;
            }
        }
    }
    #endregion Navigate Command

    #region View log file command
    [RelayCommand]
    private static void ViewLogFile()
    {
        TextFileViewer.ViewTextFile(NLogHelpers.GetLogfileName());
    }
    #endregion View log file command

    #region View readme file command
    [RelayCommand]
    private static void ViewReadMeFile()
    {
        TextFileViewer.ViewTextFile(Path.Combine(AppInfo.AppDirectory, "readme.txt"));
    }
    #endregion View readme file command

    #region Open the application folder
    [RelayCommand]
    private static void OpenAppFolder()
    {
        using Process process = new();
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.FileName = "Explorer.exe";
        process.StartInfo.Arguments = AppInfo.AppDirectory;
        _ = process.Start();
    }
    #endregion Open the application folder

    #region Check for new release
    [RelayCommand]
    private static async Task CheckReleaseAsync()
    {
        await GitHubHelpers.CheckRelease();
    }
    #endregion Check for new release

    #region Right mouse button
    /// <summary>
    /// Copy (nearly) any text in a TextBlock to the clipboard on right mouse button up.
    /// </summary>
    [RelayCommand]
    private static void RightMouseUp(MouseButtonEventArgs e)
    {
        if (e.OriginalSource is TextBlock text)
        {
            try
            {
                // Skip the navigation menu
                ListBox lb = MainWindowHelpers.FindParent<ListBox>(text);
                if (lb?.Name == "NavigationListBox")
                {
                    return;
                }

                // Copy to clipboard and display message.
                if (ClipboardHelper.CopyTextToClipboard(text.Text))
                {
                    SnackbarMsg.ClearAndQueueMessage(GetStringResource("MsgText_CopiedToClipboardItem"));
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex, $"Right-click event handler failed. {ex.Message}");
            }
        }
    }
    #endregion Right mouse button

    #region Key down events
    /// <summary>
    /// Keyboard events
    /// </summary>
    [RelayCommand]
    private static void KeyDown(KeyEventArgs e)
    {
        #region Keys without modifiers
        switch (e.Key)
        {
            case Key.F1:
                {
                    _mainWindow!.NavigationListBox.SelectedValue = FindNavPage(NavPage.About);
                    break;
                }
        }

        #endregion Keys without modifiers

        #region Keys with Ctrl
        if (e.KeyboardDevice.Modifiers == ModifierKeys.Control)
        {
            switch (e.Key)
            {
                case Key.OemComma:
                    {
                        _mainWindow!.NavigationListBox.SelectedValue = FindNavPage(NavPage.Settings);
                        break;
                    }

                case Key.Add:
                case Key.OemPlus:
                    {
                        MainWindowHelpers.EverythingLarger();
                        CompositeFormat format = CompositeFormat.Parse(GetStringResource("MsgText_UISizeSet"));
                        string size = EnumHelpers.GetEnumDescription(UserSettings.Setting!.UISize);
                        string message = string.Format(CultureInfo.InvariantCulture, format, size);
                        SnackbarMsg.ClearAndQueueMessage(message, 2000);
                        break;
                    }
                case Key.Subtract:
                case Key.OemMinus:
                    {
                        MainWindowHelpers.EverythingSmaller();
                        CompositeFormat format = CompositeFormat.Parse(GetStringResource("MsgText_UISizeSet"));
                        string size = EnumHelpers.GetEnumDescription(UserSettings.Setting!.UISize);
                        string message = string.Format(CultureInfo.InvariantCulture, format, size);
                        SnackbarMsg.ClearAndQueueMessage(message, 2000);
                        break;
                    }
            }
        }
        #endregion Keys with Ctrl

        #region Keys with Ctrl and Shift
        if (e.KeyboardDevice.Modifiers == (ModifierKeys.Control | ModifierKeys.Shift))
        {
            if (e.Key == Key.T)
            {
                switch (UserSettings.Setting!.UITheme)
                {
                    case ThemeType.Light:
                        UserSettings.Setting.UITheme = ThemeType.Dark;
                        break;
                    case ThemeType.Dark:
                        UserSettings.Setting.UITheme = ThemeType.Darker;
                        break;
                    case ThemeType.Darker:
                        UserSettings.Setting.UITheme = ThemeType.System;
                        break;
                    case ThemeType.System:
                        UserSettings.Setting.UITheme = ThemeType.Light;
                        break;
                }
                string theme = EnumHelpers.GetEnumDescription(UserSettings.Setting.UITheme);
                CompositeFormat format = CompositeFormat.Parse(GetStringResource("MsgText_UIThemeSet"));
                string message = string.Format(CultureInfo.InvariantCulture, format, theme);
                SnackbarMsg.ClearAndQueueMessage(message, 2000);
            }
            if (e.Key == Key.C)
            {
                if (UserSettings.Setting!.PrimaryColor >= AccentColor.White)
                {
                    UserSettings.Setting.PrimaryColor = AccentColor.Red;
                }
                else
                {
                    UserSettings.Setting.PrimaryColor++;
                }
                string color = EnumHelpers.GetEnumDescription(UserSettings.Setting.PrimaryColor);
                CompositeFormat format = CompositeFormat.Parse(GetStringResource("MsgText_UIThemeSet"));
                string message = string.Format(CultureInfo.InvariantCulture, format, color);
                SnackbarMsg.ClearAndQueueMessage(message, 2000);
            }
            if (e.Key == Key.F)
            {
                using Process p = new();
                p.StartInfo.FileName = AppInfo.AppDirectory;
                p.StartInfo.UseShellExecute = true;
                p.StartInfo.ErrorDialog = false;
                _ = p.Start();
            }
            if (e.Key == Key.R)
            {
                if (UserSettings.Setting?.RowSpacing >= Spacing.Wide)
                {
                    UserSettings.Setting.RowSpacing = Spacing.Compact;
                }
                else
                {
                    UserSettings.Setting!.RowSpacing++;
                }
            }
            if (e.Key == Key.S)
            {
                TextFileViewer.ViewTextFile(ConfigHelpers.SettingsFileName!);
            }
        }
        #endregion Keys with Ctrl and Shift
    }
    #endregion Key down events
}
