using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodDonationManagementSystem.DataAccess;
using FoodDonationManagementSystem.Models;

namespace FoodDonationManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodDonorsController : ControllerBase
    {
        private readonly FoodDbContext _context;

        public FoodDonorsController(FoodDbContext context)
        {
            _context = context;
        }

        // GET: api/FoodDonors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodDonor>>> GetFoodDonors()
        {
            return await _context.FoodDonors.ToListAsync();
        }

        // GET: api/FoodDonors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodDonor>> GetFoodDonor(int id)
        {
            var foodDonor = await _context.FoodDonors.FindAsync(id);

            if (foodDonor == null)
            {
                return NotFound();
            }

            return foodDonor;
        }

        // PUT: api/FoodDonors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodDonor(int id, FoodDonor foodDonor)
        {
            if (id != foodDonor.DonorId)
            {
                return BadRequest();
            }

            _context.Entry(foodDonor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodDonorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FoodDonors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FoodDonor>> PostFoodDonor(FoodDonor foodDonor)
        {
            _context.FoodDonors.Add(foodDonor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFoodDonor", new { id = foodDonor.DonorId }, foodDonor);
        }

        // DELETE: api/FoodDonors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FoodDonor>> DeleteFoodDonor(int id)
        {
            var foodDonor = await _context.FoodDonors.FindAsync(id);
            if (foodDonor == null)
            {
                return NotFound();
            }

            _context.FoodDonors.Remove(foodDonor);
            await _context.SaveChangesAsync();

            return foodDonor;
        }

        private bool FoodDonorExists(int id)
        {
            return _context.FoodDonors.Any(e => e.DonorId == id);
        }
    }
}
