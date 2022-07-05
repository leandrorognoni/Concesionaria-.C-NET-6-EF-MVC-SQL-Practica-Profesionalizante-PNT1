using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Concesionaria.Models;

namespace Concesionaria.Controllers
{
    public class VehiculoController : Controller
    {
        private readonly ConcesionariaContext _context;

        public VehiculoController(ConcesionariaContext context)
        {
            _context = context;
        }

        // GET: Vehiculo
        public async Task<IActionResult> Index()
        {
              return _context.vehiculos != null ? 
                          View(await _context.vehiculos.ToListAsync()) :
                          Problem("Entity set 'ConcesionariaContext.vehiculos'  is null.");
        }

        public async Task<IActionResult> VehiculosVenta()
        {
            return _context.vehiculos != null ?
                        View(await _context.vehiculos.ToListAsync()) :
                        Problem("Entity set 'ConcesionariaContext.vehiculos'  is null.");
        }

        // GET: Vehiculo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.vehiculos == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.vehiculos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // GET: Vehiculo/Financiacion
        public async Task<IActionResult> Financiacion(int? id)
        {
            if (id == null || _context.vehiculos == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.vehiculos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // GET: Vehiculo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vehiculo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca,Modelo,PrecioVenta,Color,Año,Kilometros,FueVendido,RutaImagen,TipoAuto")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehiculo);
        }

        // GET: Vehiculo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.vehiculos == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.vehiculos.FindAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }
            return View(vehiculo);
        }

        // POST: Vehiculo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca,Modelo,PrecioVenta,Color,Año,Kilometros,FueVendido,RutaImagen,TipoAuto")] Vehiculo vehiculo)
        {
            if (id != vehiculo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculoExists(vehiculo.Id))
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
            return View(vehiculo);
        }

        // GET: Vehiculo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.vehiculos == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.vehiculos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // POST: Vehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.vehiculos == null)
            {
                return Problem("Entity set 'ConcesionariaContext.vehiculos'  is null.");
            }
            var vehiculo = await _context.vehiculos.FindAsync(id);
            if (vehiculo != null)
            {
                _context.vehiculos.Remove(vehiculo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiculoExists(int id)
        {
          return (_context.vehiculos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
