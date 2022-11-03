using RLPortalBackend.Container.Messages;

namespace RLPortalBackend.Services
{
    /// <summary>
    /// Email service
    /// </summary>
    public interface IEmailSenderService
    {
        /// <summary>
        /// Send mail
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task SendEmail(MessageToSend data);
    }
}
