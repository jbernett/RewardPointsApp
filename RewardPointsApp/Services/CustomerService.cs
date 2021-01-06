using Microsoft.EntityFrameworkCore;
using RewardPointsApp.Models;
using RewardPointsApp.Repositories;
using RewardPointsApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RewardPointsApp.Services
{
    public class CustomerService
    {
        private RewardPointsDbContext _context;
        public CustomerService(RewardPointsDbContext context)
        {
            _context = context;
        }

        public CustomerService()
        {
        }

        public CustomerViewModel GetPastThreeMonthCustomerRewards(CustomerViewModel customerViewModel)
        {
            var date = DateTimeOffset.Now.AddMonths(-3);
            var customer = GetCustomerWithInvoicedById(customerViewModel.Guid);

            customerViewModel.Invoices = customer.Invoices.Where(o => o.Date >= date).ToList();

            CalculateRewards(customerViewModel);
            return customerViewModel;
        }

        internal List<CustomerViewModel> GetAllCustomersWithInvoices()
        {
            return _context.Customers.Include(o => o.Invoices).Select(o => new CustomerViewModel(o)).ToList();
        }

        private void CalculateRewards(CustomerViewModel customer)
        {
            var points = 0;
            foreach (var invoice in customer.Invoices)
            {
                if(invoice.Total > 50)
                {
                    points += (int)Math.Floor(invoice.Total) - 50;
                }
                if(invoice.Total > 100)
                {
                    points += ((int)Math.Floor(invoice.Total) - 100) * 2;
                }
            }

            customer.Rewards = points;
        }

        public Customer GetCustomerWithInvoicedById(Guid guid)
        {
            var customer = _context.Customers
                .Include(o => o.Invoices)
                .Where(o => o.Guid == guid)
                .FirstOrDefault();   

            return customer;
        }
    }
}
