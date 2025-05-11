using ChannelService.Application.TariffPayments.Commands.CreateTariffPayment;
using ChannelService.Application.TariffPayments.Commands.DeleteTariffPayment;
using ChannelService.Application.TariffPayments.Queries.GetTariffPayment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChannelService.WebApi.Controllers
{
    public class TariffPaymentsController(IMediator mediator) : BaseController(mediator)
    {
        [HttpPost]
        public async Task<IActionResult> Create(CancellationToken cancellationToken)
        {
            var command = new CreateTariffPaymentCommand { ChannelId = AccountId };
            await Mediator.Send(command, cancellationToken);
            return Created();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(CancellationToken cancellationToken)
        {
            var command = new DeleteTariffPaymentCommand { ChannelId = AccountId };
            await Mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<TariffPaymentVm>> Get(CancellationToken cancellationToken)
        {
            var query = new GetTariffPaymentQuery { ChannelId = AccountId };
            var payment = await Mediator.Send(query, cancellationToken);
            return Ok(payment);
        }
    }
}
