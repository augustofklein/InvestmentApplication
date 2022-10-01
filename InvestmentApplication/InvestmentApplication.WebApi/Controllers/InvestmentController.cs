using InvestmentApplication.WebApi.Models.Investment;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace InvestmentApplication.WebApi.Controllers
{
    [ApiController]
    public class InvestmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InvestmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateInvestment(CreateInvestmentInputModel inputModel, CancellationToken cancellationToken)
        {
            var command = inputModel.CreateCommand();
            if(command.IsFailure)
                return BadRequest(command.Error);

            var response = await _mediator.Send(command.Value, cancellationToken);
            if (response.IsFailure)
                return BadRequest(response.Error);

            return Ok(response.IsSuccess);
        }
    }
}
