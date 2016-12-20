using System;
using System.ComponentModel.DataAnnotations;

namespace Waldorf.Domain
{
    public class Experience
    {
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Institution { get; set; }

        [Required]
        [StringLength(50)]
        public string Position { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [StringLength(1000)]
        public string ResponsibilitiesDuties { get; set; }

        public long PartyId { get; set; }
    }
}
