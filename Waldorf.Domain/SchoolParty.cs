using System;
using System.ComponentModel.DataAnnotations;

namespace Waldorf.Domain
{
    public class SchoolParty
    {
        public long Id { get; set; }

        public int SchoolId { get; set; }

        [StringLength(128)]
        [Required]
        public string UserId { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
