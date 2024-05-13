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
    public class CentrosDeportivosController : Controller
    {
        private readonly MyContext _context;

        public CentrosDeportivosController(MyContext context)
        {
            _context = context;
        }

        // GET: CentrosDeportivos
        public async Task<IActionResult> Index()
        {
              return _context.CentrosDeportivos != null ? 
                          View(await _context.CentrosDeportivos.ToListAsync()) :
                          Problem("Entity set 'MyContext.CentrosDeportivos'  is null.");
        }

        // GET: CentrosDeportivos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CentrosDeportivos == null)
            {
                return NotFound();
            }

            var centroDeportivo = await _context.CentrosDeportivos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (centroDeportivo == null)
            {
                return NotFound();
            }

            return View(centroDeportivo);
        }

        // GET: CentrosDeportivos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CentrosDeportivos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Direccion")] CentroDeportivo centroDeportivo)
        {
     
                _context.Add(centroDeportivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            
        }

        // GET: CentrosDeportivos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CentrosDeportivos == null)
            {
                return NotFound();
            }

            var centroDeportivo = await _context.CentrosDeportivos.FindAsync(id);
            if (centroDeportivo == null)
            {
                return NotFound();
            }
            return View(centroDeportivo);
        }

        // POST: CentrosDeportivos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Direccion")] CentroDeportivo centroDeportivo)
        {
            if (id != centroDeportivo.Id)
            {
                return NotFound();
            }

          
               
                    _context.Update(centroDeportivo);
                    await _context.SaveChangesAsync();
               
                return RedirectToAction(nameof(Index));
            

        }

        // GET: CentrosDeportivos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CentrosDeportivos == null)
            {
                return NotFound();
            }

            var centroDeportivo = await _context.CentrosDeportivos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (centroDeportivo == null)
            {
                return NotFound();
            }

            return View(centroDeportivo);
        }

        // POST: CentrosDeportivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CentrosDeportivos == null)
            {
                return Problem("Entity set 'MyContext.CentrosDeportivos'  is null.");
            }
            var centroDeportivo = await _context.CentrosDeportivos.FindAsync(id);
            if (centroDeportivo != null)
            {
                _context.CentrosDeportivos.Remove(centroDeportivo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CentroDeportivoExists(int id)
        {
          return (_context.CentrosDeportivos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
