using System;
using System.Collections.Generic;

namespace SandboxCore.Queries
{
    public class CustomerData : ICustomerData
    {
        public IReadOnlyCollection<Customer> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
