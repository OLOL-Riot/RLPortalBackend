using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RLPortalBackend.Container.Messages;
using RLPortalBackend.Services;

namespace RLPortalBackend.Controllers
{
    /// <summary>
    /// EmailSenderController
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EmailSenderController : Controller
    {
        private readonly IEmailSenderService _emailSenderService;

        /// <summary>
        /// EmailSenderController constructor
        /// </summary>
        /// <param name="emailSenderService"></param>
        public EmailSenderController(IEmailSenderService emailSenderService)
        {
            _emailSenderService = emailSenderService;
        }

        /// <summary>
        /// Send a message with email 
        /// (Permissions: Administrator)
        /// </summary>
        /// <param name="data"></param>
        [HttpPost, Authorize(Roles = "Administrator")]
        public void SendEmail(MessageToSend data)
        {
            _emailSenderService.SendEmail(data);
        }

    }
}
