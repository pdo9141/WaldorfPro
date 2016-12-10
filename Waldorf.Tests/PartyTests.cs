using System;
using System.Linq;
using System.Diagnostics;
using System.Data.Entity;
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
    public class PartyTests
    {
        [TestMethod]
        public void Party_Select_EagerLoad_Test()
        {
            using (var context = new WaldorfContext())
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                context.Configuration.ProxyCreationEnabled = false; // When using Include, no proxies are required.
                var parties = context.Parties.Where(p => p.FirstName == "Megan")
                    .Include(p => p.CreditCard)
                    .Include(p => p.PartyTypes)
                    .Include(p => p.Graduates)
                    .Include(p => p.Undergraduates)
                    .Include(p => p.StateCredentials)
                    .Include(p => p.WaldorfTeachingCertifications)
                    .Include(p => p.OccupationalCertifications)
                    .Include("JobPositionsOfInterest.JobPositionTierOneCategory.JobPositionTierTwoCategory").AsNoTracking().ToList();

                sw.Stop();
                Console.WriteLine("Query with eager load: {0}", sw.ElapsedMilliseconds);

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

                /*
                var party = context.Parties.Find(1);
                context.Entry(party).Reference(p => p.CreditCard).Load();
                context.Entry(party).Collection(p => p.Graduates).Load();
                context.Entry(party).Collection(p => p.Undergraduates).Load();
                context.Entry(party).Collection(p => p.StateCredentials).Load();
                context.Entry(party).Collection(p => p.WaldorfTeachingCertifications).Load();
                context.Entry(party).Collection(p => p.OccupationalCertifications).Load();
                */

                var parties = context.Parties.Where(p => p.FirstName == "Megan")
                    .Include(p => p.PartyTypes)
                    .Include("JobPositionsOfInterest.JobPositionTierOneCategory.JobPositionTierTwoCategory").ToList();

                foreach (var party in parties)
                {
                    context.Entry(party).Reference(p => p.CreditCard).Load();
                    context.Entry(party).Collection(p => p.Graduates).Load();
                    context.Entry(party).Collection(p => p.Undergraduates).Load();
                    context.Entry(party).Collection(p => p.StateCredentials).Load();
                    context.Entry(party).Collection(p => p.WaldorfTeachingCertifications).Load();
                    context.Entry(party).Collection(p => p.OccupationalCertifications).Load();
                }
                
                sw.Stop();
                Console.WriteLine("Query with explicit load: {0}", sw.ElapsedMilliseconds);
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
        
        private void BenchmarkQueries()
        {
            /*
            Benchmark("Load with include", () =>
            {
                using (var db = new gmokContext())
                {
                    var contacts = db.ContactInformations.Include(x => x.ContactInformationMails).Include(x => x.ContactInformationPhonenumbers).AsNoTracking().ToList();
                }
            });

            Benchmark("Load separate and fix", () =>
            {
                using (var db = new gmokContext())
                {
                    var contacts = db.ContactInformations.AsNoTracking().ToList();
                    var phones = db.ContactInformationPhonenumbers.AsNoTracking().ToLookup(x => x.ContactInformationID);
                    var mails = db.ContactInformationMails.AsNoTracking().ToLookup(x => x.ContactInformationID);

                    foreach (var c in contacts)
                    {
                        c.ContactInformationMails = mails.Contains(c.ID) ? mails[c.ID].ToList() : new List<ContactInformationMail>();
                        c.ContactInformationPhonenumbers = phones.Contains(c.ID) ? phones[c.ID].ToList() : new List<ContactInformationPhonenumber>();
                    }
                }
            });

            Benchmark("Load separate as batch", () =>
            {
                using (var db = new gmokContext())
                {
                    var cmd = db.Database.Connection.CreateCommand();

                    Benchmark("generate sql", () =>
                    {
                        var csql = db.ContactInformations.ToString();
                        var psql = db.ContactInformationPhonenumbers.ToString();
                        var msql = db.ContactInformationMails.ToString();

                        cmd.CommandText =
                            csql + ";" + Environment.NewLine + Environment.NewLine +
                            psql + ";" + Environment.NewLine + Environment.NewLine +
                            msql + ";";

                    });


                    db.Database.Connection.Open();
                    // Run the sproc 
                    var reader = cmd.ExecuteReader();

                    var contacts = ((IObjectContextAdapter)db)
                        .ObjectContext
                        .Translate<ContactInformation>(reader, "ContactInformations", MergeOption.NoTracking).ToList();
                    reader.NextResult();

                    var phones = ((IObjectContextAdapter)db)
                        .ObjectContext
                        .Translate<ContactInformationPhonenumber>(reader, "ContactInformationPhonenumbers", MergeOption.NoTracking).ToLookup(c => c.ContactInformationID);
                    reader.NextResult();

                    var mails = ((IObjectContextAdapter)db)
                        .ObjectContext
                        .Translate<ContactInformationMail>(reader, "ContactInformationMails", MergeOption.NoTracking).ToLookup(c => c.ContactInformationID);

                    foreach (var c in contacts)
                    {
                        c.ContactInformationMails = mails.Contains(c.ID) ? mails[c.ID].ToList() : new List<ContactInformationMail>();
                        c.ContactInformationPhonenumbers = phones.Contains(c.ID) ? phones[c.ID].ToList() : new List<ContactInformationPhonenumber>();
                    }
                }
            });
            */
        }
    }
}
