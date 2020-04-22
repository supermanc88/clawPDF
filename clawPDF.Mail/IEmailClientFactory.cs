namespace infosecSoft.infosecPDF.Mail
{
    public interface IEmailClientFactory
    {
        IEmailClient CreateEmailClient();
    }
}