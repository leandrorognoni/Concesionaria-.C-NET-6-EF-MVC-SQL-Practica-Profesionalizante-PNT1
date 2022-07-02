using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Concesionaria.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese el dni")]
        [Range(1000000, 99999999, ErrorMessage = "Ingrese numero de Dni valido ")]
        public int Dni { get; set; }

        [Required(ErrorMessage = "Ingrese contraseña")]
        public String Contraseña { get; set; }

        [Required(ErrorMessage = "Ingrese su nombre")]
        public String Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese su apellido")]
        public String Apellido { get; set; }
         
        [Required(ErrorMessage = "Ingrese su e-mail")]
        [EmailAddress(ErrorMessage = "Ingrese un formato correcto de email")]
        public String Email { get; set; }

         public Vehiculo? Vehiculo { get; set; }
         
        public Plan? Plan { get; set; }
 
        public Factura? Factura { get; set; }    
    }
}
