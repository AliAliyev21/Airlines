using AirlinesProje.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlinesProje.DataAccess
{
    public class MyContext : DbContext
    {
        public MyContext()
            :base("AirlinesDb") { }

        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Citie> Cities { get; set; }
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
