using MimeKit;

namespace FilmPanel.FilmPanelAppService.MailService
{
    internal class MimeMessage
    {
        public MimeMessage()
        {
        }

        public MailboxAddress Sender { get; internal set; }
    }
}