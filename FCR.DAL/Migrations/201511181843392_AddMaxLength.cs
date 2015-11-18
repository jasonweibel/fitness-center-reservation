namespace FCR.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMaxLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FitnessCenters", "CenterDescription", c => c.String(maxLength: 250));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "LastName", c => c.String());
            AlterColumn("dbo.Users", "FirstName", c => c.String());
            AlterColumn("dbo.FitnessCenters", "CenterDescription", c => c.String());
        }
    }
}
