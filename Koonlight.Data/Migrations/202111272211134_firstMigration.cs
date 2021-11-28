namespace Koonlight.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Load",
                c => new
                    {
                        LoadID = c.Int(nullable: false, identity: true),
                        DriverID = c.String(maxLength: 128),
                        Broker = c.String(),
                        SCAC = c.String(maxLength: 4),
                        PayOut = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PickUpLocation = c.String(),
                        DropOffLocation = c.String(),
                        Distance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SpecialLicenseNeeded = c.Int(nullable: false),
                        Commodity = c.String(),
                        RatePerMile = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeliverByDate = c.DateTimeOffset(precision: 7),
                        LoadCovered = c.Boolean(nullable: false),
                        PickedUp = c.Boolean(nullable: false),
                        LoadDelivered = c.Boolean(nullable: false),
                        TimePickedUp = c.DateTimeOffset(precision: 7),
                        TimeDelived = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.LoadID)
                .ForeignKey("dbo.ApplicationUser", t => t.DriverID)
                .Index(t => t.DriverID);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        FullName = c.String(),
                        DLN = c.Int(nullable: false),
                        Company = c.String(),
                        Phone = c.Int(nullable: false),
                        SpecialLicense = c.Int(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Shipper",
                c => new
                    {
                        ShipperID = c.Int(nullable: false, identity: true),
                        LoadID = c.Int(nullable: false),
                        CompanyName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ShipperID)
                .ForeignKey("dbo.Load", t => t.LoadID, cascadeDelete: true)
                .Index(t => t.LoadID);
            
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        TransactionID = c.Int(nullable: false, identity: true),
                        ShipperID = c.Int(nullable: false),
                        LoadID = c.Int(nullable: false),
                        Payout = c.Int(nullable: false),
                        DriverID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TransactionID)
                .ForeignKey("dbo.ApplicationUser", t => t.DriverID)
                .ForeignKey("dbo.Load", t => t.LoadID, cascadeDelete: false)
                .ForeignKey("dbo.Shipper", t => t.ShipperID, cascadeDelete: true)
                .Index(t => t.ShipperID)
                .Index(t => t.LoadID)
                .Index(t => t.DriverID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transaction", "ShipperID", "dbo.Shipper");
            DropForeignKey("dbo.Transaction", "LoadID", "dbo.Load");
            DropForeignKey("dbo.Transaction", "DriverID", "dbo.ApplicationUser");
            DropForeignKey("dbo.Shipper", "LoadID", "dbo.Load");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Load", "DriverID", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropIndex("dbo.Transaction", new[] { "DriverID" });
            DropIndex("dbo.Transaction", new[] { "LoadID" });
            DropIndex("dbo.Transaction", new[] { "ShipperID" });
            DropIndex("dbo.Shipper", new[] { "LoadID" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Load", new[] { "DriverID" });
            DropTable("dbo.Transaction");
            DropTable("dbo.Shipper");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Load");
        }
    }
}
