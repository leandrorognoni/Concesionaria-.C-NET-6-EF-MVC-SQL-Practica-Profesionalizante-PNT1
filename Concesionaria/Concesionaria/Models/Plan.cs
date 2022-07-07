using System.ComponentModel.DataAnnotations;

namespace Concesionaria.Models
{
    public class Plan
    {



        [Key]
        public int ClienteId { get; set; }
  
        [Range(1, 99999999, ErrorMessage = "Ingrese Id Vehiculo entre 1 y 999999 ")]
        public int VehiculoId { get; set; }


        [Range(1, 99999999, ErrorMessage = "Ingrese un monto entre 1 y 999999 ")]
        [Required(ErrorMessage = "Ingrese el monto total")]
        [Display(Name = "Monto a pagar")]
        public double MontoAbonado { get; set; }

        [Range(1, 99999999, ErrorMessage = "Ingrese un monto entre 1 y 999999 ")]
        [Required(ErrorMessage = "Ingrese el monto restante")]
        [Display(Name = "Monto restante")]
        public double MontoTotal { get; set; }

        [Range(1, 72, ErrorMessage = "Ingrese cuotas de 1 a 72 ")]
        [Required(ErrorMessage = "Ingrese las cuotas restantes")]
        [Display(Name = "Cuotas restantes")]
        public int CuotasRestantes {get;set;}

        [Required]
        [Display(Name = "Fue aprobado")]
        public Boolean fueAprobado { get; set; }

        [EnumDataType(typeof(Plazo))]
        [Display(Name = "Plazo Entrega")]
        public Plazo PlazoEntrega { get; set; }

         public Cliente? Cliente { get; set; }
         public Vehiculo? Vehiculo { get; set; }


       
            
    }   
}
