using System;
using infosecSoft.infosecPDF.Core.Settings;
using infosecSoft.infosecPDF.Shared.ViewModels;

namespace infosecSoft.infosecPDF.Shared.ViewModels.UserControls
{
    public class CurrentProfileViewModel : ViewModelBase
    {
        private ConversionProfile _currentProfile;

        public ConversionProfile CurrentProfile
        {
            get => _currentProfile;
            set
            {
                _currentProfile = value;
                OnProfileChanged(new EventArgs());
            }
        }

        public event EventHandler ProfileChanged;

        protected virtual void OnProfileChanged(EventArgs e)
        {
            RaisePropertyChanged("CurrentProfile");
            var handler = ProfileChanged;
            if (handler != null) handler(this, e);
        }

        public void RaiseCurrentProfileChanged()
        {
            OnProfileChanged(new EventArgs());
        }
    }
}