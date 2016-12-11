using System;
using System.Linq;
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
    public class SchoolTests
    {
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

            #region School Description Types
            var schoolDescriptionTypes = new HashSet<SchoolDescriptionTypeWrapper>();
            schoolDescriptionTypes.Add(SchoolDescriptionType.Nursery);
            schoolDescriptionTypes.Add(SchoolDescriptionType.PreK);
            schoolDescriptionTypes.Add(SchoolDescriptionType.Kindergarten);
            school.SchoolDescriptionTypes = schoolDescriptionTypes;
            #endregion

            #region Credit Card
            school.CreditCard = new CreditCard
            {
                CreditCardStatusType = CreditCardStatusType.Active,
                CreditCardType = CreditCardType.MasterCard,
                Number = EncryptionHelper.Encrypt<RijndaelManaged>("5555666677778888", "password", "salt"),
                CVVNumber = EncryptionHelper.Encrypt<RijndaelManaged>("456", "password", "salt"),
                ExpirationMonth = EncryptionHelper.Encrypt<RijndaelManaged>("11", "password", "salt"),
                ExpirationYear = EncryptionHelper.Encrypt<RijndaelManaged>("2017", "password", "salt"),
                HolderFirstName = EncryptionHelper.Encrypt<RijndaelManaged>("Mony", "password", "salt"),
                HolderLastName = EncryptionHelper.Encrypt<RijndaelManaged>("Taing", "password", "salt"),
                HolderMiddleName = EncryptionHelper.Encrypt<RijndaelManaged>("Yen", "password", "salt"),
            };
            #endregion

            using (var context = new WaldorfContext())
            {
                context.Schools.Add(school);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void School_PostedJobPosition_Insert_Teacher_Test()
        {
            var postedJobPosition = new PostedJobPosition
            {
                Title = "Superstar French High School Teacher",
                Description = "Description for High School French Teacher",
                PostedJobPositionStatusType = PostedJobPositionStatusType.Active,
                PartyType = PartyType.Teacher,
                EmploymentType = EmploymentType.SalariedFullTime,
                Compensation = 45000,
                CompensationType = CompensationType.Annually,
                HasBenefits = true,
                StartDate = new DateTime(2017, 10, 10),
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

        [TestMethod]
        public void School_PostedJobPosition_Insert_Admin_Test()
        {
            var postedJobPosition = new PostedJobPosition
            {
                Title = "Development President",
                Description = "President of Development",
                PostedJobPositionStatusType = PostedJobPositionStatusType.Active,
                PartyType = PartyType.Administrator,
                EmploymentType = EmploymentType.SalariedFullTime,                
                Compensation = 153000,
                CompensationType = CompensationType.Annually,
                HasBenefits = true,
                StartDate = new DateTime(2017, 01, 01),
                DateCreated = DateTime.UtcNow,
                Category = new PostedJobPositionCategory { JobPositionType = JobPositionType.DevelopmentDirector }
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
