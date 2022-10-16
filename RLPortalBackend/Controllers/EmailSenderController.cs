using RLPortalBackend.Container.Messages;
using RLPortalBackend.Services;
using RLPortalBackend.Services.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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
        [HttpPost]
        public void SendEmail(MessageToSend data)
        {
            _emailSenderService.SendEmail(data);   
        }

    }
}
