using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDonationManagementSystem.Models
{
    public class FoodDonor
    {
        [Key]
         public int DonorId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string city { get; set; }
    }
}
