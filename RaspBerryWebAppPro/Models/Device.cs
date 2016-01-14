using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaspBerryWebAppPro.Models
{
    public class Device
    {
      
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public int SerialNumber { get; set; }
        public string Name { get; set; }      

        public virtual ICollection<Relay> Relays { get; set; }
        public virtual ApplicationUser User { get; set; }       
    }
}
