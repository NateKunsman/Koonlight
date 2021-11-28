using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koonlight.Models
{
    public class LoadList
    {
        public int LoadID { get; set; }
        public decimal PayOut { get; set; }
        public string PickUpLocation { get; set; }
        public string DropOffLocation { get; set; }
        public decimal Distance { get; set; }
        public decimal Weight { get; set; }
    }
}
