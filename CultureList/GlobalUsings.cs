// Copyright (c) Tim Kennedy. All Rights Reserved. Licensed under the MIT License.

global using System;
global using System.Collections.Generic;
global using System.ComponentModel;
global using System.Diagnostics;
global using System.Globalization;
global using System.IO;
global using System.Linq;
global using System.Reflection;
global using System.Runtime.InteropServices;
global using System.Runtime.Versioning;
global using System.Security.Principal;
global using System.Text;
global using System.Text.Json;
global using System.Threading;
global using System.Threading.Tasks;
global using System.Windows;
global using System.Windows.Controls;
global using System.Windows.Data;
global using System.Windows.Input;
global using System.Windows.Media;
global using System.Windows.Markup;

global using CommunityToolkit.Mvvm.ComponentModel;
global using CommunityToolkit.Mvvm.Input;

global using MaterialDesignColors;
global using MaterialDesignThemes.Wpf;

global using NLog;
global using NLog.Config;
global using NLog.Targets;

global using CultureList.Configuration;
global using CultureList.Constants;
global using CultureList.Converters;
global using CultureList.Dialogs;
global using CultureList.Helpers;
global using CultureList.Models;
global using CultureList.Views;

global using static CultureList.Helpers.NLogHelpers;
global using static CultureList.Helpers.ResourceHelpers;
