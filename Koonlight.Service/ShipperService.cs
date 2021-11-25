using Koonlight.Models;
using Koonlight.MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koonlight.Service
{
    public class ShipperService
    {
        private readonly ApplicationDbContext ctx = new ApplicationDbContext();
        private readonly Guid _userId;
        public ShipperService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateShipper(ShipperCreate model)
        {
            var entity =
                new Shipper()
                {
                    ShipperID = model.ShipperID,
                    CompanyName = model.CompanyName,
                    Address = model.Address,
                    
                };
            {
                ctx.Shippers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ShipperList> GetShippers()
        {
            {
                var quary =
                    ctx
                        .Shippers
                        .Select(
                             e =>
                                new ShipperList
                                {
                                    ShipperID = e.ShipperID,
                                    CompanyName = e.CompanyName,
                                    Address = e.Address,
                                }
                         );
                return quary.ToArray();
            }
        }
        public ShipperDetail GetShipperById(int id)
        {
            {
                var entity =
                    ctx
                        .Shippers
                        .Single(e => e.ShipperID == id);
                return
                  new ShipperDetail
                  {
                      
                      ShipperID = entity.ShipperID,
                      CompanyName = entity.CompanyName,
                      Address = entity.Address,
                  };
            }
        }
        public bool UpdateShipper(ShipperEdit model)
        {
            {
                var entity =
                    ctx
                        .Shippers
                        .Single(e => e.ShipperID == model.ShipperID);
                
                entity.ShipperID = model.ShipperID;
                entity.CompanyName = model.CompanyName;
                entity.Address = model.Address;


                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteShipper(int Id)
        {
            {
                var entity =
                    ctx
                        .Shippers
                        .Single(e => e.ShipperID == Id);
                ctx.Shippers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}

