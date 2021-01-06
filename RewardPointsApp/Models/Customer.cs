using RewardPointsApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RewardPointsApp.Models
{
    public class Customer : IHaveGuid
    {
        public Customer()
        {
            Invoices = new HashSet<Invoice>();
        }

        [Key]
        public Guid Guid { get; set; }       

        public int Rewards { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }        

    }

    
}
