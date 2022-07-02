using System.ComponentModel.DataAnnotations;

namespace Concesionaria.Models
{
    public class Factura
    {
        [Key]
        public int ClienteId { get; set; }
  
  
        [Required(ErrorMessage = "Ingrese una fecha")]
     //  [Range(typeof(DateTime), "1/1/1990 0:00:00" , "1/1/2020 0:00:00", ErrorMessage = "La fecha debe ser entre {1} y {2}")]
        public DateTime Fecha { get; set; }

        [Display(Name = "Nombre del cliente")]
        [Required(ErrorMessage = "Ingrese nombre del cliente")]
        public String NombreCliente { get; set; }

        [Display(Name = "Apellido del cliente")]
        [Required(ErrorMessage = "Ingrese apellido del cliente")]
        public String ApellidoCliente { get; set; }

      
        [Required(ErrorMessage = "Ingrese la marca del vehiculo")]
        public String Marca { get; set; }

        [Required(ErrorMessage = "Ingrese el modelo del vehiculo")]
        public String Modelo { get; set; }

        [Display(Name = "Monto a Pagar")]
        [Required(ErrorMessage = "Ingrese monto a pagar")]
        [Range(1, 99999999, ErrorMessage = "Ingrese un monto mayor a 0 ")]
        public double MontoAbonado { get; set; }

        [Display(Name = "Monto total")]
        [Required(ErrorMessage = "Ingrese monto total")]
        [Range(1, 99999999, ErrorMessage = "Ingrese un monto mayor a 0 ")]
        public double MontoTotal { get; set; }
      
        public Cliente? Cliente { get; set; }
        
    }
}
