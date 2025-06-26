using dotnet_mvc_car_wash.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace dotnet_mvc_car_wash.Models
{
    public class Lavado
    {
        [Required]
        [Display(Name = "Car Wash ID")]
        public string IdLavado { get; set; }

        [Required]
        [Display(Name = "Vehicle License Plate")]
        public string PlacaVehiculo { get; set; }

        [Required]
        [Display(Name = "Client ID")]
        public string IdCliente { get; set; }

        [Required]
        [Display(Name = "Employee ID")]
        public string IdEmpleado { get; set; }

        [Required]
        [Display(Name = "Wash Type")]
        public TipoLavado TipoLavado { get; set; }

        [Display(Name = "Base Price")]
        public decimal PrecioBase { get; set; }

        [Display(Name = "Price to Agree")]
        public decimal? PrecioAConvenir { get; set; }

        [Display(Name = "IVA (13%)")]
        public decimal IVA { get; set; }

        [Display(Name = "Total Price")]
        public decimal PrecioTotal { get; set; }

        [Required]
        [Display(Name = "Wash Status")]
        public EstadoLavado EstadoLavado { get; set; }

        [Display(Name = "Creation Date")]
        public DateTime FechaCreacion { get; set; }

        [Display(Name = "Observations")]
        public string? Observaciones { get; set; }

        public Lavado()
        {
            FechaCreacion = DateTime.Now;
            EstadoLavado = EstadoLavado.Agendado;
        }

        public void CalculatePrices()
        {
            if (TipoLavado == TipoLavado.LaJoya)
            {
                PrecioBase = PrecioAConvenir ?? 0m;
            }
            else
            {
                PrecioBase = TipoLavado switch
                {
                    TipoLavado.Basico => 8000m,
                    TipoLavado.Premium => 12000m,
                    TipoLavado.Deluxe => 20000m,
                    _ => 0m
                };
            }

            IVA = PrecioBase * 0.13m;
            PrecioTotal = PrecioBase + IVA;
        }

        public string GetTipoLavadoDescripcion()
        {
            return TipoLavado switch
            {
                TipoLavado.Basico => "Lavado, aspirado y encerado",
                TipoLavado.Premium => "Lavado, aspirado y encerado y limpieza profunda de asientos",
                TipoLavado.Deluxe => "Lavado, aspirado y encerado, limpieza profunda de asientos, corrección de pintura. Opción productos para lavado con tratamiento nanocerámico",
                TipoLavado.LaJoya => "Incluye todo más detalles a convenir, pulidos, tratamientos hidrofóbicos, entre otros",
                _ => "Descripción no disponible"
            };
        }
    }
}