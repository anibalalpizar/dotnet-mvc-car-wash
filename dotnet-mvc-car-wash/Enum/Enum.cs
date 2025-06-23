using System.ComponentModel.DataAnnotations;

namespace dotnet_mvc_car_wash.Models.Enums
{
    public enum TipoLavado
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

    public enum WashType
    {
        [Display(Name = "Basic")]
        Basic = 8000,
        [Display(Name = "Premium")]
        Premium = 12000,
        [Display(Name = "Deluxe")]
        Deluxe = 20000,
        [Display(Name = "La Joya")]
        LaJoya = 0
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