using Microsoft.AspNetCore.Mvc;
using WebApplication_Fer.Data;

namespace WebApplication_Fer.Controllers
{
    public class ListaDesplegableController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ListaDesplegableController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var productos = _context.Productos.Select(u => u.Descripcion).ToList();
            ViewBag.Producto = productos;
            return View();
        }

    }

}
