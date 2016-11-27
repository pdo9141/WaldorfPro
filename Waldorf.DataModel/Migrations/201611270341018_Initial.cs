namespace Waldorf.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parties",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PartyStatusType = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        EmailAddress = c.String(nullable: false, maxLength: 75),
                        ZipCode = c.String(nullable: false, maxLength: 10),
                        WaldorfTranscriptFileName = c.String(maxLength: 100),
                        PreferredName = c.String(nullable: false, maxLength: 75),
                        ProfileImageName = c.String(maxLength: 100),
                        UserId = c.String(nullable: false, maxLength: 128),
                        DateCreated = c.DateTime(nullable: false),
                        CreditCard_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CreditCards", t => t.CreditCard_Id)
                .Index(t => t.CreditCard_Id);
            
            CreateTable(
                "dbo.CreditCards",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CreditCardStatusType = c.Int(nullable: false),
                        CreditCardType = c.Int(nullable: false),
                        Number = c.String(maxLength: 300),
                        CVVNumber = c.String(maxLength: 100),
                        ExpirationMonth = c.String(maxLength: 100),
                        ExpirationYear = c.String(maxLength: 100),
                        HolderFirstName = c.String(maxLength: 500),
                        HolderMiddleName = c.String(maxLength: 500),
                        HolderLastName = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Evaluations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FileName = c.String(maxLength: 100),
                        Party_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parties", t => t.Party_Id)
                .Index(t => t.Party_Id);
            
            CreateTable(
                "dbo.FavoritedPostedJobPositions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PostedJobPositionId = c.Long(nullable: false),
                        Party_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parties", t => t.Party_Id)
                .Index(t => t.Party_Id);
            
            CreateTable(
                "dbo.Graduates",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        SchoolName = c.String(nullable: false, maxLength: 50),
                        City = c.String(nullable: false, maxLength: 50),
                        State = c.Int(nullable: false),
                        DegreeEmphasis = c.String(nullable: false, maxLength: 100),
                        TranscriptFileName = c.String(maxLength: 100),
                        Party_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parties", t => t.Party_Id)
                .Index(t => t.Party_Id);
            
            CreateTable(
                "dbo.JobPositionWrappers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        JobPositionType = c.Int(nullable: false),
                        PartyId = c.Long(nullable: false),
                        JobPositionTierOneCategory_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobPositionTierOneCategories", t => t.JobPositionTierOneCategory_Id)
                .ForeignKey("dbo.Parties", t => t.PartyId, cascadeDelete: true)
                .Index(t => t.PartyId)
                .Index(t => t.JobPositionTierOneCategory_Id);
            
            CreateTable(
                "dbo.JobPositionTierOneCategories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        JobPositionTierOneCategoryType = c.Int(nullable: false),
                        JobPositionTierTwoCategory_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobPositionTierTwoCategories", t => t.JobPositionTierTwoCategory_Id)
                .Index(t => t.JobPositionTierTwoCategory_Id);
            
            CreateTable(
                "dbo.JobPositionTierTwoCategories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        JobPositionTierTwoCategoryType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OccupationalCertifications",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        State = c.Int(nullable: false),
                        DocumentationFileName = c.String(maxLength: 100),
                        Party_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parties", t => t.Party_Id)
                .Index(t => t.Party_Id);
            
            CreateTable(
                "dbo.PartyTypeWrappers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PartyType = c.Int(nullable: false),
                        PartyId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parties", t => t.PartyId, cascadeDelete: true)
                .Index(t => t.PartyId);
            
            CreateTable(
                "dbo.RecommendationLetters",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FileName = c.String(maxLength: 100),
                        Party_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parties", t => t.Party_Id)
                .Index(t => t.Party_Id);
            
            CreateTable(
                "dbo.StateCredentials",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        State = c.Int(nullable: false),
                        DocumentationFileName = c.String(maxLength: 100),
                        Party_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parties", t => t.Party_Id)
                .Index(t => t.Party_Id);
            
            CreateTable(
                "dbo.Undergraduates",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        SchoolName = c.String(nullable: false, maxLength: 50),
                        City = c.String(nullable: false, maxLength: 50),
                        State = c.Int(nullable: false),
                        Degree = c.Int(nullable: false),
                        Major = c.String(nullable: false, maxLength: 100),
                        Minor = c.String(maxLength: 100),
                        TranscriptFileName = c.String(maxLength: 100),
                        Party_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parties", t => t.Party_Id)
                .Index(t => t.Party_Id);
            
            CreateTable(
                "dbo.WaldorfTeachingCertificationTypeWrappers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        WaldorfTeachingCertificationType = c.Int(nullable: false),
                        PartyId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parties", t => t.PartyId, cascadeDelete: true)
                .Index(t => t.PartyId);
            
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SchoolStatusType = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(maxLength: 20),
                        EmailAddress = c.String(maxLength: 75),
                        WebAddress = c.String(maxLength: 100),
                        AwsnaAccreditationLevel = c.Int(nullable: false),
                        YearFounded = c.Short(nullable: false),
                        Enrollment = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Address_Id = c.Int(),
                        CreditCard_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .ForeignKey("dbo.CreditCards", t => t.CreditCard_Id)
                .Index(t => t.Address_Id)
                .Index(t => t.CreditCard_Id);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(nullable: false, maxLength: 50),
                        Street2 = c.String(maxLength: 50),
                        City = c.String(nullable: false, maxLength: 50),
                        State = c.Int(nullable: false),
                        ZipCode = c.String(nullable: false, maxLength: 10),
                        Country = c.String(maxLength: 75),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PostedJobPositions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        SchoolId = c.Int(nullable: false),
                        PostedJobPositionStatusType = c.Int(nullable: false),
                        PartyType = c.Int(nullable: false),
                        EmploymentType = c.Int(nullable: false),
                        Title = c.String(maxLength: 50),
                        Description = c.String(maxLength: 100),
                        Compensation = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CompensationType = c.Int(nullable: false),
                        HasBenefits = c.Boolean(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        DateFilled = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Category_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PostedJobPositionCategories", t => t.Category_Id)
                .ForeignKey("dbo.Schools", t => t.SchoolId, cascadeDelete: true)
                .Index(t => t.SchoolId)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.PostedJobPositionCategories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        JobPositionType = c.Int(nullable: false),
                        JobPositionTierOneCategory_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobPositionTierOneCategories", t => t.JobPositionTierOneCategory_Id)
                .Index(t => t.JobPositionTierOneCategory_Id);
            
            CreateTable(
                "dbo.FavoritedParties",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PartyId = c.Long(nullable: false),
                        PostedJobPosition_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PostedJobPositions", t => t.PostedJobPosition_Id)
                .Index(t => t.PostedJobPosition_Id);
            
            CreateTable(
                "dbo.SchoolDescriptionTypeWrappers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SchoolDescriptionType = c.Int(nullable: false),
                        SchoolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schools", t => t.SchoolId, cascadeDelete: true)
                .Index(t => t.SchoolId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SchoolDescriptionTypeWrappers", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.PostedJobPositions", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.FavoritedParties", "PostedJobPosition_Id", "dbo.PostedJobPositions");
            DropForeignKey("dbo.PostedJobPositions", "Category_Id", "dbo.PostedJobPositionCategories");
            DropForeignKey("dbo.PostedJobPositionCategories", "JobPositionTierOneCategory_Id", "dbo.JobPositionTierOneCategories");
            DropForeignKey("dbo.Schools", "CreditCard_Id", "dbo.CreditCards");
            DropForeignKey("dbo.Schools", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.WaldorfTeachingCertificationTypeWrappers", "PartyId", "dbo.Parties");
            DropForeignKey("dbo.Undergraduates", "Party_Id", "dbo.Parties");
            DropForeignKey("dbo.StateCredentials", "Party_Id", "dbo.Parties");
            DropForeignKey("dbo.RecommendationLetters", "Party_Id", "dbo.Parties");
            DropForeignKey("dbo.PartyTypeWrappers", "PartyId", "dbo.Parties");
            DropForeignKey("dbo.OccupationalCertifications", "Party_Id", "dbo.Parties");
            DropForeignKey("dbo.JobPositionWrappers", "PartyId", "dbo.Parties");
            DropForeignKey("dbo.JobPositionWrappers", "JobPositionTierOneCategory_Id", "dbo.JobPositionTierOneCategories");
            DropForeignKey("dbo.JobPositionTierOneCategories", "JobPositionTierTwoCategory_Id", "dbo.JobPositionTierTwoCategories");
            DropForeignKey("dbo.Graduates", "Party_Id", "dbo.Parties");
            DropForeignKey("dbo.FavoritedPostedJobPositions", "Party_Id", "dbo.Parties");
            DropForeignKey("dbo.Evaluations", "Party_Id", "dbo.Parties");
            DropForeignKey("dbo.Parties", "CreditCard_Id", "dbo.CreditCards");
            DropIndex("dbo.SchoolDescriptionTypeWrappers", new[] { "SchoolId" });
            DropIndex("dbo.FavoritedParties", new[] { "PostedJobPosition_Id" });
            DropIndex("dbo.PostedJobPositionCategories", new[] { "JobPositionTierOneCategory_Id" });
            DropIndex("dbo.PostedJobPositions", new[] { "Category_Id" });
            DropIndex("dbo.PostedJobPositions", new[] { "SchoolId" });
            DropIndex("dbo.Schools", new[] { "CreditCard_Id" });
            DropIndex("dbo.Schools", new[] { "Address_Id" });
            DropIndex("dbo.WaldorfTeachingCertificationTypeWrappers", new[] { "PartyId" });
            DropIndex("dbo.Undergraduates", new[] { "Party_Id" });
            DropIndex("dbo.StateCredentials", new[] { "Party_Id" });
            DropIndex("dbo.RecommendationLetters", new[] { "Party_Id" });
            DropIndex("dbo.PartyTypeWrappers", new[] { "PartyId" });
            DropIndex("dbo.OccupationalCertifications", new[] { "Party_Id" });
            DropIndex("dbo.JobPositionTierOneCategories", new[] { "JobPositionTierTwoCategory_Id" });
            DropIndex("dbo.JobPositionWrappers", new[] { "JobPositionTierOneCategory_Id" });
            DropIndex("dbo.JobPositionWrappers", new[] { "PartyId" });
            DropIndex("dbo.Graduates", new[] { "Party_Id" });
            DropIndex("dbo.FavoritedPostedJobPositions", new[] { "Party_Id" });
            DropIndex("dbo.Evaluations", new[] { "Party_Id" });
            DropIndex("dbo.Parties", new[] { "CreditCard_Id" });
            DropTable("dbo.SchoolDescriptionTypeWrappers");
            DropTable("dbo.FavoritedParties");
            DropTable("dbo.PostedJobPositionCategories");
            DropTable("dbo.PostedJobPositions");
            DropTable("dbo.Addresses");
            DropTable("dbo.Schools");
            DropTable("dbo.WaldorfTeachingCertificationTypeWrappers");
            DropTable("dbo.Undergraduates");
            DropTable("dbo.StateCredentials");
            DropTable("dbo.RecommendationLetters");
            DropTable("dbo.PartyTypeWrappers");
            DropTable("dbo.OccupationalCertifications");
            DropTable("dbo.JobPositionTierTwoCategories");
            DropTable("dbo.JobPositionTierOneCategories");
            DropTable("dbo.JobPositionWrappers");
            DropTable("dbo.Graduates");
            DropTable("dbo.FavoritedPostedJobPositions");
            DropTable("dbo.Evaluations");
            DropTable("dbo.CreditCards");
            DropTable("dbo.Parties");
        }
    }
}
