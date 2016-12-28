namespace Waldorf.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSchoolAdmin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SchoolAdmins",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        DateCreated = c.DateTime(nullable: false),
                        School_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schools", t => t.School_Id)
                .Index(t => t.School_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SchoolAdmins", "School_Id", "dbo.Schools");
            DropIndex("dbo.SchoolAdmins", new[] { "School_Id" });
            DropTable("dbo.SchoolAdmins");
        }
    }
}
