using System.ComponentModel.DataAnnotations;

namespace Waldorf.Domain.Enums
{
    public enum PartyType
    {
        [Display(Name = @"Teacher")]
        Teacher = 1,

        [Display(Name = @"Administrator")]
        Administrator = 2
    }
}
