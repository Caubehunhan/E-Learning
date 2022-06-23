using E_Learning.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClassController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Class>>> GetClasses()
        {
            if (_context.Class == null)
            {
                return NotFound();
            }
            return await _context.Class.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Class>> GetClass(string id)
        {
            if (_context.Class == null)
            {
                return NotFound();
            }
            var @class = await _context.Class.FindAsync(id);

            if (@class == null)
            {
                return NotFound();
            }
            return @class;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Class>> PutClass(string id, Class @class)
        {
            if (id == @class.ID)
            {
                _context.Entry(@class).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassExists(id))
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
            return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult<Class>> PutClass(Class @class)
        {
            if (_context.Class == null)
            {
                return Problem("Emtity set 'Context.Classes' is null. ");
            }
            _context.Class.Add(@class);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClassExists(@class.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("GetClass", new { id = @class.ID }, @class);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClass(string  id)
        {
            if (_context.Class == null)
            {
                return NotFound();
            }
            var @class = await _context.Class.FindAsync(id);
            if (@class == null)
            {
                return NotFound();
            }

            _context.Class.Remove(@class);
            await _context.SaveChangesAsync();

            return NotFound();
        }

        private bool ClassExists(string id)
        {
            return (_context.Class?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
