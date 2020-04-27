using Domain.Commands.Interfaces;
using Flunt.Notifications;
using MediatR;
using System;

namespace Domain.Commands.Abstracts
{
    public abstract class Command<TCommandResult> : Notifiable, ICommand, IRequest<TCommandResult>
        where TCommandResult : ICommandResult
    {
        public virtual TCommandResult Result() => Activator.CreateInstance<TCommandResult>();
    }
}
