using OzelDers.Web.EMailServices.Abstract;

namespace OzelDers.Web.EMailServices.Concrete
{
    public class Pop3EmailSender :IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            throw new NotImplementedException();
        }
    }
}
