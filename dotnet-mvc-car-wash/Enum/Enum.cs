using System.ComponentModel.DataAnnotations;

public enum WashPreference
{
    [Display(Name = "Weekly")]
    Weekly,
    [Display(Name = "Biweekly")]
    Biweekly,
    [Display(Name = "Monthly")]
    Monthly,
    [Display(Name = "Other")]
    Other
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