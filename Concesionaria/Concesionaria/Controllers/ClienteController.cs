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
    public class ClienteController : Controller
    {
        private readonly ConcesionariaContext _context;

        public ClienteController(ConcesionariaContext context)
        {
            _context = context;
        }

        // GET: Cliente
        public async Task<IActionResult> Index()
        {
              return _context.clientes != null ? 
                          View(await _context.clientes.ToListAsync()) :
                          Problem("Entity set 'ConcesionariaContext.clientes'  is null.");
        }

        //GET: Cliente/Consulta
        public IActionResult Consulta()
        {
            return View();
        }


        [HttpPost]
        // POST: Cliente/Consulta 
        public IActionResult Consulta(int dni, String contraseña)
        {

            var i = 1;
            var cliente = new Cliente();
            Boolean existe = false;

            while (i <= _context.clientes.Count() && !existe)
            {
                 cliente = _context.clientes.Find(i);

                if(cliente != null)
                {

                    if (cliente.Dni == dni && cliente.Contraseña.Equals(contraseña))
                    {
                        existe = true;

                    }
                    else
                    {
                        i++;
                    }


                }
                else
                {
                    i++;
                }

            }

            if (existe)
            {


                return RedirectToAction("Details", "Plan", new {cliente.Id});
             }
            else
            {
                ViewBag.Mensaje = "No fue encontrado el Dni o Contraseña";

                return View();
            }

        }




        // GET: Cliente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }
        //GET: Cliente/RegistroOk

        public IActionResult RegistroOk()
        {
            return View();
        }

        //GET: Cliente/Seleccion

        public IActionResult Seleccion(int? id)
        {
            TempData["idVehiculoSeleccionado"] = id; 
            return View();
        }

        //POST: Cliente/Seleccion
        [HttpPost]
        public IActionResult Seleccion(int dni, String contraseña)
        {
            var i = 1;
            var cliente = new Cliente();
            Boolean existe = false;
            var  idVehiculo =  TempData["idVehiculoSeleccionado"];

            while (i <= _context.clientes.Count() && !existe)
            {
                cliente = _context.clientes.Find(i);

                if (cliente != null)
                {

                    if (cliente.Dni == dni && cliente.Contraseña.Equals(contraseña))
                    {
                        existe = true;

                    }
                    else
                    {
                        i++;
                    }


                }
                else
                {
                    i++;
                }

            }



            if (existe && cliente.Plan == null)
            {
              
                
                var routeValues = new { ClienteId = cliente.Id, VehiculoId = idVehiculo, MontoAbonado = 12, MontoTotal = 14, CuotasRestantes = 2, fueAprobado = false, PlazoEntrega = Plazo.CUOTA_12 };
                return  RedirectToAction("CreateSeleccion", "Plan", routeValues);
            }
            else if(!existe)
            {
                ViewBag.Mensaje = "No fue encontrado el Dni o Contraseña";

                return View();
            }
            else
            {
                ViewBag.Mensaje = "El Dni Ingresado ya posee un plan de financiación";
               

            }

            return View();
        }


        // GET: Cliente/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Cliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Dni,Contraseña,Nombre,Apellido,Email")] Cliente cliente)
        { 
            var buscadoPorDni = _context.clientes.Where(m => m.Dni == cliente.Dni);
            Cliente clienteEncontrado = buscadoPorDni.FirstOrDefault();

            if (ModelState.IsValid && clienteEncontrado==null)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(RegistroOk));
            }
            else
            {
                ViewBag.MensajeInvalido = "Ya existe un cliente con ese DNI ";

            }
            return View(cliente);
        }
 

        // GET: Cliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Dni,Contraseña,Nombre,Apellido,Email")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id))
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
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.clientes == null)
            {
                return Problem("Entity set 'ConcesionariaContext.clientes'  is null.");
            }
            var cliente = await _context.clientes.FindAsync(id);
            if (cliente != null)
            {

                _context.clientes.Remove(cliente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
          return (_context.clientes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
