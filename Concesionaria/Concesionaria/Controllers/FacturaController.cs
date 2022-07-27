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
    public class FacturaController : Controller
    {
        private readonly ConcesionariaContext _context;

        public FacturaController(ConcesionariaContext context)
        {
            _context = context;
        }

        // GET: Factura
        public async Task<IActionResult> Index()
        {
            var concesionariaContext = _context.facturas.Include(f => f.Cliente);
            return View(await concesionariaContext.ToListAsync());
        }

        // GET: FacturasTotal
        public async Task<IActionResult> FacturasTotal()
        {
            var concesionariaContext = _context.facturas.Include(f => f.Cliente);
            return View(await concesionariaContext.ToListAsync());
        }


        // GET: Factura/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.facturas == null)
            {
                return NotFound();
            }

            var factura = await _context.facturas
                .Include(f => f.Cliente)
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // GET: Factura/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.clientes, "Id", "Apellido");
            return View();
        }

        // POST: Factura/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteId,Fecha,NombreCliente,ApellidoCliente,Marca,Modelo,MontoAbonado,MontoTotal")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(factura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.clientes, "Id", "Apellido", factura.ClienteId);
            return View(factura);
        }

        // GET: Factura/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.facturas == null)
            {
                return NotFound();
            }

            var factura = await _context.facturas.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.clientes, "Id", "Apellido", factura.ClienteId);
            return View(factura);
        }

        // POST: Factura/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,Fecha,NombreCliente,ApellidoCliente,Marca,Modelo,MontoAbonado,MontoTotal")] Factura factura)
        {
            if (id != factura.ClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturaExists(factura.ClienteId))
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
            ViewData["ClienteId"] = new SelectList(_context.clientes, "Id", "Apellido", factura.ClienteId);
            return View(factura);
        }

        // GET: Factura/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.facturas == null)
            {
                return NotFound();
            }

            var factura = await _context.facturas
                .Include(f => f.Cliente)
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // POST: Factura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.facturas == null)
            {
                return Problem("Entity set 'ConcesionariaContext.facturas'  is null.");
            }
            var factura = await _context.facturas.FindAsync(id);
            if (factura != null)
            {
                _context.facturas.Remove(factura);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaExists(int id)
        {
          return (_context.facturas?.Any(e => e.ClienteId == id)).GetValueOrDefault();
        }
    }
}
