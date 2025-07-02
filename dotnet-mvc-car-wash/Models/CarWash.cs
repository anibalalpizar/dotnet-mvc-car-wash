using dotnet_mvc_car_wash.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace dotnet_mvc_car_wash.Models
{
    public class CarWash
    {
        [Required]
        [Display(Name = "Car Wash ID")]
        public string IdCarWash { get; set; }

        [Required]
        [Display(Name = "Vehicle License Plate")]
        public string VehicleLicensePlate { get; set; }

        [Required]
        [Display(Name = "Client ID")]
        public string IdClient { get; set; }

        [Required]
        [Display(Name = "Employee ID")]
        public string IdEmployee { get; set; }

        [Required]
        [Display(Name = "Wash Type")]
        public WashType WashType { get; set; }

        [Display(Name = "Base Price")]
        public decimal BasePrice { get; set; }

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

        public CarWash()
        {
            FechaCreacion = DateTime.Now;
            EstadoLavado = EstadoLavado.Agendado;
        }

        public void CalculatePrices()
        {
            if (WashType == WashType.LaJoya)
            {
                BasePrice = PrecioAConvenir ?? 0m;
            }
            else
            {
                BasePrice = WashType switch
                {
                    WashType.Basico => 8000m,
                    WashType.Premium => 12000m,
                    WashType.Deluxe => 20000m,
                    _ => 0m
                };
            }

            IVA = BasePrice * 0.13m;
            PrecioTotal = BasePrice + IVA;
        }

        public string GetTipoLavadoDescripcion()
        {
            return WashType switch
            {
                WashType.Basico => "Lavado, aspirado y encerado",
                WashType.Premium => "Lavado, aspirado y encerado y limpieza profunda de asientos",
                WashType.Deluxe => "Lavado, aspirado y encerado, limpieza profunda de asientos, corrección de pintura. Opción productos para lavado con tratamiento nanocerámico",
                WashType.LaJoya => "Incluye todo más detalles a convenir, pulidos, tratamientos hidrofóbicos, entre otros",
                _ => "Descripción no disponible"
            };
        }
    }
}