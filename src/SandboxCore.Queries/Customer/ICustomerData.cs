using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SandboxCore.Queries
{
    public interface ICustomerData
    {
        Customer GetCustomer(int customerId);
        IReadOnlyCollection<Customer> GetAllCustomers();
    }
}
