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
        // GET: Load
        public ActionResult Index()
        {
            var service = CreateLoadService();
            var model = service.GetLoads();

            return View(model);
        }
        //GET:Load
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

        private LoadService CreateLoadService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LoadService(_userId);
            return service;
        }
    }
}