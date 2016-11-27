using System.ComponentModel.DataAnnotations;
using Waldorf.Domain.Enums;

namespace Waldorf.Domain
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Street { get; set; }

        [StringLength(50)]
        public string Street2 { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        public StateAbbreviation State { get; set; }

        [Display(Name = "ZIP Code")]
        [Required]
        [StringLength(10)]
        public string ZipCode { get; set; }

        [StringLength(75)]
        public string Country { get; set; }
    }
}
