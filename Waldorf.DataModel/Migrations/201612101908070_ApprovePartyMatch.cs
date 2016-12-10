namespace Waldorf.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApprovePartyMatch : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApprovedMatchPostedJobPositions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PostedJobPositionId = c.Long(nullable: false),
                        Party_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parties", t => t.Party_Id)
                .Index(t => t.Party_Id);
            
            AddColumn("dbo.Parties", "AllowSchoolMatchWithoutApproval", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApprovedMatchPostedJobPositions", "Party_Id", "dbo.Parties");
            DropIndex("dbo.ApprovedMatchPostedJobPositions", new[] { "Party_Id" });
            DropColumn("dbo.Parties", "AllowSchoolMatchWithoutApproval");
            DropTable("dbo.ApprovedMatchPostedJobPositions");
        }
    }
}
