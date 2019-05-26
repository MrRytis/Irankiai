using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using DataLibrary.Logic;
using WebApplication2.Models;
using static DataLibrary.Logic.Processor;
using BidModel = DataLibrary.Models.BidModel;

namespace WebApplication2.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PayForBid()
        {
            ViewData["Message"] = "Pay for bid";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PayForBid(BidModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateBid(model.Card,
                    model.Date);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }




        public ActionResult ViewPayForBid()
        {
            ViewData["Message"] = "Pay for bid.";

            return View();
        }
    }
}