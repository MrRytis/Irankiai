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
    public class InvoiceController : Controller
    {
        private DBcontext db = new DBcontext();

        public ActionResult InvoiceForm(int id)
        {
            InvoiceModel invoice = db.Invoices.Find(id);
            return View(invoice);
        }

        [HttpPost]
        public ActionResult InvoiceForm(InvoiceModel newInvoice, int id)
        {
            if(ModelState.IsValid)
            {
                var invoice = db.Invoices.Find(id);
                invoice.Status = "Paid";
                invoice.Date = DateTime.Today;
                invoice.Card = newInvoice.Card;
                invoice.CardOwner = newInvoice.CardOwner;
                invoice.CVC = newInvoice.CVC;
                db.SaveChangesAsync();
                this.Flash("success", "Added!");
                return RedirectToAction("RentList", "Rent");
            }
            this.Flash("error", "Failed!");
            return View();
        }
    }
}