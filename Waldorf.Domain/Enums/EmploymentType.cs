using System.ComponentModel.DataAnnotations;

namespace Waldorf.Domain.Enums
{
    public enum EmploymentType
    {
        [Display(Name = @"Salaried/Full-time")]
        SalariedFullTime = 1,

        [Display(Name = @"Hourly")]
        Hourly = 2,

        [Display(Name = @"Part-time")]
        PartTime = 3,

        [Display(Name = @"Volunteer Internship")]
        VolunteerInternship = 4,

        [Display(Name = @"Contract")]
        Contract = 5,

        [Display(Name = @"Other")]
        Other = 6
    }
}