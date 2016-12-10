using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Waldorf.Domain.Enums;

namespace Waldorf.Domain
{
    public class PostedJobPosition
    {
        public PostedJobPosition()
        {
            FavoritedParties = new HashSet<FavoritedParty>();            
        }

        public long Id { get; set; }

        public int SchoolId { get; set; }

        public PostedJobPositionStatusType PostedJobPositionStatusType { get; set; }

        public PartyType PartyType { get; set; }

        public EmploymentType EmploymentType { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public decimal Compensation { get; set; }

        public CompensationType CompensationType { get; set; }

        public bool HasBenefits { get; set; }

        public DateTime StartDate { get; set; }

        public PostedJobPositionCategory Category { get; set; }

        public ICollection<FavoritedParty> FavoritedParties { get; set; }

        public DateTime? DateFilled { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
