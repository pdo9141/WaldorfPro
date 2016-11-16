using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Waldorf.Domain
{
    public class Party
    {
        public Party()
        {
            PartyTypes = new HashSet<PartyTypeWrapper>();
            JobPositionsOfInterest = new HashSet<JobPositionWrapper>();
        }

        public long Id { get; set; }

        [Display(Name = "First Name")]
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        [Required]
        [StringLength(75)]
        public string EmailAddress { get; set; }

        [Display(Name = "ZIP Code")]
        [Required]
        [StringLength(10)]
        public string ZipCode { get; set; }

        public ICollection<PartyTypeWrapper> PartyTypes { get; set; }

        public ICollection<JobPositionWrapper> JobPositionsOfInterest { get; set; }

        [StringLength(75)]
        [Required]
        public string PreferredName { get; set; }

        [StringLength(100)]
        public string ProfileImageName { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
