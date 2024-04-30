using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication_Fer.Data;
using WebApplication_Fer.Models;

namespace WebApplication_Fer.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string nombreUsuario, string contraseña)
        {
            var usuario = _context.Usuario.FirstOrDefault(u => u.User == nombreUsuario && u.Contra == contraseña);
            if (usuario != null)
            {
                // Usuario autenticado, redirigir al inicio
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Credenciales incorrectas");
                return View();
            }
        }
    }

}
