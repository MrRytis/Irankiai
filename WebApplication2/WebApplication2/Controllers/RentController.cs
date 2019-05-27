using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.DAL;
using WebApplication2.Models;
using MvcFlashMessages;

namespace WebApplication2.Controllers
{
    public class RentController : Controller
    {
        private DBcontext db = new DBcontext();

        // GET: Rent
        public ActionResult RentList()
        {
            return View(db.Rents.ToList());
        }

        public ActionResult DeclineRent(int id)
        {
            var Rent = db.Rents.Find(id);
            db.Rents.Remove(Rent);
            db.SaveChanges();
            this.Flash("success", "Removed!");
            return RedirectToAction("RentList");
        }

        public ActionResult Rent()
        {
            var items = db.Items.ToList();
            List<string> selection = new List<string>();
            foreach (var item in items)
            {
                selection.Add(item.Name);
            }
            
            ViewData["selection"] = selection;
            return View();
        }

        [HttpPost]
        public ActionResult Rent(RentModel rent)
        {
            var items = db.Items.ToList();
            List<string> selection = new List<string>();
            foreach (var item in items)
            {
                selection.Add(item.Name);
            }
            ViewData["selection"] = selection;

            if (ModelState.IsValid)
            {
                if (Request["Items"] != null || rent.StartDate > rent.EndDate)
                {
                    var it = Request["Items"];
                    var item = db.Items.Where(x => x.Name == it).SingleOrDefault();

                    InvoiceModel invoice = new InvoiceModel();
                    invoice.Status = "Unpaid";
                    invoice.Amount = item.Price * (rent.EndDate - rent.StartDate).TotalDays;
                    invoice.Date = DateTime.Today;
                    invoice.CVC = 100;
                    invoice.CardOwner = "-";
                    invoice.Card = 0;

                    var checkBox = Request.Form["checkBox"];

                    if (checkBox!= null)
                    {
                        TransportRequestModel transport = new TransportRequestModel();
                        transport.Delivery_Time = rent.StartDate;
                        transport.Pickup_Time = rent.StartDate;
                        transport.Status = "Created";
                        db.TransportRequests.Add(transport);
                        rent.Transport = transport;
                    }

                    rent.Status = "In rent";
                    rent.Invoice = invoice;
                    rent.Item = item;
                    rent.Comments = item.Description;                   

                    db.Invoices.Add(invoice);
                    db.Rents.Add(rent);
                    db.SaveChanges();
                    this.Flash("success", "Added!");
                    return RedirectToAction("RentList");
                }
                this.Flash("error", "Failed!");
                return View();
            }
            this.Flash("error", "Failed!");
            return View();
        }
    }
}