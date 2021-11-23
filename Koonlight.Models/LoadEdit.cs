using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koonlight.Models
{
    public class LoadEdit
    {
        public string Broker { get; set; }
        [MaxLength(4, ErrorMessage = "There are too many characters in this feild")]
        public string SCAC { get; set; }
        public decimal PayOut { get; set; }
        public string PickUpLocation { get; set; }
        public string DropOffLocation { get; set; }
        public decimal Distance { get; set; }
        public decimal Weight { get; set; }
        public EndorsementNeededEnum SpecialLicenseNeeded { get; set; }
        //Create later as an enum //https://www.bts.gov/topics/freight-transportation/freight-shipments-commodity
        public string Commodity { get; set; }
        public decimal RatePerMile { get; set; }
    }
}
