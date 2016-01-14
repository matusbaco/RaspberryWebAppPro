using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaspBerryWebAppPro.Models
{
    public class RelayEvent
    {
        public Guid RelayId { get; set; }   
        public Guid Id { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int DurationInMinutes { get; set; }   

        public virtual Relay Relay { get; set; }
    }
}