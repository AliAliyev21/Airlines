using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlinesProje.Entities
{
    public class Airplane
    {
        [Key]
        public int PlaneId { get; set; }
        public string Model { get; set; }
        public int? Capacity { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }

        public override string ToString()
        {
            return Model + " " + Capacity.ToString();
        }
    }
}
