using System.ComponentModel.DataAnnotations;

namespace Concesionaria.Models
{
    public class Vendedor
    {
        [Key]
        public int IdVendedor { get; set; }


        [Required(ErrorMessage = "Ingrese el Nombre")]
        public String Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese el Apellido")]
        public String Apellido { get; set; }

        [Required(ErrorMessage = "Ingrese una constreña")]
        public String Contraseña { get; set; }


        [Required(ErrorMessage = "Ingrese el Dni")]
        [Range(1000000, 99999999, ErrorMessage = "Ingrese numero de Dni valido ")]
        public int Dni { get; set; }

        public List<Cliente> Clientes { get; set; }
    }
}
