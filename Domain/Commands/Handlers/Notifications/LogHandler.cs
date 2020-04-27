using Domain.Commands.Input.Notifications;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Commands.Handlers.Notifications
{
    public class LogHandler : INotificationHandler<LogCommand>
    {
        public Task Handle(LogCommand command, CancellationToken cancellationToken)
        {
            var task = Task.Run(() =>
            {
                foreach (var notification in command.Notifications)
                    Console.WriteLine(notification.Message);
            });

            return task;
        }
    }
}
