using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaspBerryWebAppPro.Models
{
    public class Relay
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }

        public int Index { get; set; }
        public string Name { get; set; }    

        public virtual Device Device { get; set; }
        public virtual ICollection<RelayEvent> RelayEvents { get; set; }
    }
}
