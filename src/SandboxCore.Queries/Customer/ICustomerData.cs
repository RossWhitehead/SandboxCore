using System.Collections.Generic;

namespace SandboxCore.Queries
{
    public interface ICustomerData
    {
        Customer GetCustomer(int customerId);
        IReadOnlyCollection<Customer> GetAllCustomers();
    }
}