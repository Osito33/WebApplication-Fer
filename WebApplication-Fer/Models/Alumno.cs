using System.ComponentModel.DataAnnotations;
namespace WebApplication_Fer.Models
{
    public class Alumno
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "La descripcion es obligatoria")]
        public string NombreAlumno { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public int Calificacion{ get; set; }
        [Required(ErrorMessage = "La calificacion es obligatoria")]
        public int Semestre { get; set; }
        


    }
}
