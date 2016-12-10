using System;
using System.Linq;
using System.Diagnostics;
using System.Data.Entity;
using System.Configuration;
using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Waldorf.Domain;
using Waldorf.DataModel;
using Waldorf.Domain.Enums;
using Waldorf.Common.Security;

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
        public void EncryptionHelper_Test()
        {
            string plain = "1111222233334444";
            string encrypted = EncryptionHelper.Encrypt<RijndaelManaged>(plain, "password", "salt");
            string decrypted = EncryptionHelper.Decrypt<RijndaelManaged>(encrypted, "password", "salt");
        }

        [TestMethod]
        public void Party_Select_EagerLoad_Test()
        {
            using (var context = new WaldorfContext())
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                context.Configuration.ProxyCreationEnabled = false; // When using Include, no proxies are required.
                var parties = context.Parties.Where(p => p.FirstName == "Megan")
                    .Include(p => p.PartyTypes)
                    .Include(p => p.Graduates)
                    .Include(p => p.Undergraduates)
                    .Include(p => p.StateCredentials)
                    .Include(p => p.WaldorfTeachingCertifications)
                    .Include(p => p.OccupationalCertifications)
                    .Include("JobPositionsOfInterest.JobPositionTierOneCategory.JobPositionTierTwoCategory").AsNoTracking().ToList();

                sw.Stop();
                Console.WriteLine("Query with include: {0}", sw.ElapsedMilliseconds);

                /*
                foreach (var party in parties)
                {
                    var preferredName = party.PreferredName;
                    var partyTypes = party.PartyTypes;
                    var jobPositionsOfInterest = party.JobPositionsOfInterest;
                }
                */
            }
        }

        [TestMethod]
        public void Party_Select_ExplicitLoad_Test()
        {
            using (var context = new WaldorfContext())
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                var query = context.Parties.Where(p => p.FirstName == "Megan")
                    .Include(p => p.PartyTypes)
                    .Include("JobPositionsOfInterest.JobPositionTierOneCategory.JobPositionTierTwoCategory");

                query.SelectMany(p => p.Graduates).Load();
                query.SelectMany(p => p.Undergraduates).Load();
                query.SelectMany(p => p.StateCredentials).Load();
                query.SelectMany(p => p.WaldorfTeachingCertifications).Load();
                query.SelectMany(p => p.OccupationalCertifications).Load();
                
                var parties = query.AsNoTracking().ToList();

                sw.Stop();
                Console.WriteLine("Query with include selectmany: {0}", sw.ElapsedMilliseconds);
            }
        }

        [TestMethod]
        public void Party_Insert_Teacher_Test()
        {
            var party = new Party
            {
                PartyStatusType = PartyStatusType.Pending,
                FirstName = "Megan",
                LastName = "Fox",
                EmailAddress = "mfox@yahoo.com",
                ZipCode = "92626",
                PreferredName = "Foxy Lady",
                DateCreated = DateTime.UtcNow,
                WaldorfTranscriptFileName = String.Format("WaldorfTranscript_{0}.pdf", Guid.NewGuid()),
                ProfileImageName = String.Format("ProfileImage_{0}.jpg", Guid.NewGuid()),
                UserId = "1",
                AllowSchoolMatchWithoutApproval = false
            };

            #region Add Party Type
            var partyTypes = new HashSet<PartyTypeWrapper>();
            partyTypes.Add(PartyType.Teacher);
            party.PartyTypes = partyTypes;
            #endregion

            #region Add Positions of Interest
            var jobPositionsOfInterest = new HashSet<JobPositionWrapper>();
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
            #endregion

            #region Add Favorited Posted Job Positions
            #endregion

            #region Approved Match Posted Job Positions
            #endregion

            #region Undergraduates
            var undergraduates = new HashSet<Undergraduate>();
            undergraduates.Add(new Undergraduate
            {
                SchoolName = "UCLA",
                City = "Los Angeles",
                State = StateAbbreviation.CA,
                Degree = DegreeType.BS,
                Major = "Finance",
                Minor = "Photography",
                TranscriptFileName = String.Format("Transcript_{0}.pdf", Guid.NewGuid())
            });
            party.Undergraduates = undergraduates;
            #endregion

            #region Graduates
            var graduates = new HashSet<Graduate>();
            graduates.Add(new Graduate
            {
                SchoolName = "UCI",
                City = "Irvine",
                State = StateAbbreviation.CA,
                DegreeEmphasis = "International Finance",
                TranscriptFileName = String.Format("Transcript_{0}.pdf", Guid.NewGuid())
            });
            party.Graduates = graduates;

            #endregion

            #region State Credentials
            var stateCredentials = new HashSet<StateCredential>();
            stateCredentials.Add(new StateCredential
            {
                Name = "Superfly State Credential",
                State = StateAbbreviation.CA,
                DocumentationFileName = String.Format("Documentation_{0}.pdf", Guid.NewGuid())
            });
            party.StateCredentials = stateCredentials;
            #endregion

            #region Occupational Certifications
            var occupationalCertifications = new HashSet<OccupationalCertification>();
            occupationalCertifications.Add(new OccupationalCertification
            {
                Name = "Shipping Occupational Cert",
                State = StateAbbreviation.CA,
                DocumentationFileName = String.Format("Documentation_{0}.pdf", Guid.NewGuid())
            });
            party.OccupationalCertifications = occupationalCertifications;

            #endregion

            #region Waldorf Teaching Certifications
            var waldorfTeachingCertifications = new HashSet<WaldorfTeachingCertificationTypeWrapper>();
            waldorfTeachingCertifications.Add(new WaldorfTeachingCertificationTypeWrapper { WaldorfTeachingCertificationType = WaldorfTeachingCertificationType.GradesTeaching });
            waldorfTeachingCertifications.Add(new WaldorfTeachingCertificationTypeWrapper { WaldorfTeachingCertificationType = WaldorfTeachingCertificationType.EarlyChildhoodTeaching });
            party.WaldorfTeachingCertifications = waldorfTeachingCertifications;
            #endregion

            #region Recommendation Letters
            var recommendationLetters = new HashSet<RecommendationLetter>();
            recommendationLetters.Add(new RecommendationLetter { FileName = String.Format("Recommendation_{0}.pdf", Guid.NewGuid()) });
            recommendationLetters.Add(new RecommendationLetter { FileName = String.Format("Recommendation_{0}.pdf", Guid.NewGuid()) });
            party.RecommendationLetters = recommendationLetters;
            #endregion

            #region Evaluations
            var evaluations = new HashSet<Evaluation>();
            evaluations.Add(new Evaluation { FileName = String.Format("Evaluation_{0}.pdf", Guid.NewGuid()) });
            evaluations.Add(new Evaluation { FileName = String.Format("Evaluation_{0}.pdf", Guid.NewGuid()) });
            party.Evaluations = evaluations;
            #endregion

            #region Credit Card
            party.CreditCard = new CreditCard
            {
                CreditCardStatusType = CreditCardStatusType.Active,
                CreditCardType = CreditCardType.MasterCard,
                Number = EncryptionHelper.Encrypt<RijndaelManaged>("1111222233334444", "password", "salt"),
                CVVNumber = EncryptionHelper.Encrypt<RijndaelManaged>("123", "password", "salt"),
                ExpirationMonth = EncryptionHelper.Encrypt<RijndaelManaged>("10", "password", "salt"),
                ExpirationYear = EncryptionHelper.Encrypt<RijndaelManaged>("2017", "password", "salt"),
                HolderFirstName = EncryptionHelper.Encrypt<RijndaelManaged>("Phillip", "password", "salt"),
                HolderLastName = EncryptionHelper.Encrypt<RijndaelManaged>("Do", "password", "salt"),
                HolderMiddleName = EncryptionHelper.Encrypt<RijndaelManaged>("Hung", "password", "salt"),
            };
            #endregion
            
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
                    State = StateAbbreviation.CA,
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
