using System;
using System.Collections.Generic;
using infosecSoft.infosecPDF.Core.Settings.Enums;
using infosecSoft.infosecPDF.Shared.Helper;
using pdfforge.DynamicTranslator;

namespace infosecSoft.infosecPDF.ViewModels.UserControls
{
    internal class DebugTabViewModel : ApplicationSettingsViewModel
    {
        public IEnumerable<EnumValue<LoggingLevel>> LoggingValues =>
            TranslationHelper.Instance.TranslatorInstance.GetEnumTranslation<LoggingLevel>();

        public bool ProfileManagementIsEnabled => true;

        protected override void OnSettingsChanged(EventArgs e)
        {
            base.OnSettingsChanged(e);

            RaisePropertyChanged("ProfileManagementIsEnabled");
        }
    }
}