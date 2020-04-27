using Domain.Commands.Interfaces;
using Flunt.Notifications;
using Tasks = System.Threading.Tasks;

namespace Domain.Commands.Abstracts
{
    public abstract class CommandResult : Notifiable, ICommandResult
    {
        public object Data { get; set; }
    }
}
