namespace AirlinesProje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Airplanes",
                c => new
                    {
                        PlaneId = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        Capacity = c.Int(),
                    })
                .PrimaryKey(t => t.PlaneId);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ScheduleId = c.Int(nullable: false, identity: true),
                        FlightNumber = c.String(),
                        DepartureCityID = c.Int(nullable: false),
                        ArrivalCityID = c.Int(nullable: false),
                        DepartureTime = c.DateTime(nullable: false),
                        ArrivalTime = c.DateTime(nullable: false),
                        PlaneId = c.Int(nullable: false),
                        PilotId = c.Int(nullable: false),
                        Citie_CityId = c.Int(),
                        Citie_CityId1 = c.Int(),
                        ArrivalCity_CityId = c.Int(),
                        DepartureCity_CityId = c.Int(),
                    })
                .PrimaryKey(t => t.ScheduleId)
                .ForeignKey("dbo.Airplanes", t => t.PlaneId, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.Citie_CityId)
                .ForeignKey("dbo.Cities", t => t.Citie_CityId1)
                .ForeignKey("dbo.Cities", t => t.ArrivalCity_CityId)
                .ForeignKey("dbo.Cities", t => t.DepartureCity_CityId)
                .ForeignKey("dbo.Pilots", t => t.PilotId, cascadeDelete: true)
                .Index(t => t.PlaneId)
                .Index(t => t.PilotId)
                .Index(t => t.Citie_CityId)
                .Index(t => t.Citie_CityId1)
                .Index(t => t.ArrivalCity_CityId)
                .Index(t => t.DepartureCity_CityId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.CityId);
            
            CreateTable(
                "dbo.Pilots",
                c => new
                    {
                        PilotId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LicenseNumber = c.String(),
                    })
                .PrimaryKey(t => t.PilotId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        ScheduleId = c.Int(nullable: false),
                        PassengerName = c.String(),
                        SeatNumber = c.String(),
                        ClassType = c.String(),
                    })
                .PrimaryKey(t => t.TicketId)
                .ForeignKey("dbo.Schedules", t => t.ScheduleId, cascadeDelete: true)
                .Index(t => t.ScheduleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "ScheduleId", "dbo.Schedules");
            DropForeignKey("dbo.Schedules", "PilotId", "dbo.Pilots");
            DropForeignKey("dbo.Schedules", "DepartureCity_CityId", "dbo.Cities");
            DropForeignKey("dbo.Schedules", "ArrivalCity_CityId", "dbo.Cities");
            DropForeignKey("dbo.Schedules", "Citie_CityId1", "dbo.Cities");
            DropForeignKey("dbo.Schedules", "Citie_CityId", "dbo.Cities");
            DropForeignKey("dbo.Schedules", "PlaneId", "dbo.Airplanes");
            DropIndex("dbo.Tickets", new[] { "ScheduleId" });
            DropIndex("dbo.Schedules", new[] { "DepartureCity_CityId" });
            DropIndex("dbo.Schedules", new[] { "ArrivalCity_CityId" });
            DropIndex("dbo.Schedules", new[] { "Citie_CityId1" });
            DropIndex("dbo.Schedules", new[] { "Citie_CityId" });
            DropIndex("dbo.Schedules", new[] { "PilotId" });
            DropIndex("dbo.Schedules", new[] { "PlaneId" });
            DropTable("dbo.Tickets");
            DropTable("dbo.Pilots");
            DropTable("dbo.Cities");
            DropTable("dbo.Schedules");
            DropTable("dbo.Airplanes");
        }
    }
}
