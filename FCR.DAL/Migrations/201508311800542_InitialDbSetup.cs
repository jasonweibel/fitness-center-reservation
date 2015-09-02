namespace FCR.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDbSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CalendarEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        eventDescription = c.String(),
                        startDate = c.DateTime(),
                        endDate = c.DateTime(),
                        isAvailable = c.Boolean(),
                        FitnessCenter_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FitnessCenters", t => t.FitnessCenter_Id)
                .Index(t => t.FitnessCenter_Id);
            
            CreateTable(
                "dbo.FitnessCenters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CenterDescription = c.String(),
                        UnitIntervalMinutes = c.Int(nullable: false),
                        MaxConcurrentUnits = c.Int(nullable: false),
                        OperationTimeUnitStart = c.Int(nullable: false),
                        OperationTimeUnitLength = c.Int(nullable: false),
                        MaxDaysOutForReservation = c.Int(nullable: false),
                        Site_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sites", t => t.Site_Id)
                .Index(t => t.Site_Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Secret = c.String(),
                        Name = c.String(),
                        ApplicationType = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        RefreshTokenLifeTime = c.Int(nullable: false),
                        AllowedOrigin = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        ReservationDate = c.DateTime(nullable: false),
                        ReservationTimeUnitStart = c.Int(nullable: false),
                        ReservationTimeUnitLength = c.Int(nullable: false),
                        Validated = c.Boolean(nullable: false),
                        Resource_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Resources", t => t.Resource_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Resource_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ResourceName = c.String(),
                        ResourceDescription = c.String(),
                        FitnessCenter_Id = c.Int(),
                        ResourceType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FitnessCenters", t => t.FitnessCenter_Id)
                .ForeignKey("dbo.ResourceTypes", t => t.ResourceType_Id)
                .Index(t => t.FitnessCenter_Id)
                .Index(t => t.ResourceType_Id);
            
            CreateTable(
                "dbo.ResourceTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ResourceTypeDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SiteName = c.String(),
                        SiteCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FitnessCenters", "Site_Id", "dbo.Sites");
            DropForeignKey("dbo.Reservations", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Resources", "ResourceType_Id", "dbo.ResourceTypes");
            DropForeignKey("dbo.Reservations", "Resource_Id", "dbo.Resources");
            DropForeignKey("dbo.Resources", "FitnessCenter_Id", "dbo.FitnessCenters");
            DropForeignKey("dbo.CalendarEvents", "FitnessCenter_Id", "dbo.FitnessCenters");
            DropIndex("dbo.Resources", new[] { "ResourceType_Id" });
            DropIndex("dbo.Resources", new[] { "FitnessCenter_Id" });
            DropIndex("dbo.Reservations", new[] { "User_Id" });
            DropIndex("dbo.Reservations", new[] { "Resource_Id" });
            DropIndex("dbo.FitnessCenters", new[] { "Site_Id" });
            DropIndex("dbo.CalendarEvents", new[] { "FitnessCenter_Id" });
            DropTable("dbo.Sites");
            DropTable("dbo.Users");
            DropTable("dbo.ResourceTypes");
            DropTable("dbo.Resources");
            DropTable("dbo.Reservations");
            DropTable("dbo.Clients");
            DropTable("dbo.FitnessCenters");
            DropTable("dbo.CalendarEvents");
        }
    }
}
