namespace OzelDers.Web.EMailServices.Abstract
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
