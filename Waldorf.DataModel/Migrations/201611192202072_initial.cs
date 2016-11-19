namespace Waldorf.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
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
                        PreferredName = c.String(nullable: false, maxLength: 75),
                        ProfileImageName = c.String(maxLength: 100),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(nullable: false, maxLength: 50),
                        Street2 = c.String(maxLength: 50),
                        City = c.String(nullable: false, maxLength: 50),
                        State = c.String(nullable: false, maxLength: 2),
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
            DropForeignKey("dbo.PostedJobPositions", "Category_Id", "dbo.PostedJobPositionCategories");
            DropForeignKey("dbo.PostedJobPositionCategories", "JobPositionTierOneCategory_Id", "dbo.JobPositionTierOneCategories");
            DropForeignKey("dbo.Schools", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.PartyTypeWrappers", "PartyId", "dbo.Parties");
            DropForeignKey("dbo.JobPositionWrappers", "PartyId", "dbo.Parties");
            DropForeignKey("dbo.JobPositionWrappers", "JobPositionTierOneCategory_Id", "dbo.JobPositionTierOneCategories");
            DropForeignKey("dbo.JobPositionTierOneCategories", "JobPositionTierTwoCategory_Id", "dbo.JobPositionTierTwoCategories");
            DropIndex("dbo.SchoolDescriptionTypeWrappers", new[] { "SchoolId" });
            DropIndex("dbo.PostedJobPositionCategories", new[] { "JobPositionTierOneCategory_Id" });
            DropIndex("dbo.PostedJobPositions", new[] { "Category_Id" });
            DropIndex("dbo.PostedJobPositions", new[] { "SchoolId" });
            DropIndex("dbo.Schools", new[] { "Address_Id" });
            DropIndex("dbo.PartyTypeWrappers", new[] { "PartyId" });
            DropIndex("dbo.JobPositionTierOneCategories", new[] { "JobPositionTierTwoCategory_Id" });
            DropIndex("dbo.JobPositionWrappers", new[] { "JobPositionTierOneCategory_Id" });
            DropIndex("dbo.JobPositionWrappers", new[] { "PartyId" });
            DropTable("dbo.SchoolDescriptionTypeWrappers");
            DropTable("dbo.PostedJobPositionCategories");
            DropTable("dbo.PostedJobPositions");
            DropTable("dbo.Addresses");
            DropTable("dbo.Schools");
            DropTable("dbo.PartyTypeWrappers");
            DropTable("dbo.JobPositionTierTwoCategories");
            DropTable("dbo.JobPositionTierOneCategories");
            DropTable("dbo.JobPositionWrappers");
            DropTable("dbo.Parties");
        }
    }
}
