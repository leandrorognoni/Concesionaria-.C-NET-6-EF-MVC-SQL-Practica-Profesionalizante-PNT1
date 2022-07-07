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
    public class PlanController : Controller
    {
        private readonly ConcesionariaContext _context;

        public PlanController(ConcesionariaContext context)
        {
            _context = context;
        }

        // GET: Plan
        public async Task<IActionResult> Index()
        {
            var concesionariaContext = _context.planes.Include(p => p.Cliente).Include(p => p.Vehiculo);
            return View(await concesionariaContext.ToListAsync());
        }

        //GET: Descripcion
        public async Task<IActionResult> Descripcion()
        {
             return View();
        }

        // GET: Plan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.planes == null)
            {
                return NotFound();
            }

            var plan = await _context.planes
                .Include(p => p.Cliente)
                .Include(p => p.Vehiculo)
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (plan == null)
            {
                return NotFound();
            }

            return View(plan);
        }

        // GET: Plan/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.clientes, "Id", "Id");
            ViewData["VehiculoId"] = new SelectList(_context.vehiculos, "Id", "Id");
            return View();
        }

        // POST: Plan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteId,VehiculoId,MontoAbonado,MontoTotal,CuotasRestantes,fueAprobado,PlazoEntrega")] Plan plan)
        {
            plan.Cliente = _context.clientes.Find(plan.ClienteId);
            plan.Vehiculo = _context.vehiculos.Find(plan.VehiculoId);
           
            
            if (ModelState.IsValid)
            {
                _context.Add(plan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.clientes, "Id", "Id", plan.ClienteId);
            ViewData["VehiculoId"] = new SelectList(_context.vehiculos, "Id", "Id", plan.VehiculoId);
            return View(plan);
        }
        /*
                [HttpPost]
                [ValidateAntiForgeryToken]
                public IActionResult Create(int id, int vehi, int monto, int total , int cuo, Boolean fue, Plazo plazo )
                {


                    return View( );
                }
        */
     
         public   IActionResult  CreateSeleccion([Bind("ClienteId,VehiculoId,MontoAbonado,MontoTotal,CuotasRestantes,fueAprobado,PlazoEntrega")] Plan plan)
        {
            plan.Cliente = _context.clientes.Find(plan.ClienteId);
            plan.Vehiculo = _context.vehiculos.Find(plan.VehiculoId);
            
            Cliente cliente = _context.clientes.Find(plan.ClienteId);
           
            if (ModelState.IsValid)
            {
                //Si es valido, ademas se asigna el vehiculo del cliente y el plan al cliente
                 cliente.Vehiculo = _context.vehiculos.Find(plan.VehiculoId);
                 cliente.Plan = plan;


                //OJOOOOOOOOOO
                plan.Vehiculo = cliente.Vehiculo;
                plan.Cliente = cliente;
                
                _context.Add(plan);
                  _context.SaveChanges();
                return RedirectToAction(nameof(PlanRegistrado));
            }
            ViewData["ClienteId"] = new SelectList(_context.clientes, "Id", "Id", plan.ClienteId);
            ViewData["VehiculoId"] = new SelectList(_context.vehiculos, "Id", "Id", plan.VehiculoId);
            return View(plan);
        }
        

        //GET: Plan/Registrado

        public async Task<IActionResult> PlanRegistrado ()
        {
            return View();
        }


        // GET: Plan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.planes == null)
            {
                return NotFound();
            }

            var plan = await _context.planes.FindAsync(id);
            if (plan == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.clientes, "Id", "Apellido", plan.ClienteId);
            ViewData["VehiculoId"] = new SelectList(_context.vehiculos, "Id", "Color", plan.VehiculoId);
            return View(plan);
        }

        // POST: Plan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,VehiculoId,MontoAbonado,MontoTotal,CuotasRestantes,fueAprobado,PlazoEntrega")] Plan plan)
        {
            if (id != plan.ClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanExists(plan.ClienteId))
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
            ViewData["ClienteId"] = new SelectList(_context.clientes, "Id", "Apellido", plan.ClienteId);
            ViewData["VehiculoId"] = new SelectList(_context.vehiculos, "Id", "Color", plan.VehiculoId);
            return View(plan);
        }

        // GET: Plan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.planes == null)
            {
                return NotFound();
            }

            var plan = await _context.planes
                .Include(p => p.Cliente)
                .Include(p => p.Vehiculo)
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (plan == null)
            {
                return NotFound();
            }

            return View(plan);
        }

        // POST: Plan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.planes == null)
            {
                return Problem("Entity set 'ConcesionariaContext.planes'  is null.");
            }
            var plan = await _context.planes.FindAsync(id);
            if (plan != null)
            {

                //Se modifican a null ambos campos para evitar error por restriccion FK 
      
                Cliente cliente = _context.clientes.Find(plan.ClienteId);
                cliente.Vehiculo = _context.vehiculos.Find(plan.VehiculoId);
                cliente.Plan = null;
                cliente.Vehiculo = null;
                 

                    _context.planes.Remove(plan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanExists(int id)
        {
          return (_context.planes?.Any(e => e.ClienteId == id)).GetValueOrDefault();
        }
    }
}
