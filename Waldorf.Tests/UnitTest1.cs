using System;
using System.Linq;
using System.Data.Entity;
using System.Configuration;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Waldorf.Domain;
using Waldorf.DataModel;
using Waldorf.Domain.Enums;

namespace Waldorf.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Config_Section_Test()
        {
            var cacheServerConfiguration = (CacheServerConfiguration)ConfigurationManager.GetSection("CacheServerConfiguration");
        }

        [TestMethod]
        public void Party_Select_Test()
        {
            using (var context = new WaldorfContext())
            {
                var parties = context.Parties.Where(p => p.FirstName == "Mason").Include(p => p.PartyTypes).Include("JobPositionsOfInterest.JobPositionTierOneCategory.JobPositionTierTwoCategory").AsNoTracking().ToList();
                foreach (var party in parties)
                {
                    var preferredName = party.PreferredName;
                    var partyTypes = party.PartyTypes;
                    var jobPositionsOfInterest = party.JobPositionsOfInterest;
                }
            }
        }

        [TestMethod]
        public void Party_Insert_Test()
        {
            var party = new Party
            {
                PartyStatusType = PartyStatusType.Pending,
                FirstName = "Megan",
                LastName = "Fox",
                EmailAddress = "mfox@yahoo.com",
                ZipCode = "92626",
                PreferredName = "Foxy Lady",
                DateCreated = DateTime.UtcNow
            };

            var partyTypes = new HashSet<PartyTypeWrapper>();
            partyTypes.Add(PartyType.Teacher);
            party.PartyTypes = partyTypes;

            var jobPositionsOfInterest = new HashSet<JobPositionWrapper>();

            /*
            jobPositionsOfInterest.Add(new JobPositionWrapper
            {
                JobPositionType = JobPositionType.LowerOrHighSchoolCoordinator
            });
            */

            jobPositionsOfInterest.Add(new JobPositionWrapper
            {
                JobPositionType = JobPositionType.HighSchoolTeacher,
                JobPositionTierOneCategory = new JobPositionTierOneCategory
                {
                    JobPositionTierOneCategoryType = JobPositionTierOneCategoryType.WorldLanguages,
                    JobPositionTierTwoCategory = new JobPositionTierTwoCategory
                    {
                        JobPositionTierTwoCategoryType = JobPositionTierTwoCategoryType.French
                    }
                }
            });

            party.JobPositionsOfInterest = jobPositionsOfInterest;

            using (var context = new WaldorfContext())
            {
                context.Parties.Add(party);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void School_Insert_Test()
        {
            var school = new School
            {
                SchoolStatusType = SchoolStatusType.Pending,
                Name = "Waldorf Garden Grove",
                Address = new Address
                {
                    Street = "153 Cool St.",
                    City = "Garden Grove",
                    State = "CA",
                    ZipCode = "92843",
                    Country = "USA"
                },
                PhoneNumber = "714-555-5555",
                EmailAddress = "admin@GGWaldorf.com",
                WebAddress = "http://www.GGWaldorf.com/",
                AwsnaAccreditationLevel = AwsnaAccreditationLevel.Accredited,
                YearFounded = 2016,
                Enrollment = 720,
                DateCreated = DateTime.UtcNow
            };

            var schoolDescriptionTypes = new HashSet<SchoolDescriptionTypeWrapper>();
            schoolDescriptionTypes.Add(SchoolDescriptionType.Nursery);
            schoolDescriptionTypes.Add(SchoolDescriptionType.PreK);
            schoolDescriptionTypes.Add(SchoolDescriptionType.Kindergarten);
            school.SchoolDescriptionTypes = schoolDescriptionTypes;

            using (var context = new WaldorfContext())
            {
                context.Schools.Add(school);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void PostedJobPosition_Insert_Admin_Test()
        {
            var postedJobPosition = new PostedJobPosition
            {
                PostedJobPositionStatusType = PostedJobPositionStatusType.Active,
                PartyType = PartyType.Administrator,
                EmploymentType = EmploymentType.SalariedFullTime,
                Title = "Development President",
                Description = "President of Development",
                Compensation = 153000,
                CompensationType = CompensationType.Annually,
                HasBenefits = true,
                Category = new PostedJobPositionCategory { JobPositionType = JobPositionType.DevelopmentDirector },
                DateCreated = DateTime.UtcNow
            };

            using (var context = new WaldorfContext())
            {
                var school = context.Schools.FirstOrDefault(p => p.Name == "Waldorf Garden Grove");
                school.PostedJobPositions.Add(postedJobPosition);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void PostedJobPosition_Insert_Teacher_Test()
        {
            var postedJobPosition = new PostedJobPosition
            {
                PostedJobPositionStatusType = PostedJobPositionStatusType.Active,
                PartyType = PartyType.Teacher,
                EmploymentType = EmploymentType.SalariedFullTime,
                Compensation = 45000,
                CompensationType = CompensationType.Annually,
                HasBenefits = true,
                DateCreated = DateTime.UtcNow
            };

            postedJobPosition.Category = new PostedJobPositionCategory
            {
                JobPositionType = JobPositionType.HighSchoolTeacher,
                JobPositionTierOneCategory = new JobPositionTierOneCategory
                {
                    JobPositionTierOneCategoryType = JobPositionTierOneCategoryType.WorldLanguages,
                    JobPositionTierTwoCategory = new JobPositionTierTwoCategory
                    {
                        JobPositionTierTwoCategoryType = JobPositionTierTwoCategoryType.French
                    }
                }
            };

            using (var context = new WaldorfContext())
            {
                var school = context.Schools.FirstOrDefault(p => p.Name == "Waldorf Garden Grove");
                school.PostedJobPositions.Add(postedJobPosition);
                context.SaveChanges();
            }
        }
    }
}
