using RewardPointsApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RewardPointsApp.Models
{
    public class Invoice : IHaveGuid
    {
        
        [Key]
        public Guid Guid { get; set; }

        public Guid CustomerGuid { get; set; }

        public decimal Total { get; set; }

        public DateTimeOffset Date { get; set; }


        public Customer Customer { get; set; }

        

    }
}
