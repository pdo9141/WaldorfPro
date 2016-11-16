using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Waldorf.Domain;
using Waldorf.DataModel;

namespace Waldorf.Tests
{
    [TestClass]
    public class UnitTest1
    {
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
    }
}
