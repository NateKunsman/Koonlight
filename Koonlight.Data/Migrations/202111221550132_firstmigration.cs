namespace Koonlight.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Loads",
                c => new
                    {
                        LoadId = c.Int(nullable: false, identity: true),
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
                .PrimaryKey(t => t.LoadId)
                .ForeignKey("dbo.AspNetUsers", t => t.DriverID)
                .Index(t => t.DriverID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        FullName = c.String(),
                        DLN = c.Int(nullable: false),
                        Company = c.String(nullable: false),
                        PickUpNum = c.Int(nullable: false),
                        Phone = c.Int(nullable: false),
                        SCAC = c.String(),
                        Currently = c.Boolean(nullable: false),
                        SpecialLicense = c.Int(nullable: false),
                        IsInsured = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Shippers",
                c => new
                    {
                        ShipperID = c.Int(nullable: false, identity: true),
                        LoadID = c.Int(nullable: false),
                        CompanyName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ShipperID)
                .ForeignKey("dbo.Loads", t => t.LoadID, cascadeDelete: false)
                .Index(t => t.LoadID);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionID = c.Int(nullable: false, identity: true),
                        Payout = c.Int(nullable: false),
                        ShipperID = c.Int(nullable: false),
                        LoadID = c.Int(nullable: false),
                        DriverID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TransactionID)
                .ForeignKey("dbo.AspNetUsers", t => t.DriverID)
                .ForeignKey("dbo.Loads", t => t.LoadID, cascadeDelete: false)
                .ForeignKey("dbo.Shippers", t => t.ShipperID, cascadeDelete: false)
                .Index(t => t.ShipperID)
                .Index(t => t.LoadID)
                .Index(t => t.DriverID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "ShipperID", "dbo.Shippers");
            DropForeignKey("dbo.Transactions", "LoadID", "dbo.Loads");
            DropForeignKey("dbo.Transactions", "DriverID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Shippers", "LoadID", "dbo.Loads");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Loads", "DriverID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Transactions", new[] { "DriverID" });
            DropIndex("dbo.Transactions", new[] { "LoadID" });
            DropIndex("dbo.Transactions", new[] { "ShipperID" });
            DropIndex("dbo.Shippers", new[] { "LoadID" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Loads", new[] { "DriverID" });
            DropTable("dbo.Transactions");
            DropTable("dbo.Shippers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Loads");
        }
    }
}
