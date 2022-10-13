using RLPortalBackend.Container.Messages;

namespace RLPortalBackend.Services
{
    public interface IEmailSenderService
    {
        public Task SendEmail(MessageToSend data);
    }
}
