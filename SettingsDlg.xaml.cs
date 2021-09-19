﻿using Microsoft.Graphics.Canvas.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Rich_Text_Editor
{
    public sealed partial class SettingsDlg : ContentDialog
    {
        RichEditBox targetEditor;
        ComboBox fontsCombo;
        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        public SettingsDlg(RichEditBox targetEditor, ComboBox fontsCombo)
        {
            InitializeComponent();
            this.targetEditor = targetEditor;
            this.fontsCombo = fontsCombo;

            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            string fontSetting = localSettings.Values["FontFamily"] as string;
            if (fontSetting != null) FontsCombo.SelectedItem = fontSetting;
            if ((string)localSettings.Values["TextWrapping"] == "enabled")
            {
                textWrappingSwitch.IsOn = true;
            }
            else
            {
                textWrappingSwitch.IsOn = true;
            }

        }

        private void okBtn11_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        public List<string> Fonts
        {
            get
            {
                return CanvasTextFormat.GetSystemFontFamilies().OrderBy(f => f).ToList();
            }
        }

        private void FontsCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fontsCombo.SelectedItem = FontsCombo.SelectedValue.ToString();
            localSettings.Values["FontFamily"] = FontsCombo.SelectedValue.ToString();
        }

        private void ToggleSwitchTextWrap_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch aSwitch = (ToggleSwitch)sender;
            if (aSwitch.IsOn)
            {
                localSettings.Values["TextWrapping"] = "enabled";
            }
            else
            {
                localSettings.Values["TextWrapping"] = "disabled";
            }
        }
    }
}
