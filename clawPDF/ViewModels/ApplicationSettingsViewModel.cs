﻿using System;
using infosecSoft.infosecPDF.Core.Settings;
using infosecSoft.infosecPDF.Shared.ViewModels;

namespace infosecSoft.infosecPDF.ViewModels
{
    internal class ApplicationSettingsViewModel : ViewModelBase
    {
        private ApplicationSettings _applicationSettings;
        public EventHandler SettingsChanged;

        public ApplicationSettings ApplicationSettings
        {
            get => _applicationSettings;
            set
            {
                _applicationSettings = value;
                OnSettingsChanged(new EventArgs());
            }
        }

        public bool TitleTabIsEnabled => true;

        public bool DebugTabIsEnabled => true;

        public bool PrinterTabIsEnabled => true;

        protected virtual void OnSettingsChanged(EventArgs e)
        {
            RaisePropertyChanged(nameof(ApplicationSettings));
            RaiseGpoPropertiesChanged();

            if (SettingsChanged != null)
                SettingsChanged(this, e);
        }

        private void RaiseGpoPropertiesChanged()
        {
            RaisePropertyChanged(nameof(TitleTabIsEnabled));
            RaisePropertyChanged(nameof(DebugTabIsEnabled));
            RaisePropertyChanged(nameof(PrinterTabIsEnabled));
        }
    }
}