using Domain.Commands.Abstracts;
using System.Threading.Tasks;

namespace Domain.Commands.Interfaces
{
    public interface IHandler
    {
        Task<TCommandResult> Incomplete<TCommandResult>(TCommandResult commandResult)
            where TCommandResult : CommandResult;
        Task<TCommandResult> Complete<TCommandResult>(TCommandResult commandResult, object data)
            where TCommandResult : CommandResult;
    }
}
