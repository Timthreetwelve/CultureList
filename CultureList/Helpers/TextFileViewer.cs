// Copyright (c) Tim Kennedy. All Rights Reserved. Licensed under the MIT License.

// Comment out the following if MessageBox is not to be used
#define messagebox

namespace CultureList.Helpers;

/// <summary>
///  Class for viewing text files. If the file extension is not associated
///  with an application, notepad.exe will be attempted.
/// </summary>
public static class TextFileViewer
{
    #region Text file viewer
    public static void ViewTextFile(string textFile)
    {
        string fname = string.Empty;
        try
        {
            fname = PathHelpers.AnonymizePath(textFile);

            using Process p = new();
            p.StartInfo.FileName = $"\"{textFile}\"";
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.ErrorDialog = false;
            _ = p.Start();
            _log.Debug($"Opening {fname}");
        }
        catch (Win32Exception ex)
        {
            int ERROR_NO_ASSOCIATION = 1155;
            if (ex.NativeErrorCode == ERROR_NO_ASSOCIATION)
            {
                string notepadPath = string.Empty;
                string system32 = Environment.GetFolderPath(Environment.SpecialFolder.System);
                string windir = Environment.GetEnvironmentVariable("windir") ?? "C:\\Windows";

                if (File.Exists(Path.Combine(system32, "notepad.exe")))
                {
                    notepadPath = Path.Combine(system32, "notepad.exe");
                }
                else if (File.Exists(Path.Combine(windir, "notepad.exe")))
                {
                    notepadPath = Path.Combine(windir, "notepad.exe");
                }
                else
                {
                    _log.Error($"Unable to find notepad.exe in {system32} or {windir}");
#if messagebox
                    CompositeFormat format = CompositeFormat.Parse(GetStringResource("MsgText_ErrorOpeningFile"));
                    string msg = string.Format(CultureInfo.InvariantCulture, format, textFile);
                    _ = MessageBox.Show($"{msg}\n\nUnable to find notepad.exe in {system32} or {windir}",
                                        GetStringResource("MsgText_Error_Caption"),
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Error);
#endif
                    return;
                }
                using Process p = new();
                p.StartInfo.FileName = notepadPath;
                p.StartInfo.Arguments = $"\"{textFile}\"";
                p.StartInfo.UseShellExecute = true;
                p.StartInfo.ErrorDialog = false;
                _ = p.Start();
                _log.Debug($"Opening {fname} in Notepad.exe");
            }
            else
            {
#if messagebox
                _log.Error(ex, $"Unable to open {fname}");
                CompositeFormat format = CompositeFormat.Parse(GetStringResource("MsgText_ErrorOpeningFile"));
                string msg = string.Format(CultureInfo.InvariantCulture, format, textFile);
                _ = MessageBox.Show($"{msg}\n{ex.Message}",
                                    GetStringResource("MsgText_ErrorCaption"),
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
#endif
            }
        }
        catch (Exception ex)
        {
#if messagebox
            _log.Error($"Unable to open {fname}. {ex.Message} ");
            CompositeFormat format = CompositeFormat.Parse(GetStringResource("MsgText_ErrorOpeningFile"));
            string msg = string.Format(CultureInfo.InvariantCulture, format, textFile);
            _ = MessageBox.Show($"{msg}\n{ex.Message}",
                                GetStringResource("MsgText_ErrorCaption"),
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
#endif
        }
    }
    #endregion Text file viewer
}
