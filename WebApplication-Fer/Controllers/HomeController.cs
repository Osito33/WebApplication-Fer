using WebApplication_Fer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using WebApplication_Fer.Data;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Rotativa.AspNetCore;


namespace WebApplication_Fer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Productos.ToArrayAsync());
        }
        //Metodo para llamar la vista del frame
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(int id ) 
            
        {
            var ProductoEncontrado = _context.Productos.Find(id);
            if (ProductoEncontrado != null)
            {
                return View(ProductoEncontrado);
            }
            else
            {
                return NotFound();
            }
         
        }

        public IActionResult Delete(int id)

        {
            var ProductoEncontrado = _context.Productos.Find(id);
            if (ProductoEncontrado != null)
            {
                return View(ProductoEncontrado);
            }
            else
            {
                return View();
            }
           
        }


        [HttpPost]
        public async Task<ActionResult> AddPerson(Producto producto)
        {// validar si el formulario tiene datos incorrectos
            if (ModelState.IsValid)
            {
                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();
                // Despues de agregar el producto establece el mensaje de la alerta en TempData
                TempData["SuccessMessage"] = "El producto se ha guardado exitosamente.";
                return RedirectToAction("Index");
            }
            else
            {
                //si hay errores de validacion, vuelve a mostrar el formulario de creacion con los mensajes de error
                return View(producto);
            }
        }

        [HttpPost]
        public async Task<ActionResult> guardarCambios(Producto producto)
        {// validar si el formulario tiene datos incorrectos
            if (ModelState.IsValid)
            {
                _context.Productos.Update(producto);
                await _context.SaveChangesAsync();
                // Despues de agregar el producto establece el mensaje de la alerta en TempData
                TempData["SuccessMessage"] = "El producto se ha guardado exitosamente.";
                return RedirectToAction("Index");
            }
            else
            {
                //si hay errores de validacion, vuelve a mostrar el formulario de creacion con los mensajes de error
                return View(producto);
            }
        }

        [HttpPost]
        public async Task<ActionResult> eliminarProducto(Producto producto)
        {
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "El producto se ha Eliminado exitosamente.";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public async Task<IActionResult> generarReporte()
        {
            return new ViewAsPdf("generarReporte", await _context.Productos.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}