using Flunt.Notifications;
using MediatR;
using System.Collections.Generic;

namespace Domain.Commands.Input.Notifications
{
    public class LogCommand : Notifiable, INotification
    {
        public LogCommand(IReadOnlyCollection<Notification> notifications) => AddNotifications(notifications);
    }
}
