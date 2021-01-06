using Microsoft.AspNetCore.Mvc;
using RewardPointsApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RewardPointsApp.ViewModel
{
    public class CustomerViewModel
    {
        [Required]
        [BindProperty]
        public Guid Guid { get; set; }
        public int Rewards { get; set; }
        public List<Invoice> Invoices { get; set; }

        public CustomerViewModel() { }

        public CustomerViewModel(Customer customer)
        {
            Guid = customer.Guid;
            Rewards = customer.Rewards;
            Invoices = customer.Invoices.ToList();
        }
    }
}
