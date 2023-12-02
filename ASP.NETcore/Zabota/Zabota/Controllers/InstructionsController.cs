using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zabota.Models;

namespace Zabota.Controllers
{
    public class InstructionsController : Controller
    {
        private readonly AppContext _context;

        public InstructionsController(AppContext context)
        {
            _context = context;
        }

        // GET: Instructions
        public async Task<IActionResult> Index()
        {
              return _context.Instructions != null ? 
                          View(await _context.Instructions.ToListAsync()) :
                          Problem("Entity set 'AppContext.Instructions'  is null.");
        }

        // GET: Instructions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Instructions == null)
            {
                return NotFound();
            }

            var instruction = await _context.Instructions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instruction == null)
            {
                return NotFound();
            }

            return View(instruction);
        }

        // GET: Instructions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instructions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Instruction instruction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instruction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instruction);
        }

        // GET: Instructions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Instructions == null)
            {
                return NotFound();
            }

            var instruction = await _context.Instructions.FindAsync(id);
            if (instruction == null)
            {
                return NotFound();
            }
            return View(instruction);
        }

        // POST: Instructions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Instruction instruction)
        {
            if (id != instruction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instruction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstructionExists(instruction.Id))
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
            return View(instruction);
        }

        // GET: Instructions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Instructions == null)
            {
                return NotFound();
            }

            var instruction = await _context.Instructions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instruction == null)
            {
                return NotFound();
            }

            return View(instruction);
        }

        // POST: Instructions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Instructions == null)
            {
                return Problem("Entity set 'AppContext.Instructions'  is null.");
            }
            var instruction = await _context.Instructions.FindAsync(id);
            if (instruction != null)
            {
                _context.Instructions.Remove(instruction);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstructionExists(int id)
        {
          return (_context.Instructions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
