using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.DAL;
using WebApplication2.Models;

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
            if(ModelState.IsValid)
            {
                var it = Request["Items"];
                var item = db.Items.Where(x => x.Name == it).SingleOrDefault();

                InvoiceModel invoice = new InvoiceModel();
                invoice.Status = "Unpaid";
                invoice.Amount = item.Price;
                invoice.Date = DateTime.Today;
                invoice.CVC = 100;


                rent.Status = "something";
                rent.Invoice = invoice;
                rent.Item = item;
                rent.Comments = item.Description;

                db.Invoices.Add(invoice);
                db.Rents.Add(rent);
                db.SaveChanges();
                return RedirectToAction("RentList");
            }
            return View();
        }
    }
}