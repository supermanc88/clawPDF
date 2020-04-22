using infosecSoft.infosecPDF.Core.Settings;

namespace infosecSoft.infosecPDF.Shared.Helper
{
    public static class MailSignatureHelper
    {
        public static string ComposeMailSignature(EmailClient mailSettings)
        {
            return ComposeMailSignature(mailSettings.AddSignature);
        }

        public static string ComposeMailSignature(EmailSmtp mailSettings)
        {
            return ComposeMailSignature(mailSettings.AddSignature);
        }

        public static string ComposeMailSignature(bool addSignature = true)
        {
            return "";
        }
    }
}