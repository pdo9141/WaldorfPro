using System.ComponentModel.DataAnnotations;
using Waldorf.Domain.Enums;

namespace Waldorf.Domain
{
    public class OccupationalCertification
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public StateAbbreviation State { get; set; }

        [StringLength(100)]
        public string DocumentationFileName { get; set; }
    }
}  