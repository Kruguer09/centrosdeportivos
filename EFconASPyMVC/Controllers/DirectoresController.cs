using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFconASPyMVC.Context;
using EFconASPyMVC.Models;

namespace EFconASPyMVC.Controllers
{
    public class DirectoresController : Controller
    {
        private readonly MyContext _context;

        public DirectoresController(MyContext context)
        {
            _context = context;
        }

        // GET: Directores
        public async Task<IActionResult> Index()
        {
            var myContext = _context.Directores.Include(d => d.CentroDeportivo);
            return View(await myContext.ToListAsync());
        }

        // GET: Directores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Directores == null)
            {
                return NotFound();
            }

            var director = await _context.Directores
                .Include(d => d.CentroDeportivo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (director == null)
            {
                return NotFound();
            }

            return View(director);
        }

        // GET: Directores/Create
        public IActionResult Create()
        {
            ViewData["CentroDeportivoId"] = new SelectList(_context.CentrosDeportivos, "Id", "Id");
            return View();
        }

        // POST: Directores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Empleados,CentroDeportivoId")] Director director)
        {

                _context.Add(director);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            

        }

        // GET: Directores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Directores == null)
            {
                return NotFound();
            }

            var director = await _context.Directores.FindAsync(id);
            if (director == null)
            {
                return NotFound();
            }
            ViewData["CentroDeportivoId"] = new SelectList(_context.CentrosDeportivos, "Id", "Id", director.CentroDeportivoId);
            return View(director);
        }

        // POST: Directores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Empleados,CentroDeportivoId")] Director director)
        {
            if (id != director.Id)
            {
                return NotFound();
            }

   
                    _context.Update(director);
                    await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));

        }

        // GET: Directores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Directores == null)
            {
                return NotFound();
            }

            var director = await _context.Directores
                .Include(d => d.CentroDeportivo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (director == null)
            {
                return NotFound();
            }

            return View(director);
        }

        // POST: Directores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Directores == null)
            {
                return Problem("Entity set 'MyContext.Directores'  is null.");
            }
            var director = await _context.Directores.FindAsync(id);
            if (director != null)
            {
                _context.Directores.Remove(director);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirectorExists(int id)
        {
          return (_context.Directores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
