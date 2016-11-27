using System.ComponentModel.DataAnnotations;
using Waldorf.Domain.Enums;

namespace Waldorf.Domain
{
    public class Undergraduate
    {
        [Display(Name = "Name of School")]
        [Required]
        [StringLength(50)]
        public string SchoolName { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        public StateAbbreviation State { get; set; }

        [Required]
        public DegreeType Degree { get; set; }

        [Required]
        [StringLength(100)]
        public string Major { get; set; }

        [StringLength(100)]
        public string Minor { get; set; }

        [StringLength(100)]
        public string TranscriptFileName { get; set; }
    }
}
