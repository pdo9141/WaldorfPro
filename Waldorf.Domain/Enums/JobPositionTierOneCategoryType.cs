using System.ComponentModel.DataAnnotations;

namespace Waldorf.Domain
{
    public enum JobPositionTierOneCategoryType
    {
        [Display(Name = @"Sciences")]
        Sciences = 1,

        [Display(Name = @"Humanities")]
        Humanities = 2,

        [Display(Name = @"Math")]
        Math = 3,

        [Display(Name = @"Technology")]
        Technology = 4,

        [Display(Name = @"World Languages")]
        WorldLanguages = 5,

        [Display(Name = @"Music")]
        Music = 6,

        [Display(Name = @"Practical/Fine/Performing Arts")]
        PracticalFinePerformingArts = 7,

        [Display(Name = @"Physical Education/Movement")]
        PhysicalEducationMovement = 8,

        [Display(Name = @"Eurhythmy")]
        Eurhythmy = 9
    }
}
