using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows.Documents;
using System.Windows.Markup;
using System.ComponentModel.DataAnnotations;

namespace AirlinesProje.Entities
{
    public class Citie
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string Country { get; set; }
        public virtual ICollection<Schedule> DepartureSchedules { get; set; }
        public virtual ICollection<Schedule> ArrivalSchedules { get; set; }

        public override string ToString()
        {
            return CityName;
        }
    }
}

