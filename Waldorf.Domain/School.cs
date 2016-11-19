using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Waldorf.Domain.Enums;

namespace Waldorf.Domain
{
    public class School
    {
        public School()
        {
            SchoolDescriptionTypes = new HashSet<SchoolDescriptionTypeWrapper>();
            PostedJobPositions = new HashSet<PostedJobPosition>();
        }

        public int Id { get; set; }

        public SchoolStatusType SchoolStatusType { get; set; }

        [Display(Name = "Name of School")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public Address Address { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        [Display(Name = "Email Address")]
        [StringLength(75)]
        public string EmailAddress { get; set; }

        [Url]
        [Display(Name = "Website Address")]
        [StringLength(100)]
        public string WebAddress { get; set; }

        public AwsnaAccreditationLevel AwsnaAccreditationLevel { get; set; }

        public short YearFounded { get; set; }

        public int Enrollment { get; set; }

        public ICollection<SchoolDescriptionTypeWrapper> SchoolDescriptionTypes { get; set; }

        public ICollection<PostedJobPosition> PostedJobPositions { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
