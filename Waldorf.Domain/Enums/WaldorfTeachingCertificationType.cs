using System.ComponentModel.DataAnnotations;

namespace Waldorf.Domain.Enums
{
    public enum WaldorfTeachingCertificationType
    {
        [Display(Name = @"Administrator")]
        Administrator = 1,

        [Display(Name = @"Early Childhood Teaching")]
        EarlyChildhoodTeaching = 2,

        [Display(Name = @"Grades Teaching")]
        GradesTeaching = 3,

        [Display(Name = @"High School Teaching")]
        HighSchoolTeaching = 4,

        [Display(Name = @"MA, Waldorf Education")]
        MAWaldorfEducation = 5,

        [Display(Name = @"Specialty Teaching")]
        SpecialtyTeaching = 6
    }
}

