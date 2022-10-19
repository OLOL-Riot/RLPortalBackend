using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RLPortalBackend.Container.Messages;
using RLPortalBackend.Services;

namespace RLPortalBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailSenderController : Controller
    {
        private readonly IEmailSenderService _emailSenderService;

        public EmailSenderController(IEmailSenderService emailSenderService)
        {
            _emailSenderService = emailSenderService;
        }

        /// <summary>
        /// Sendig email
        /// </summary>
        /// <param name="data"></param>
        [HttpPost, Authorize(Roles = "Administrator")]
        public void SendEmail(MessageToSend data)
        {
            _emailSenderService.SendEmail(data);
        }

    }
}
