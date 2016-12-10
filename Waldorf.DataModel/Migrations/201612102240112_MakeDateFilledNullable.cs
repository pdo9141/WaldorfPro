namespace Waldorf.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeDateFilledNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PostedJobPositions", "DateFilled", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PostedJobPositions", "DateFilled", c => c.DateTime(nullable: false));
        }
    }
}
