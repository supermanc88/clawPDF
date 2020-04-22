using infosecSoft.infosecPDF.Helper;

namespace infosecSoft.infosecPDF.Startup
{
    internal class InitializeSettingsStart : IAppStart
    {
        public bool Run()
        {
            SettingsHelper.SaveSettings();

            return true;
        }
    }
}