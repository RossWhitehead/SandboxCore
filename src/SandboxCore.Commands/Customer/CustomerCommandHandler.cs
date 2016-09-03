using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SandboxCore.Commands;
using SandboxCore.Commands.Customer;
using SandboxCore.Data;

namespace SandboxCore.Command.Customer
{
    public class CustomerCommandHandler :
        ICommandHandler<AddCustomer>,
        ICommandHandler<ModifyCustomer>,
        ICommandHandler<RemoveCustomer>
    {
        private SandboxCoreDbContext db;

        public CustomerCommandHandler(SandboxCoreDbContext db)
        {
            this.db = db;
        }

        public Task<CommandResult> Execute(RemoveCustomer command)
        {
            if (command == null)
            {
                throw new ArgumentNullException();
            }

            return null;
        }

        public Task<CommandResult> Execute(ModifyCustomer command)
        {
            if (command == null)
            {
                throw new ArgumentNullException();
            }

            return null;
        }

        public Task<CommandResult> Execute(AddCustomer command)
        {
            if (command == null)
            {
                throw new ArgumentNullException();
            }

            return null;
        }
    }
}
