using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AirlinesProje.Entities
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }
        public string FlightNumber { get; set; }
        public int DepartureCityID { get; set; }
        public int ArrivalCityID { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int PlaneId { get; set; }
        public int PilotId { get; set; }
        public virtual Airplane Airplane { get; set; }
        public virtual Citie DepartureCity { get; set; }
        public virtual Citie ArrivalCity { get; set; }
        public virtual Pilot Pilot { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

        public override string ToString()
        {
            return FlightNumber;
        }
    }
}
