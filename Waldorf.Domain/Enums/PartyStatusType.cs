using System.ComponentModel.DataAnnotations;

namespace Waldorf.Domain.Enums
{
    public enum PartyStatusType
    {
        [Display(Name = @"Active")]
        Active = 1,

        [Display(Name = @"Pending")]
        Pending = 2
    }
}
