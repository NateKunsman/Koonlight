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
    public class LoadCreate
    {
        [Key]
        [Required]
        public int LoadId { get; set; }
        public string Broker { get; set; }
        [MaxLength(4, ErrorMessage = "There are too many characters in this field")]
        [Required]
        public string SCAC { get; set; }
        [Required]
        public decimal PayOut { get; set; }
        [Required]
        public string PickUpLocation { get; set; }
        [Required]
        public string DropOffLocation { get; set; }
        public decimal Distance { get; set; }
        [Required]
        public decimal Weight { get; set; }
        public EndorsementNeededEnum SpecialLicenseNeeded { get; set; }
        //Create later as an enum //https://www.bts.gov/topics/freight-transportation/freight-shipments-commodity
        public string Commodity { get; set; }
        public decimal RatePerMile { get; set; }
        [Required]
        public DateTimeOffset? DeliverByDate { get; set; }

    }
}
