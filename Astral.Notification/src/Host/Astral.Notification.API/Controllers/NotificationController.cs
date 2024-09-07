using Astral.Notification.Application.ApplicationQueries.NotificationQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Astral.Notification.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public NotificationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetNotificationAsync()
        {
            var a = await _mediator.Send(new GetNotificationQuery());

            return Ok(a);
        }
    }
}
