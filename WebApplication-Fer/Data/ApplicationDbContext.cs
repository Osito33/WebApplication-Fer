using WebApplication_Fer.Models;
using Microsoft.EntityFrameworkCore;
namespace WebApplication_Fer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //public DbSet<Producto> Inicio { get; set; }
        public DbSet<Producto> Productos { get; set; }

        public DbSet<Producto> Alumnos { get; set; }
        public DbSet<WebApplication_Fer.Models.Alumno> Alumno { get; set; } = default!;
        public DbSet<WebApplication_Fer.Models.Usuario> Usuario { get; set; } = default!;



    }
}