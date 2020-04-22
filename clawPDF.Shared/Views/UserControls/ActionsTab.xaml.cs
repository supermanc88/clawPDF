using System.Windows.Controls;
using infosecSoft.infosecPDF.Shared.Helper;
using infosecSoft.infosecPDF.Shared.ViewModels.UserControls;

namespace infosecSoft.infosecPDF.Shared.Views.UserControls
{
    public partial class ActionsTab : UserControl
    {
        public ActionsTab()
        {
            InitializeComponent();
            if (TranslationHelper.Instance.IsInitialized) TranslationHelper.Instance.TranslatorInstance.Translate(this);
        }

        public ActionsTabViewModel ViewModel => (ActionsTabViewModel)DataContext;
    }
}