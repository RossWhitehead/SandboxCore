using System.Threading.Tasks;

namespace SandboxCore.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task<CommandResult> Execute(TCommand command);
    }
}