using System.ComponentModel.DataAnnotations;

namespace Waldorf.Domain.Enums
{
    public enum JobPositionTierTwoCategoryType
    {
        [Display(Name = @"Spanish")]
        Spanish = 1,

        [Display(Name = @"German")]
        German = 2,

        [Display(Name = @"French")]
        French = 3,

        [Display(Name = @"Mandarin")]
        Mandarin = 4,

        [Display(Name = @"Japanese")]
        Japanese = 5,

        [Display(Name = @"Other")]
        Other = 6
    }
}
