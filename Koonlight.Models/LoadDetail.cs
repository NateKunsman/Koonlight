using Koonlight.MVC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koonlight.Models
{
    public class LoadDetail
    {
        public int LoadID { get; set; }
        [ForeignKey(nameof(Driver))]
        public string DriverID { get; set; }
        public virtual ApplicationUser Driver { get; set; }
        public string Broker { get; set; }
        [MaxLength(4, ErrorMessage = "There are too many characters in this field")]
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
        public DateTimeOffset? DeliverByDate { get; set; }
        public bool LoadCovered { get; set; }
        public bool PickedUp { get; set; }
        public bool LoadDelivered { get; set; }
        public DateTimeOffset? TimePickedUp { get; set; }
        public DateTimeOffset? TimeDelived { get; set; }
    }
}
