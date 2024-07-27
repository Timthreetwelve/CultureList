The Culture List ReadMe file


Introduction
============
Culture List will display a subset of the culture information found in System.Globalization.CultureInfo.
I built the application to be able to quickly look up information such as date and number formats and
the correct local spelling of a language name.


Using Culture List
==================
Culture List will display a list of cultures in the grid on the left side of the window. When a culture
is selected, details for that culture are displayed in the grid on the right side of the window.

You can choose to have All cultures listed, Neutral cultures, or Specific cultures. Neutral cultures are
those that are not specific to a country or region. Specific cultures are, well, specific to a country
or region. All cultures are a combination of Neutral and Specific. The current list is displayed near
the upper right corner of the window.

You can choose to have the Display Name, the Native Name or the English Name displayed along side the
Language Code in the left grid. By default, the list is sorted by Language Code. You can change the sort
by clicking on the column header.

A note on Native Name. If the Native Name does not display correctly, try selecting a different font in
the UI Settings section of the Settings page.

A note on Number Group Separators. Some cultures use a number group separator, such as the space character,
that does lend itself to being displayed. Those group separators will be shown as "space character",
"non-breaking space character", or "narrow non-breaking space character".

You can also filter the list by entering text in the filter box directly above the list. The filter will
find text in the Language Code column and the Display Name, Native Name and English Name columns regardless
of which Name column is displayed.

Any text field in either the Culture list grid or the Details grid can be copied by simply right-clicking
on the text. 


Navigation
==========
Use the menu on the left for page navigation or to exit the application.


Settings Page
=============
The Application Settings section of the Settings page has the previously mentioned options to select which
cultures to display and which column to show in the left grid.

The UI Settings section has options that determine how the application looks. From here you can select the
application's theme, UI size, font and more.

The Language Settings section contains UI language options.


About Page
==========
Selecting About will display the About dialog which shows information about the app such as the version
number and has a link to the GitHub repository. There is also a link to this read me file. You can also
check for new releases of this application by clicking the link at the bottom of the About page. At the
bottom of the About page there is a scrollable list of the people that contributed a translation to help
make Culture List available to more users.


Three-Dot Menu
==============
The three-dot menu at the right end of the page header that has options to view the log file, open the
readme file (this file) and exit the application. There is also an option to check 


Keyboard Shortcuts
==================
These keyboard shortcuts are available:

    Ctrl + Comma = Go to Settings
    Ctrl + Numpad Plus or Ctrl + Plus = Increase size
    Ctrl + Numpad Minus or Ctrl + Minus = Decrease size
    Ctrl + Shift + C = Change the Accent Color
    Ctrl + Shift + F = Open File Explorer in the application folder
    Ctrl + Shift + R = Change row spacing
    Ctrl + Shift + S = Open the Settings file
    Ctrl + Shift + T = Change the Theme
    F1 = Go to the About screen


Uninstalling
============
To uninstall, use the regular Windows add/remove programs feature.


Notices and License
===================
Culture List was written by Tim Kennedy.

Culture List uses the following packages:

    * Material Design in XAML Toolkit https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit

    * Community Toolkit MVVM https://github.com/CommunityToolkit/dotnet

    * NLog https://nlog-project.org/

    * GitVersion https://github.com/GitTools/GitVersion

    * OctoKit https://github.com/octokit/octokit.net

    * Vanara https://github.com/dahall/vanara

    * GitKraken was used for everything Git related. https://www.gitkraken.com/

    * Inno Setup was used to create the installer. https://jrsoftware.org/isinfo.php

    * Visual Studio Community was used throughout the development of Culture List. https://visualstudio.microsoft.com/vs/community/

    * XAML Styler is indispensable when working with XAML. https://github.com/Xavalon/XamlStyler

    * JetBrains ReSharper Command Line Tools were used for code analysis. https://www.jetbrains.com/resharper/features/command-line.html

    * And of course, the essential PowerToys https://github.com/microsoft/PowerToys



MIT License
Copyright (c) 2024 Tim Kennedy

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and
associated documentation files (the "Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject
to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial
portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT
LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
