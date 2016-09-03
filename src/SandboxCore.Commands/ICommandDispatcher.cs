using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SandboxCore.Commands
{
    public interface ICommandDispatcher
    {
        Task<CommandResult> Dispatch<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
