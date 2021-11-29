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
                    LoadID = model.LoadID,
                    DriverID = model.DriverID,
                    SCAC = model.SCAC,
                    PayOut = model.PayOut,
                    Broker = model.Broker,
                    PickUpLocation = model.PickUpLocation,
                    DropOffLocation = model.DropOffLocation,
                    Commodity = model.Commodity,
                    Distance = model.Distance,
                    Weight = model.Weight,
                    RatePerMile = model.RatePerMile,
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
                                    LoadID = e.LoadID,
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

            var entity =
                ctx
                    .Loads
                    .Single(e => e.LoadID == id /*&& e.DriverID == _userId.ToString()*/);
            return
              new LoadDetail
              {
                  LoadID = entity.LoadID,
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
        public LoadEdit GetLoadByIdForEdit(int id)
        {

            var entity =
                ctx
                    .Loads
                    .Single(e => e.LoadID == id /*&& e.DriverID == _userId.ToString()*/);
            return
              new LoadEdit
              {
                  LoadID = entity.LoadID,
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
              };

        }
        public bool UpdateLoad(LoadEdit model)
        {
            {
                var entity =
                    ctx
                        .Loads
                        .Single(e => e.LoadID == model.LoadID /*&& e.DriverID == _userId.ToString()*/);
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
                        .Single(e => e.LoadID == Id /*&& e.DriverID == _userId.ToString()*/);
                ctx.Loads.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
