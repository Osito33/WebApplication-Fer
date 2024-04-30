using System.ComponentModel.DataAnnotations;

namespace WebApplication_Fer.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El Nombre es Obligatorio")]
        public required string User { get; set; }
        [Required(ErrorMessage = "La Clave es Obligatoria")]
        public required string Contra { get; set; }
    }

}
