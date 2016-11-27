using System.ComponentModel.DataAnnotations;
using Waldorf.Domain.Enums;

namespace Waldorf.Domain
{
    public class CreditCard
    {
        public long Id { get; set; }

        public CreditCardStatusType CreditCardStatusType { get; set; }

        public CreditCardType CreditCardType { get; set; }

        [StringLength(300)]
        public string Number { get; set; }

        [StringLength(100)]
        public string CVVNumber { get; set; }

        [StringLength(100)]
        public string ExpirationMonth { get; set; }

        [StringLength(100)]
        public string ExpirationYear { get; set; }

        [StringLength(500)]
        public string HolderFirstName { get; set; }

        [StringLength(500)]
        public string HolderMiddleName { get; set; }

        [StringLength(500)]
        public string HolderLastName { get; set; }
    }
}
