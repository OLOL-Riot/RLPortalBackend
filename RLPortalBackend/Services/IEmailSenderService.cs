using RLPortal.Container.Messages;

namespace RLPortal.Services
{
    public interface IEmailSenderService
    {
        public Task SendEmail(MessageToSend data);
    }
}
