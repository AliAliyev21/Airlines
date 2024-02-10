using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlinesProje.Entities
{
    public class Pilot
    {
        [Key]
        public int PilotId { get; set; }
        public string Name { get; set; }
        public string LicenseNumber { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
