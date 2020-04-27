using Domain.Commands.Input.Notifications;
using Domain.Commands.Interfaces;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Domain.Commands.Abstracts
{
    public abstract class Handler : IHandler
    {
        protected readonly IMediator _mediator;

        public Handler(IMediator mediator) => _mediator = mediator;

        public Task<TCommandResult> Complete<TCommandResult>(TCommandResult commandResult, object data)
            where TCommandResult : CommandResult
        {
            commandResult.Data = data;
            return Task.FromResult(commandResult); 
        }

        public Task<TCommandResult> Incomplete<TCommandResult>(TCommandResult commandResult)
            where TCommandResult : CommandResult
        {
            _mediator.Publish(new LogCommand(commandResult.Notifications));
            return Task.FromResult(commandResult);
        }
    }
}
