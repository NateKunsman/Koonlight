using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Koonlight.Models
{
    public class Shipper
    {
        [Key]
        public int ShipperID { get; set; }
        public virtual Load Load { get; set; }
        [ForeignKey(nameof(Load))]
        public int LoadID { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string Address { get; set; }

    }
}