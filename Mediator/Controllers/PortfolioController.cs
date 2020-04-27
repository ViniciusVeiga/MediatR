using Domain.Commands.Input;
using Domain.Repositories;
using MediatR;
using MeuPortfolio.PortfolioManagement.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Mediator.Controllers
{
    [ApiController]
    public class PortfolioController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IPortfolioRepository _portfolioRepository;

        public PortfolioController(
            IMediator mediator,
            IPortfolioRepository portfolioRepository)
        {
            _mediator = mediator;
            _portfolioRepository = portfolioRepository;
        }

        [HttpGet]
        [Route("v1/portfolios")]
        public IActionResult Get()
        {
            return Ok(_portfolioRepository.GetPortfolios());
        }

        [HttpPost]
        [Route("v1/portfolios")]
        public async Task<IActionResult> PostAsync([FromBody]CreatePortfolioCommand command)
        {
            var commandResult = await _mediator.Send(command);
            return Response(commandResult);
        }
    }
}
