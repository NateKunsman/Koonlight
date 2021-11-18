using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Koonlight.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }
        //Foreign key for payout???
        public int Payout { get; set; }
        [ForeignKey(nameof(Shipper))]
        public int ShipperID { get; set; }
        [ForeignKey(nameof(Load))]
        public int LoadID { get; set; }
        [ForeignKey(nameof(DriverID))]
        public int DriverID { get; set; }
       //POD (stretch goal)
    }
}