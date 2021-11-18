using Koonlight.Models;
using Koonlight.MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Koonlight.Controllers
{
    public class LoadController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Load
        public ActionResult Index()
        {
            List<Load> loadList = _db.Loads.ToList();
            List<Load> orderedList = loadList.OrderBy(load => load.LoadId).ToList();
            return View(orderedList);
        }
        //GET:Load
        public ActionResult Create()
        {
            return View();
        }
    }
}