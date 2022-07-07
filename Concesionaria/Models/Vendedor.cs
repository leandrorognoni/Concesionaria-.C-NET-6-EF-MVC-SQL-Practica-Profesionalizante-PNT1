using System.ComponentModel.DataAnnotations;

namespace Concesionaria.Models
{
    public class Vendedor
    {
        [Key]
        public int IdVendedor { get; set; }


        [Required(ErrorMessage = "Ingrese el usuario")]
        public String Usuario { get; set; }
          
        [Required(ErrorMessage = "Ingrese una constreña")]
        public String Contraseña { get; set; }
         
 
    }
}
