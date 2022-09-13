using FoodDonationManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDonationManagementSystem.DataAccess
{
    public class FoodDbContext:DbContext
    {
        public FoodDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<FoodDonor> FoodDonors { get; set; }
    }
}
