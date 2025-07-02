using System.ComponentModel.DataAnnotations;

namespace dotnet_mvc_car_wash.Models.Enums
{
    public enum WashType
    {
        [Display(Name = "Básico")]
        Basico,
        Premium,
        Deluxe,
        [Display(Name = "La Joya")]
        LaJoya
    }

    public enum EstadoLavado
    {
        [Display(Name = "En Proceso")]
        EnProceso,
        Facturado,
        Agendado
    }

    public enum WashStatus
    {
        [Display(Name = "In Process")]
        InProcess,
        [Display(Name = "Billed")]
        Billed,
        [Display(Name = "Scheduled")]
        Scheduled
    }

    public enum WashPreference
    {
        [Display(Name = "Semanal")]
        Semanal,
        [Display(Name = "Quincenal")]
        Quincenal,
        [Display(Name = "Mensual")]
        Mensual,
        [Display(Name = "Otro")]
        Otro
    }
}