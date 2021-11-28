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

        // GET: Shipper/Details
        public ActionResult Details(int id)
        {
            var svc = CreateShipperService();
            var shipper = svc.GetShipperById(id);
            return View(shipper);
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
            ModelState.AddModelError("", "Shipper not created");

            return View();
        }

        // GET: Shipper/Edit
        public ActionResult Edit(int id)
        {
            var service = CreateShipperService();
            var detail = service.GetShipperById(id);
            var model =
                new ShipperEdit
                {
                    CompanyName = detail.CompanyName,
                    Address = detail.Address,
                };
            return View(model);
        }

        // POST: Shipper/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ShipperEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.ShipperID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateShipperService();
            if (service.UpdateShipper(model))
            {
                TempData["SaveResult"] = "Shipper detail was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Shipper could not be updated.");
            return View();
        }

        // GET: Shipper/Delete
        public ActionResult Delete(int id)
        {
            var svc = CreateShipperService();
            var model = svc.GetShipperById(id);

            return View(model);
        }

        // POST: Shipper/Delete
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
