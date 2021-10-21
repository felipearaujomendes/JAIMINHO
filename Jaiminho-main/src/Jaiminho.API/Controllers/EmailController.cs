using Microsoft.AspNetCore.Mvc;
using Jaiminho.API.Services;
using Jaiminho.API.ViewModels;
using System.Threading.Tasks;

namespace Jaiminho.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> SendAsync(EmailViewModel emailViewModel)
        {
           var retorno = await _emailService.SendMailAsync(emailViewModel);

            if (!retorno) return BadRequest();
            return Ok();
        }

    }
}
