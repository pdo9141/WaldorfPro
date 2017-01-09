using System.ComponentModel.DataAnnotations;

namespace Waldorf.Web.ViewModels.Colleague
{
    public class StepOneViewModel
    {
        [Display(Name = "First name:")]
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Last name:")]
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [EmailAddress]
        [Display(Name = "Email:")]
        [Required]
        [StringLength(75)]
        public string EmailAddress { get; set; }

        [EmailAddress]
        [Display(Name = "Confirm your email:")]
        [Required]
        [StringLength(75)]
        public string ConfirmEmailAddress { get; set; }

        [Display(Name = "Zip Code:")]
        [Required]
        [StringLength(10)]
        public string ZipCode { get; set; }
    }
}