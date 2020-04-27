using Domain.Commands.Abstracts;
using Domain.Commands.Input;
using Domain.Commands.Output;
using Domain.Entity;
using Domain.Provider;
using Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Commands.Handlers
{
    public class PortfolioHandler :
        Handler,
        IRequestHandler<CreatePortfolioCommand, CreatePortfolioCommandResult>
    {
        private readonly TenantProvider _tenantProvider;
        private readonly IPortfolioRepository _portfolioRepository;

        public PortfolioHandler(
            TenantProvider tenantProvider,
            IPortfolioRepository portfolioRepository,
            IMediator mediator) : base(mediator)
        {
            _tenantProvider = tenantProvider;
            _portfolioRepository = portfolioRepository;
        }

        public Task<CreatePortfolioCommandResult> Handle(CreatePortfolioCommand command, CancellationToken cancellationToken)
        {
            var commandResult = command.Result();
            if (!command.Validate())
            {
                commandResult.AddNotifications(command.Notifications);
                return Incomplete(commandResult);
            }

            if (_portfolioRepository.CheckNameExists(command.Name))
            {
                commandResult.AddNotification(nameof(Portfolio), $"Já existe Portfolio com esse nome ({command.Name})");
                return Incomplete(commandResult);
            }

            var portfolio = new Portfolio(command.Name, _tenantProvider.GetTenantId());
            commandResult.AddNotifications(portfolio.Notifications);
            if (commandResult.Invalid) return Incomplete(commandResult);

            _portfolioRepository.Add(portfolio);

            commandResult.Id = portfolio.Id;
            return Complete(commandResult, _portfolioRepository.GetPortfolio(portfolio.Id));
        }
    }
}
