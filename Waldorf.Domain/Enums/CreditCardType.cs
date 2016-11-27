using System.ComponentModel.DataAnnotations;

namespace Waldorf.Domain.Enums
{
    public enum CreditCardType
    {
        [Display(Name = @"Visa")]
        Visa = 1,

        [Display(Name = @"MasterCard")]
        MasterCard = 2,

        [Display(Name = @"American Express")]
        AmericanExpress = 3,

        [Display(Name = @"Diners Club")]
        DinersClub = 4,

        [Display(Name = @"Discover")]
        Discover = 5,

        [Display(Name = @"JCB")]
        JCB = 6
    }
}
