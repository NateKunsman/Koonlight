using Koonlight.Models;
using Koonlight.MVC.Data;
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
        // GET: Load
        public ActionResult Index()
        {
            var model = new LoadList[0];
            return View(model);
        }
        //GET:Load
        public ActionResult Create()
        {
            return View();
        }
    }
}