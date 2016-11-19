using System.ComponentModel.DataAnnotations;

namespace Waldorf.Domain.Enums
{
    public enum AwsnaAccreditationLevel
    {
        [Display(Name = @"Full Member")]
        FullMember = 1,

        [Display(Name = @"Accredited")]
        Accredited = 2,

        [Display(Name = @"Candidate")]
        Candidate = 3,

        [Display(Name = @"Developing")]
        Developing = 4,

        [Display(Name = @"Other")]
        Other = 5
    }
}
