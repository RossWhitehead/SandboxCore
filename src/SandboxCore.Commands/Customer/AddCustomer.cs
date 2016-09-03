using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SandboxCore.Commands.Customer
{
    public class AddCustomer : ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
