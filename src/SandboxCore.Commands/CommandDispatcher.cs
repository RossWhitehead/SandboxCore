using System;
using System.Threading.Tasks;

namespace SandboxCore.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
           this.serviceProvider = serviceProvider;
        }

        public async Task<CommandResult> Dispatch<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = (ICommandHandler<TCommand>)this.serviceProvider.GetService(typeof(ICommandHandler<TCommand>));
            return await handler.Execute(command);
        }
    }
}