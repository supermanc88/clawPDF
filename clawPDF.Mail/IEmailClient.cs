namespace infosecSoft.infosecPDF.Mail
{
    public interface IEmailClient
    {
        bool IsClientInstalled { get; }

        bool ShowEmailClient(Email email);
    }
}