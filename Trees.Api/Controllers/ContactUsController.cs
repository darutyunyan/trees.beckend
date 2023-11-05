using Microsoft.AspNetCore.Mvc;
using Trees.Api.Models.Dto.ContactUs;
using Trees.Api.Services.Mail;

namespace Trees.Api.Controllers
{
    public class ContactUsController : BaseController
    {
        public ContactUsController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost]
        [Route("Feedback")]
        public async Task<ActionResult> Feedback(FeedbackDto dto)
        {
            string subject = "test";

            string message = $"Имя: {dto.Name}<br>Телефон: {dto.Phone}<br>Почта: {dto.Email}<p>Сообщение: {dto.Message}</p>"; // todo

            await _mailService.Send(subject, message);

            return Ok();
        }

        [HttpPost]
        [Route("ShortFeedback")]
        public async Task<ActionResult> ShortFeedback(ShortFeedbackDto dto)
        {
            string subject = "test short";

            string message = $"Имя: {dto.Name}<br>Телефон: {dto.Phone}"; // todo

            await _mailService.Send(subject, message);

            return Ok();
        }

        private readonly IMailService _mailService;
    }
}
