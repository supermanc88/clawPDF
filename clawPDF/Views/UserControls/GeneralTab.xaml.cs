﻿using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;
using infosecSoft.infosecPDF.Shared.Helper;
using infosecSoft.infosecPDF.Utilities;
using infosecSoft.infosecPDF.Helper;
using infosecSoft.infosecPDF.ViewModels.UserControls;
using pdfforge.DynamicTranslator;

namespace infosecSoft.infosecPDF.Views.UserControls
{
    internal partial class GeneralTab
    {
        private static readonly TranslationHelper TranslationHelper = TranslationHelper.Instance;

        public GeneralTab()
        {
            InitializeComponent();
            if (TranslationHelper.IsInitialized) TranslationHelper.TranslatorInstance.Translate(this);
        }

        public Action PreviewLanguageAction { private get; set; }

        public GeneralTabViewModel ViewModel => (GeneralTabViewModel)DataContext;

        public Visibility RequiresUacVisibility =>
            new OsHelper().UserIsAdministrator() ? Visibility.Collapsed : Visibility.Visible;

        private void LanguagePreviewButton_Click(object sender, RoutedEventArgs e)
        {
            TranslationHelper.Instance.SetTemporaryTranslation((Language)LanguageBox.SelectionBoxItem);
            TranslationHelper.Instance.TranslatorInstance.Translate(this);
            TranslationHelper.Instance.TranslateProfileList(SettingsHelper.Settings.ConversionProfiles);
            //overwrite items of comboboxes with translated items
            ChangeDefaultPrinterComboBox.ItemsSource = ViewModel.AskSwitchPrinterValues;
            ChangeDefaultPrinterComboBox.SelectedValue = ViewModel.ApplicationSettings.AskSwitchDefaultPrinter;
            PreviewLanguageAction();
        }

        private void DownloadHyperlink_OnRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(Urls.clawSoftWebsiteUrl);
            e.Handled = true;
        }
    }
}