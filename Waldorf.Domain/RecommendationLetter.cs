using System;
using System.ComponentModel.DataAnnotations;

namespace Waldorf.Domain
{
    public class RecommendationLetter
    {
        public long Id { get; set; }

        [StringLength(100)]
        public string FileName { get; set; }

        public long PartyId { get; set; }
    }
}
