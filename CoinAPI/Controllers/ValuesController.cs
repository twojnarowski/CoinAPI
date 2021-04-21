using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoinAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoinAPI.Controllers
{
    public class ValuesController : Controller
    {
        private readonly CoinDBContext _context;

        public ValuesController(CoinDBContext context)
        {
            _context = context;
        }

        [HttpGet("Values")]
        // GET: Values
        public async Task<ActionResult<IEnumerable<Value>>> Index()
        {
            return await _context.Values.ToListAsync();
        }

        [HttpGet("Values/Details/{id}")]
        // GET: Values/Details/5
        public async Task<ActionResult<Value>> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var value = await _context.Values
                .FirstOrDefaultAsync(m => m.Id == id);
            if (value == null)
            {
                return NotFound();
            }

            return value;
        }

        // POST: Values/Create
        [HttpPost("Values/Create")]
        public async Task<ActionResult<Value>> Create([Bind("Id,Code,Timestamp,Rate")] Value value)
        {
            if (ModelState.IsValid)
            {
                _context.Add(value);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return value;
        }

        [HttpPut("Values/Edit/{id}")]
        // POST: Values/Edit/5
        public async Task<ActionResult<Value>> Edit(int id, [Bind("Id,Code,Timestamp,Rate")] Value value)
        {
            if (id != value.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(value);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ValueExists(value.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return value;
        }

        // POST: Values/Delete/5
        [HttpDelete("Values/Delete/{id}"), ActionName("Delete")]
        public async Task<ActionResult<int>> DeleteConfirmed(int id)
        {
            var value = await _context.Values.FindAsync(id);
            _context.Values.Remove(value);
            await _context.SaveChangesAsync();
            return id;
        }

        private bool ValueExists(int id)
        {
            return _context.Values.Any(e => e.Id == id);
        }
    }
}