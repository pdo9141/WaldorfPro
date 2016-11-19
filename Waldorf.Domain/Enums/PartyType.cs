using System.ComponentModel.DataAnnotations;

namespace Waldorf.Domain.Enums
{
    public enum PartyType
    {
        [Display(Name = @"Teacher")]
        Teacher = 1,

        [Display(Name = @"Administrator")]
        Administrator = 2,

        [Display(Name = @"I don't know yet. This is new to me.")]
        Unknown = 3
    }
}
