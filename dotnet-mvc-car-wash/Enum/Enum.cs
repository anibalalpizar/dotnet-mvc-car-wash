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

    public enum WashStatus
    {
        [Display(Name = "In Process")]
        InProgress,
        Billed,
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