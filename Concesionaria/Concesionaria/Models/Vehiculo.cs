using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Concesionaria.Models
{
    public class Vehiculo
    {
        [Key]
        public int Id { get; set; }
         
        [Required(ErrorMessage = "Ingrese la marca")]
        public String Marca { get; set; }

        [Required(ErrorMessage= "Ingrese el modelo")]
        public String Modelo { get; set; }

        [Required(ErrorMessage = "Ingrese el precio")]
        [Display(Name = "Precio venta")]
        [Range(1, 9999999, ErrorMessage = "Ingrese un precio mayor a 0 ")]
        public int PrecioVenta { get; set; }

        [Required(ErrorMessage = "Ingrese el color")]
        public String Color { get; set; }

        [Required(ErrorMessage = "Ingrese el año")]
        [Range(1950, 2022, ErrorMessage = "Ingrese año entre 1950 y 2022 ")]

        public int Año { get; set; }

        [Required(ErrorMessage = "Ingresen los Kilometros")]
        [Range(0, 999999, ErrorMessage = "Ingrese kilometraje correcto")]

        public int Kilometros { get; set; }

        [Required]
        [Display(Name = "Vehiculo vendido")]
        public Boolean FueVendido { get; set; }

        [Required(ErrorMessage = "Ingrese la ruta de la imagen")]
        public String RutaImagen { get; set; }

        [Display(Name = "Tipo")]
        [EnumDataType(typeof(TipoVehiculo))]
        public TipoVehiculo TipoAuto { get; set; }
 

      

    }
}
