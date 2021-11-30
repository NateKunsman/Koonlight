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
    public class TransactionEdit
    {
        public int TransactionID { get; set; }
        public int Payout { get; set; }
        public int ShipperID { get; set; }
        public virtual Shipper Shipper { get; set; }
        public int LoadID { get; set; }
        public virtual Load Load { get; set; }
        public string DriverID { get; set; }
        public virtual ApplicationUser Driver { get; set; }
    }
}
