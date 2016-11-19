using System.ComponentModel.DataAnnotations;

namespace Waldorf.Domain.Enums
{
    public enum SchoolDescriptionType
    {
        [Display(Name = @"Nursery")]
        Nursery = 1,

        [Display(Name = @"Pre-K")]
        PreK = 2,

        [Display(Name = @"Kindergarten")]
        Kindergarten = 3,

        [Display(Name = @"Lower School (1-5)")]
        LowerSchool = 4,

        [Display(Name = @"Middle School (6-8)")]
        MiddleSchool = 5,

        [Display(Name = @"High School (9-12)")]
        HighSchool = 6,

        [Display(Name = @"Other")]
        Other = 7
    }
}
