using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.Interfaces;
using ASI.Basecode.Services.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService (ICustomerRepository customerRepository)
        {
            this._customerRepository= customerRepository;
        }

        public (bool, IEnumerable<Customer>) GetCustomers()
        {

            var customers = _customerRepository.ViewCustomers();
            if (customers != null)
            {
                return (true, customers);
            }
            return (false, null);
        }

        public void AddCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentException();
            }
            var newCustomer = new Customer();

            newCustomer.customerName = customer.customerName;
            newCustomer.customerEmail = customer.customerEmail;
            newCustomer.role = customer.role;
            newCustomer.customerPassword = PasswordManager.EncryptPassword(customer.customerPassword);
            _customerRepository.AddCustomer(newCustomer);

        }
        public void DeleteCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentException();
            }


            _customerRepository.DeleteCustomer(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentException();
            }


            _customerRepository.UpdateCustomer(customer);
        }

    }
}
