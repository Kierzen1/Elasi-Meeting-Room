using ASI.Basecode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Data.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> ViewCustomers();
        void AddCustomer(Customer customer);

        void DeleteCustomer(Customer customer);

        void UpdateCustomer(Customer customer);
    }
}
