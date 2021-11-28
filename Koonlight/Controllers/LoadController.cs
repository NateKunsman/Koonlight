using Koonlight.Models;
using Koonlight.MVC.Data;
using Koonlight.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Koonlight.Controllers
{
    [Authorize]
    public class LoadController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        private Guid _userId;
        //POST: Load
        public ActionResult Index()
        {
            var service = CreateLoadService();
            var model = service.GetLoads();

            return View(model);
        }
        //POST:Load
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LoadCreate model)
        {
            if (!ModelState.IsValid) return View(model);
      
            var service = CreateLoadService();

            if (service.CreateLoad(model))
            {
                return RedirectToAction("Index");
            };
            return View(model);
        }
        //GET: Load Detail
        public ActionResult Detail(int id)
        {
            var svc = CreateLoadService();
            var load = svc.GetLoadById(id); 

            return View(load);
        }

        //GET: List Load
        //PUT: Edit Load
        public ActionResult Edit(int id)
        {
            var service = CreateLoadService();
            var detail = service.GetLoadById(id);
            var model =
                new LoadEdit
                {
                    SCAC = detail.SCAC,
                    Broker = detail.Broker,
                    PayOut = detail.PayOut,
                    PickUpLocation = detail.PickUpLocation,
                    DropOffLocation = detail.DropOffLocation,
                    Distance = detail.Distance,
                    SpecialLicenseNeeded = detail.SpecialLicenseNeeded,
                    Weight = detail.Weight,
                    Commodity = detail.Commodity,
                    RatePerMile = detail.RatePerMile,
                    DeliverByDate = detail.DeliverByDate,
                    LoadCovered = detail.LoadCovered,
                };
            return View(model);

        }
        //PUT: Edit Load
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LoadEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if(model.LoadID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateLoadService();
            if (service.UpdateLoad(model))
            {
                TempData["SaveResult"] = "Your load was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your load could not be updated.");
            return View();
        }
        //Delete Load
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateLoadService();
            var model = svc.GetLoadById(id); 

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteLoad(int id)
        {
            var service = CreateLoadService();
            service.DeleteLoad(id);
            TempData["SaveResult"] = "Your load was deleted";
            return RedirectToAction("Index");
        }

        //Helper method
        private LoadService CreateLoadService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LoadService(_userId);
            return service;
        }
        
    }
}