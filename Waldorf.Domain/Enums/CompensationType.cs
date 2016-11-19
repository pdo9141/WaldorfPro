using System.ComponentModel.DataAnnotations;

namespace Waldorf.Domain.Enums
{
    public enum CompensationType
    {
        [Display(Name = @"Hourly")]
        Hourly = 1,

        [Display(Name = @"Annually")]
        Annually = 2
    }
}
