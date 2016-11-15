using System.ComponentModel.DataAnnotations;

namespace Waldorf.Domain
{
    public enum JobPositionType
    {
        [Display(Name = @"Pre-School Lead Teacher")]
        PreSchoolLeadTeacher = 1,

        [Display(Name = @"Pre-School Assistant")]
        PreSchoolAssistant = 2,

        [Display(Name = @"Kindergarten Lead Teacher")]
        KindergartenLeadTeacher = 3,

        [Display(Name = @"Kindergarten Assistant")]
        KindergartenAssistant = 4,

        [Display(Name = @"Grades Lead Teacher")]
        GradesLeadTeacher = 5,

        [Display(Name = @"Grades Assistant")]
        GradesAssistant = 6,

        [Display(Name = @"High School Teacher")]
        HighSchoolTeacher = 7,

        [Display(Name = @"High School Assistant")]
        HighSchoolAssistant = 8,

        [Display(Name = @"Administrative Director")]
        AdministrativeDirector = 9,

        [Display(Name = @"Pedagogical Chair")]
        PedagogicalChair = 10,

        [Display(Name = @"Development Director")]
        DevelopmentDirector = 11,

        [Display(Name = @"Enrollment")]
        Enrollment = 12,

        [Display(Name = @"Registrar")]
        Registrar = 13,
        
        [Display(Name = @"Lower or High School Coordinator")]
        LowerOrHighSchoolCoordinator = 14,

        [Display(Name = @"Office Support")]
        OfficeSupport = 15,

        [Display(Name = @"Accounting/Finance")]
        AccountingFinance = 16
    }
}