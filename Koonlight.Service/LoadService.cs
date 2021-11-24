using Koonlight.Models;
using Koonlight.MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koonlight.Service
{
        public class LoadService
        {
        private readonly ApplicationDbContext ctx = new ApplicationDbContext();
        private readonly Guid _userId;
        public LoadService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateLoad(LoadCreate model)
        {
            var entity =
                new Load()
                {
                    //OwnerId = Driver,
                    SCAC = model.SCAC,
                    PayOut = model.PayOut,
                    PickUpLocation = model.PickUpLocation,
                    DropOffLocation = model.DropOffLocation,
                    Weight = model.Weight,
                    DeliverByDate = model.DeliverByDate
                };
            {
                ctx.Loads.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<LoadList> GetLoads()
        {
            {
                var quary =
                    ctx
                        .Loads
                        //.Where(e => e.Driver.Id == DriverId) //Figure out if actually you need this and if so fix this (so far I don't think I need it)
                        .Select(
                             e =>
                                new LoadList
                                {
                                    LoadId = e.LoadId,
                                    PayOut = e.PayOut,
                                    PickUpLocation = e.PickUpLocation,
                                    DropOffLocation = e.DropOffLocation,
                                    Distance = e.Distance,
                                    Weight = e.Weight,
                                }
                         );
                return quary.ToArray();
            }
        }
        public LoadDetail GetLoadById(int id)
        {
            {
                var entity =
                    ctx
                        .Loads
                        .Single(e => e.LoadId == id && e.DriverID == _userId); 
                return
                  new LoadDetail
                  {
                      LoadId = entity.LoadId,
                      SCAC = entity.SCAC,
                      Broker = entity.Broker,
                      PayOut = entity.PayOut,
                      PickUpLocation = entity.PickUpLocation,
                      DropOffLocation = entity.DropOffLocation,
                      Distance = entity.Distance,
                      Weight = entity.Weight,
                      Commodity = entity.Commodity,
                      RatePerMile = entity.RatePerMile,
                      DeliverByDate = entity.DeliverByDate,
                      LoadCovered = entity.LoadCovered,
                      PickedUp = entity.PickedUp,
                      LoadDelivered = entity.LoadDelivered,
                      TimePickedUp = entity.TimePickedUp,
                      TimeDelived = entity.TimeDelived,
                  };
            }
        }
        public bool UpdateLoad(LoadEdit model)
        {
            {
                var entity =
                    ctx
                        .Loads
                        .Single(e => e.LoadId == model.LoadId && e.DriverID == _userId);
                entity.LoadId = model.LoadId;
                entity.SCAC = model.SCAC;
                entity.Broker = model.Broker;
                entity.PayOut = model.PayOut;
                entity.PickUpLocation = model.PickUpLocation;
                entity.DropOffLocation = model.DropOffLocation;
                entity.Distance = model.Distance;
                entity.Weight = model.Weight;
                entity.Commodity = model.Commodity;
                entity.RatePerMile = model.RatePerMile;
                entity.DeliverByDate = model.DeliverByDate;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteLoad(int Id)
        {
            {
                var entity =
                    ctx
                        .Loads
                        .Single(e => e.LoadId == Id && e.DriverID == _userId);
                ctx.Loads.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
