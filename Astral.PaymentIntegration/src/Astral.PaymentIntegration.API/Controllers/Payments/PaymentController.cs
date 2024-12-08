using Astral.PaymentIntegration.API.Controllers.Payments.Requests;
using Astral.PaymentIntegration.Application.Payments.CreatePayment;
using Astral.PaymentIntegration.Application.Payments.GetPayment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Astral.PaymentIntegration.API.Controllers.Payments
{
    [ApiController]
    [Route("api/payments")]
    public class PaymentController : ControllerBase
    {
        private readonly ISender _sender;

        public PaymentController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        [Route("GetPayment")]
        public async Task<IActionResult> GetPayment(string externalCode, CancellationToken cancellationToken)
        {
            var query = new GetPaymentQuery(Guid.NewGuid());
            var result = await _sender.Send(query, cancellationToken);

            return Ok(result.Value);
        }

        [HttpPost]
        [Route("CreatePayment")]
        public async Task<IActionResult> CreatePayment(CreatePaymentRequest request, CancellationToken cancellationToken)
        {
            var command = new CreatePaymentCommand(
                request.MemberId,
                request.ExternalCode,
                request.Price,
                request.Currency);

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return CreatedAtAction(nameof(CreatePayment), new { id = result.Value }, result.Value);
        }
    }
}
