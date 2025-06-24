using dotnet_mvc_car_wash.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace dotnet_mvc_car_wash.Models
{
    public class Lavado
    {
        [Required]
        [Display(Name = "ID de Lavado")]
        public string IdLavado { get; set; }

        [Required]
        [Display(Name = "Placa del Vehículo")]
        public string PlacaVehiculo { get; set; }

        [Required]
        [Display(Name = "ID del Cliente")]
        public string IdCliente { get; set; }

        [Required]
        [Display(Name = "ID del Empleado")]
        public string IdEmpleado { get; set; }

        [Required]
        [Display(Name = "Tipo de Lavado")]
        public TipoLavado TipoLavado { get; set; }

        [Display(Name = "Precio Base")]
        public decimal PrecioBase { get; set; }

        [Display(Name = "Precio A Convenir")]
        public decimal? PrecioAConvenir { get; set; }

        [Display(Name = "IVA (13%)")]
        public decimal IVA { get; set; }

        [Display(Name = "Precio Total")]
        public decimal PrecioTotal { get; set; }

        [Required]
        [Display(Name = "Estado del Lavado")]
        public EstadoLavado EstadoLavado { get; set; }

        [Display(Name = "Fecha de Creación")]
        public DateTime FechaCreacion { get; set; }

        [Display(Name = "Observaciones")]
        public string? Observaciones { get; set; }

        public Lavado()
        {
            FechaCreacion = DateTime.Now;
            EstadoLavado = EstadoLavado.Agendado;
        }

        public void CalcularPrecios()
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