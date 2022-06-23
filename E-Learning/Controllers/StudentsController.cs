using E_Learning.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
            private readonly ApplicationDbContext _context;

            public StudentsController(ApplicationDbContext context)
            {
                _context = context;
            }


         
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            if (_context.User == null)
            {
                return NotFound();
            }
            return await _context.User.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(string id)
        {
            if (_context.User == null)
            {
                return NotFound();
            }
            var User = await _context.User.FindAsync(id);

            if (User == null)
            {
                return NotFound();
            }
            return User;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> PutUser(string id, User User)
        {
            if (id != User.ID)
            {
                _context.Entry(User).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(id))
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
        public async Task<ActionResult<User>> PuUser(User User)
        {
            if (_context.User == null)
            {
                return Problem("Emtity set 'Context.User' is null. ");
            }
            _context.User.Add(User);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserExists(User.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("GetUser", new { id = User.ID }, User);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(string id)
        {
            if (_context.User == null)
            {
                return NotFound();
            }
            var User = await _context.User.FindAsync(id);
            if (User == null)
            {
                return NotFound();
            }

            _context.User.Remove(User);
            await _context.SaveChangesAsync();

            return NotFound();
        }

        private bool UserExists(string id)
        {
            return (_context.User?.Any(e => e.ID == id)).GetValueOrDefault();
        }

    }
}
