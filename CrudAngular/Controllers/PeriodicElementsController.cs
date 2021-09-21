using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodicElementsController : ControllerBase
    {
        private readonly CrudAngularAppDbContext _context;

        public PeriodicElementsController(CrudAngularAppDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetElements()
        {
            return Ok(await _context.PeriodicElements.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateElement(PeriodicElement element)
        {
            await _context.PeriodicElements.AddAsync(element);
            await _context.SaveChangesAsync();

            return Created(string.Empty, element);
        }

        [HttpPut]
        public async Task<IActionResult> EditElement(PeriodicElement element)
        {
            if(!_context.PeriodicElements.Any(e => e.Id == element.Id))
            {
                return NotFound();
            }

            _context.Entry(element).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(element);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteElement(int id)
        {
            var dbElement = await _context.PeriodicElements.FindAsync(id);

            if (dbElement == null)
            {
                return NotFound("Element not found!");
            }

            _context.PeriodicElements.Remove(dbElement);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
