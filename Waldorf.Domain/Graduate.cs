using System.ComponentModel.DataAnnotations;
using Waldorf.Domain.Enums;

namespace Waldorf.Domain
{
    public class Graduate
    {
        public long Id { get; set; }

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
        [StringLength(100)]
        public string DegreeEmphasis { get; set; }

        [StringLength(100)]
        public string TranscriptFileName { get; set; }
    }
}
