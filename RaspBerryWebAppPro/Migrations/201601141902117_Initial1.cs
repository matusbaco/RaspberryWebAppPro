namespace RaspBerryWebAppPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        SerialNumber = c.Int(nullable: false),
                        Name = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Relays",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DeviceId = c.Guid(nullable: false),
                        Index = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Devices", t => t.DeviceId, cascadeDelete: true)
                .Index(t => t.DeviceId);
            
            CreateTable(
                "dbo.RelayEvents",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RelayId = c.Guid(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        DurationInMinutes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Relays", t => t.RelayId, cascadeDelete: true)
                .Index(t => t.RelayId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Devices", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.RelayEvents", "RelayId", "dbo.Relays");
            DropForeignKey("dbo.Relays", "DeviceId", "dbo.Devices");
            DropIndex("dbo.RelayEvents", new[] { "RelayId" });
            DropIndex("dbo.Relays", new[] { "DeviceId" });
            DropIndex("dbo.Devices", new[] { "User_Id" });
            DropTable("dbo.RelayEvents");
            DropTable("dbo.Relays");
            DropTable("dbo.Devices");
        }
    }
}
