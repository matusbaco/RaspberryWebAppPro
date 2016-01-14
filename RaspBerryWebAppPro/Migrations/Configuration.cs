namespace RaspBerryWebAppPro.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RaspBerryWebAppPro.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "RaspBerryWebAppPro.Models.ApplicationDbContext";
        }

        protected override void Seed(RaspBerryWebAppPro.Models.ApplicationDbContext context)
        {
            var devices = new List<Device>();
            var relays = new List<Relay>();
            var relayevents = new List<RelayEvent>();

            Device device1 = new Device();
            device1.SerialNumber = 0;
            device1.Name = "0001d";
            device1.Id = Guid.NewGuid();

            devices.Add(device1);

            Relay rel1 = new Relay();

            rel1.DeviceId = device1.Id;
            rel1.Index = 0;
            rel1.Name = "r01:0001d";
            rel1.Id= Guid.NewGuid();
            relays.Add(rel1);

            RelayEvent ev11 = new RelayEvent { EndTime = DateTime.Now, StartTime = DateTime.Now, Id = Guid.NewGuid(),  DurationInMinutes = 15, RelayId = rel1.Id };
            relayevents.Add(ev11);


            devices.ForEach(s => context.Devices.Add(s));
            context.SaveChanges();

            relays.ForEach(s => context.Relays.Add(s));
            context.SaveChanges();

            relayevents.ForEach(s => context.RelayEvents.Add(s));
            context.SaveChanges();
        }
    }
}
