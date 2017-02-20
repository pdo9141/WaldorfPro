using System.ComponentModel.DataAnnotations;

namespace Waldorf.Domain.Enums
{
    public enum PostedJobPositionStatusType
    {
        [Display(Name = @"Active")]
        Active = 1,

        [Display(Name = @"Filled")]
        Filled = 2
    }
}
