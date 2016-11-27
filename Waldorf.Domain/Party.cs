﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Waldorf.Domain.Enums;

namespace Waldorf.Domain
{
    public class Party
    {
        public Party()
        {
            PartyTypes = new HashSet<PartyTypeWrapper>();
            JobPositionsOfInterest = new HashSet<JobPositionWrapper>();
            FavoritedPostedJobPositionIds = new HashSet<long>();
            Undergraduates = new HashSet<Undergraduate>();
            Graduates = new HashSet<Graduate>();
            StateCredentials = new HashSet<StateCredential>();
            OccupationalCertifications = new HashSet<OccupationalCertification>();
        }

        public long Id { get; set; }

        public PartyStatusType PartyStatusType { get; set; }

        [Display(Name = "First Name")]
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [EmailAddress]
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

        public ICollection<long> FavoritedPostedJobPositionIds { get; set; }

        public ICollection<Undergraduate> Undergraduates { get; set; }

        public ICollection<Graduate> Graduates { get; set; }

        public ICollection<StateCredential> StateCredentials { get; set; }

        public ICollection<OccupationalCertification> OccupationalCertifications { get; set; }
        
        [StringLength(75)]
        [Required]
        public string PreferredName { get; set; }

        [StringLength(100)]
        public string ProfileImageName { get; set; }

        public CreditCard CreditCard { get; set; }

        [StringLength(128)]
        [Required]
        public string UserId { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
