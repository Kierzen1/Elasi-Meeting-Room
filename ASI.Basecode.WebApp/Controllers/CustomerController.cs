using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ASI.Basecode.WebApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index(string search)
        {
            (bool result, IEnumerable<Customer> customers) = _customerService.GetCustomers();

            if (!result)
            {
                return View(null); 
            }
            if (!string.IsNullOrEmpty(search))
            {
                customers = customers.Where(c => c.customerName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                                          c.customerEmail.Contains(search, StringComparison.OrdinalIgnoreCase));
            }

            return View(customers.ToList());
        }

        public IActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            try
            {
                _customerService.AddCustomer(customer);
                return RedirectToAction("Index");
            }
            catch (InvalidDataException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View(customer); 
            }
        }

        public IActionResult Delete(int customerId)
        {
            (bool result, IEnumerable<Customer> customers) = _customerService.GetCustomers();
            var customer = customers.FirstOrDefault(r => customerId == r.customerId);
            if (customer != null)
            {
                _customerService.DeleteCustomer(customer);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Update(int customerId)
        {
            (bool result, IEnumerable<Customer> customers) = _customerService.GetCustomers();
            var customer = customers.FirstOrDefault(r => customerId == r.customerId);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerService.UpdateCustomer(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }
    }
}
