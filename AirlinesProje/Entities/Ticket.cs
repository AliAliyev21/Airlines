using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlinesProje.Entities
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        public int ScheduleId { get; set; }
        public string PassengerName { get; set; }
        public string SeatNumber { get; set; }
        public string ClassType { get; set; }
        public virtual Schedule Schedule { get; set; }

        public override string ToString()
        {
            return PassengerName;
        }
    }
}
