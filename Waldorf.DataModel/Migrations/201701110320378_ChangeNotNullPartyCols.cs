namespace Waldorf.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNotNullPartyCols : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Parties", "FirstName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Parties", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Parties", "EmailAddress", c => c.String(maxLength: 75));
            AlterColumn("dbo.Parties", "ZipCode", c => c.String(maxLength: 10));
            AlterColumn("dbo.Parties", "PreferredName", c => c.String(maxLength: 75));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Parties", "PreferredName", c => c.String(nullable: false, maxLength: 75));
            AlterColumn("dbo.Parties", "ZipCode", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Parties", "EmailAddress", c => c.String(nullable: false, maxLength: 75));
            AlterColumn("dbo.Parties", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Parties", "FirstName", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
