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
    public class TransactionController : Controller
    {
        // GET: Transaction
        public ActionResult Index()
        {
            var service = CreateTransactionService();
            var model = service.GetTransactions();
            return View(model);
        }

        // GET: Transaction/Details
        public ActionResult Details(int id)
        {
            var svc = CreateTransactionService();
            var transaction = svc.GetTransactionById(id);
            return View(transaction);
        }

        // GET: Transaction/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transaction/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTransaction(TransactionCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTransactionService();

            if (service.CreateTransaction(model))
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Shipper/Edit            ------Not sure I want there to be an option to edit a Transaction just yet.
        //public ActionResult Edit(int id)
        //{
        //    var service = CreateTransactionService();
        //    var detail = service.GetTransactionById(id);
        //    var model =
        //        new TransactionEdit
        //        {
        //            CompanyName = detail.CompanyName,
        //            Address = detail.Address,
        //        };
        //    return View(model);
        //}

        //// POST: Transaction/Edit/
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, TransactionEdit model)
        //{
        //    if (!ModelState.IsValid) return View(model);
        //    if (model.ShipperID != id)
        //    {
        //        ModelState.AddModelError("", "Id Mismatch");
        //        return View(model);
        //    }
        //    var service = CreateTransactionService();
        //    if (service.UpdateTransaction(model))
        //    {
        //        TempData["SaveResult"] = "Transaction detail was updated.";
        //        return RedirectToAction("Index");
        //    }
        //    ModelState.AddModelError("", "Transaction could not be updated.");
        //    return View();
        //}

        // GET: Transaction/Delete
        public ActionResult Delete(int id)
        {
            var svc = CreateTransactionService();
            var model = svc.GetTransactionById(id);

            return View(model);
        }

        // POST: Shipper/Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTransaction(int id)
        {
            var service = CreateTransactionService();
            service.DeleteTransaction(id);
            TempData["SaveResult"] = "Transaction was deleted";
            return RedirectToAction("Index");
        }

        //Helper method
        private TransactionService CreateTransactionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TransactionService(userId);
            return service;
        }
    }
}
