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
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Loads.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<LoadList> GetLoads()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var quary =
                    ctx
                        .Loads
                        //.Where(e => e.Driver.Id == DriverId)
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
    }
}
