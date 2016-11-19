using System.ComponentModel.DataAnnotations;

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
        [StringLength(2)]
        public string State { get; set; }
        
        [Display(Name = "ZIP Code")]
        [Required]
        [StringLength(10)]
        public string ZipCode { get; set; }

        [StringLength(75)]
        public string Country { get; set; }
    }
}
