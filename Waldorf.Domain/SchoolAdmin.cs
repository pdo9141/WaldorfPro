using System;
using System.ComponentModel.DataAnnotations;

namespace Waldorf.Domain
{
    public class SchoolAdmin
    {
        public long Id { get; set; }

        public School School { get; set; }

        [StringLength(128)]
        [Required]
        public string UserId { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
