using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SandboxCore.Commands;

namespace SandboxCore.Command.Customer
{
    public class RemoveCustomer : ICommand
    {
        public int CustomerId { get; set; }
    }
}
