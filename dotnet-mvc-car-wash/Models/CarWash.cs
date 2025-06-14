using System.ComponentModel.DataAnnotations;

namespace dotnet_mvc_car_wash.Models
{
    public class CarWash
    {
        [Required]
        [Display(Name = "Wash ID")]
        public int WashId { get; set; }

        [Required]
        [Display(Name = "Vehicle License Plate")]
        public string VehicleLicensePlate { get; set; }

        [Required]
        [Display(Name = "Customer ID")]
        public string CustomerId { get; set; }

        [Required]
        [Display(Name = "Employee ID")]
        public string EmployeeId { get; set; }

        [Required]
        [Display(Name = "Wash Type")]
        public WashType WashType { get; set; }

        [Display(Name = "Base Price")]
        public decimal BasePrice { get; set; }

        [Display(Name = "IVA (13%)")]
        public decimal IVA { get; set; }

        [Display(Name = "Total Price")]
        public decimal TotalPrice { get; set; }

        [Required]
        [Display(Name = "Wash Status")]
        public WashStatus Status { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
    }
}
