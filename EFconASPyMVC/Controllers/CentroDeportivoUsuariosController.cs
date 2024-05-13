using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFconASPyMVC.Context;
using EFconASPyMVC.Models;
using Microsoft.Data.SqlClient.DataClassification;

namespace EFconASPyMVC.Controllers
{
    public class CentroDeportivoUsuariosController : Controller
    {
        private readonly MyContext _context;

        public CentroDeportivoUsuariosController(MyContext context)
        {
            _context = context;
        }

        // GET: CentroDeportivoUsuarios
        public async Task<IActionResult> Index()
        {
            var myContext = _context.CentrosUsuarios.Include(c => c.CentroDeportivo).Include(c => c.Usuario);
            return View(await myContext.ToListAsync());
        }

        // GET: CentroDeportivoUsuarios/Details/5
        public async Task<IActionResult> Details(int UsuarioId,int? CentroDeportivoId)
        {
            if (CentroDeportivoId==null ||UsuarioId == null )
            {
                return NotFound();
            }

            var centroDeportivoUsuario = await _context.CentrosUsuarios
                .Include(c => c.CentroDeportivo)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.UsuarioId == UsuarioId && m.CentroDeportivoId==CentroDeportivoId);
            if (centroDeportivoUsuario == null)
            {
                return NotFound();
            }

            return View(centroDeportivoUsuario);
        }

        // GET: CentroDeportivoUsuarios/Create
        public IActionResult Create()
        {
            ViewData["CentroDeportivoId"] = new SelectList(_context.CentrosDeportivos, "Id", "Id");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id");
            return View();
        }

        // POST: CentroDeportivoUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioId,CentroDeportivoId")] CentroDeportivoUsuario centroDeportivoUsuario)
        {

                _context.Add(centroDeportivoUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

        }

        // GET: CentroDeportivoUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? UsuarioId, int? CentroDeportivoId)
        {
            if (CentroDeportivoId == null || UsuarioId == null)
            {
                return NotFound();
            }

            var centroDeportivoUsuario = await _context.CentrosUsuarios.FindAsync(UsuarioId,CentroDeportivoId);
            if (centroDeportivoUsuario == null)
            {
                return NotFound();
            }
            ViewData["CentroDeportivoId"] = new SelectList(_context.CentrosDeportivos, "Id", "Id", centroDeportivoUsuario.CentroDeportivoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", centroDeportivoUsuario.UsuarioId);
            return View(centroDeportivoUsuario);
        }

        // POST: CentroDeportivoUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int UsuarioId,int CentroDeportivoId, [Bind("UsuarioId,CentroDeportivoId")] CentroDeportivoUsuario centroDeportivoUsuario)
        {
            if (UsuarioId != centroDeportivoUsuario.UsuarioId || CentroDeportivoId!=centroDeportivoUsuario.CentroDeportivoId)
            {
                return NotFound();
            }

 
                    _context.Update(centroDeportivoUsuario);
                    await _context.SaveChangesAsync();
          
                return RedirectToAction(nameof(Index));

        }

        // GET: CentroDeportivoUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? UsuarioId, int? CentroDeportivoId)
        {
            if (CentroDeportivoId == null || UsuarioId == null)
            {
                return NotFound();
            }

            var centroDeportivoUsuario = await _context.CentrosUsuarios
                .Include(c => c.CentroDeportivo)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.UsuarioId == UsuarioId && m.CentroDeportivoId == CentroDeportivoId);
            if (centroDeportivoUsuario == null)
            {
                return NotFound();
            }

            return View(centroDeportivoUsuario);
        }

        // POST: CentroDeportivoUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int UsuarioId, int CentroDeportivoId)
        {
            
            var centroDeportivoUsuario = await _context.CentrosUsuarios.FindAsync(UsuarioId, CentroDeportivoId);
            if (centroDeportivoUsuario != null)
            {
                _context.CentrosUsuarios.Remove(centroDeportivoUsuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
