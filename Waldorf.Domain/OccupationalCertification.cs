using System.ComponentModel.DataAnnotations;
using Waldorf.Domain.Enums;

namespace Waldorf.Domain
{
    public class OccupationalCertification
    {
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public StateAbbreviation State { get; set; }

        [StringLength(100)]
        public string DocumentationFileName { get; set; }

        public long PartyId { get; set; }
    }
}  