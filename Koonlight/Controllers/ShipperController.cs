using Koonlight.Models;
using Koonlight.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Koonlight.Controllers
{
    public class ShipperController : Controller
    {
        // GET: Shipper
        public ActionResult Index()
        {
            var service = CreateShipperService();
            var model = service.GetShippers();
            return View(model);
        }

        // GET: Shipper/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Shipper/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shipper/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateShipper(ShipperCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateShipperService();

            if (service.CreateShipper(model))
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Shipper/Edit/5
        public ActionResult Edit(int id)
        {

            return View();
        }

        // POST: Shipper/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var service = CreateShipperService();
            var detail = service.GetShipperById(id);
            var model =
                new ShipperEdit
                {
                    CompanyName = detail.CompanyName,
                    Address = detail.Address,
                };
            return View();
            
        }

        // GET: Shipper/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Shipper/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteShipper(int id)
        {
            var service = CreateShipperService();
            service.DeleteShipper(id);
            TempData["SaveResult"] = "Shipper was deleted";
            return RedirectToAction("Index");
        }
        
        //Helper method
        private ShipperService CreateShipperService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ShipperService(userId);
            return service;
        }
    }
}
