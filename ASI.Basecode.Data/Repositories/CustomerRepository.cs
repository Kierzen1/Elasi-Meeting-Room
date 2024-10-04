using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using Basecode.Data.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Data.Repositories
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        List<Customer> _allCustomer = new();
        private readonly AsiBasecodeDBContext _dbContext;

        public CustomerRepository(AsiBasecodeDBContext dbContext, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Customer> ViewCustomers()
        {
            return _dbContext.Customers.ToList();
        }

        public void AddCustomer(Customer customer)
        {
            try
            {
                var newCustomer = new Customer();
                newCustomer.customerName = customer.customerName;
                newCustomer.customerEmail = customer.customerEmail;
                newCustomer.role = customer.role;
                newCustomer.customerPassword= customer.customerPassword;
                _dbContext.Customers.Add(newCustomer);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new InvalidDataException("error adding customer");
            }
        }
        public void DeleteCustomer(Customer customer)
        {
            _dbContext.Customers.Remove(customer);
            _dbContext.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            var existingCustomer = _dbContext.Customers.FirstOrDefault(c => c.customerId == customer.customerId);
            if (existingCustomer != null)
            {
                existingCustomer.customerName = customer.customerName;
                existingCustomer.customerEmail = customer.customerEmail;
                existingCustomer.role = customer.role;
                existingCustomer.customerPassword = customer.customerPassword;

                _dbContext.Customers.Update(existingCustomer);
                _dbContext.SaveChanges();

            }
        }
        public (bool, IEnumerable<Customer>) GetCustomers()
        {
            throw new NotImplementedException();
        }
    }
}
