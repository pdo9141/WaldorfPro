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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PartyTypeWrappers", "PartyId", "dbo.Parties");
            DropForeignKey("dbo.JobPositionWrappers", "PartyId", "dbo.Parties");
            DropForeignKey("dbo.JobPositionWrappers", "JobPositionTierOneCategory_Id", "dbo.JobPositionTierOneCategories");
            DropForeignKey("dbo.JobPositionTierOneCategories", "JobPositionTierTwoCategory_Id", "dbo.JobPositionTierTwoCategories");
            DropIndex("dbo.PartyTypeWrappers", new[] { "PartyId" });
            DropIndex("dbo.JobPositionTierOneCategories", new[] { "JobPositionTierTwoCategory_Id" });
            DropIndex("dbo.JobPositionWrappers", new[] { "JobPositionTierOneCategory_Id" });
            DropIndex("dbo.JobPositionWrappers", new[] { "PartyId" });
            DropTable("dbo.PartyTypeWrappers");
            DropTable("dbo.JobPositionTierTwoCategories");
            DropTable("dbo.JobPositionTierOneCategories");
            DropTable("dbo.JobPositionWrappers");
            DropTable("dbo.Parties");
        }
    }
}
