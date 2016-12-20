using System;
using System.Linq;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Waldorf.DataModel;

namespace Waldorf.Tests
{
    [TestClass]
    public class MatchQueriesTests
    {
        [TestMethod]
        public void MatchQueries_JobPosition_Colleague_Test()
        {
            using (var context = new WaldorfContext())
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                var postedJobPositionId = 5;
                var parties = 
                    (from pjp in context.PostedJobPositions
                     from p in context.Parties
                     where pjp.Id == postedJobPositionId                    
                     && (p.AllowSchoolMatchWithoutApproval == true || p.ApprovedMatchPostedJobPositions.Any(ampjp => ampjp.PostedJobPositionId == postedJobPositionId))
                     && p.JobPositionsOfInterest.Any(jpoi => jpoi.JobPositionType == pjp.Category.JobPositionType 
                        && jpoi.JobPositionTierOneCategory.JobPositionTierOneCategoryType == pjp.Category.JobPositionTierOneCategory.JobPositionTierOneCategoryType
                        && jpoi.JobPositionTierOneCategory.JobPositionTierTwoCategory.JobPositionTierTwoCategoryType == pjp.Category.JobPositionTierOneCategory.JobPositionTierTwoCategory.JobPositionTierTwoCategoryType)
                    select p).ToList();
                
                sw.Stop();
                Console.WriteLine("JobPosition/Colleague match took: {0}", sw.ElapsedMilliseconds);

                foreach (var party in parties)
                {
                    var preferredName = party.PreferredName;
                    var partyTypes = party.PartyTypes;
                    var jobPositionsOfInterest = party.JobPositionsOfInterest;
                }                
            }
        }

        [TestMethod]
        public void MatchQueries_Colleague_JobPosition_Test()
        {
            using (var context = new WaldorfContext())
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                var partyId = 1;
                var postedJobPositions =
                    (from pjp in context.PostedJobPositions
                     from p in context.Parties                                       
                     where p.Id == partyId
                     && p.JobPositionsOfInterest.Any(jpoi => jpoi.JobPositionType == pjp.Category.JobPositionType
                        && jpoi.JobPositionTierOneCategory.JobPositionTierOneCategoryType == pjp.Category.JobPositionTierOneCategory.JobPositionTierOneCategoryType
                        && jpoi.JobPositionTierOneCategory.JobPositionTierTwoCategory.JobPositionTierTwoCategoryType == pjp.Category.JobPositionTierOneCategory.JobPositionTierTwoCategory.JobPositionTierTwoCategoryType)
                     select pjp).ToList();

                sw.Stop();
                Console.WriteLine("Colleague/JobPosition match took: {0}", sw.ElapsedMilliseconds);

                foreach (var postedJobPosition in postedJobPositions)
                {
                    var title = postedJobPosition.Title;
                    var compensation = postedJobPosition.Compensation;
                }
            }
        }
    }
}
