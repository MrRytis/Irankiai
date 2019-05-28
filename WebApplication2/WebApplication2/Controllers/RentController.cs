using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.DAL;
using WebApplication2.Models;
using MvcFlashMessages;
using DataLibrary.DataAccess;

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

                    if (item == null)
                    {
                        this.Flash("error", "Failed!");
                        return View();
                    }

                    InvoiceModel invoice = new InvoiceModel();
                    invoice.Status = "Unpaid";
                    invoice.Amount = item.Price * (rent.EndDate - rent.StartDate).TotalDays;
                    invoice.Date = DateTime.Today;
                    invoice.CVC = 100;
                    invoice.CardOwner = "-";
                    invoice.Card = 0;

                    var checkBox = Request.Form["checkBox"];

                    string tID = null;
                    string itID = null;
                    string inID = null;
                    string inID2 = null;

                    itID = item.Id.ToString();

                    if (checkBox!= null)
                    {
                        TransportRequestModel transport = new TransportRequestModel();
                        transport.Delivery_Time = rent.StartDate;
                        transport.Pickup_Time = rent.EndDate;
                        transport.Status = "Created";
                        //db.TransportRequests.Add(transport);
                        rent.Transport = transport;

                        string sql = @"insert into dbo.Transport (Pickup_Time, Delivery_Time, Status, Notes) values (@Pickup_Time, @Delivery_Time, @Status, @Notes); SELECT MAX(ID) FROM dbo.Transport;";
                        tID = (SqlDataAccess.SaveData(sql, transport)).ToString();
                        tID = db.TransportRequests.OrderByDescending(u => u.Id).FirstOrDefault().Id.ToString();


                        InvoiceModel invoice2 = new InvoiceModel();
                        invoice2.Status = "Unpaid";
                        invoice2.Amount = item.Price * (rent.EndDate - rent.StartDate).TotalDays;
                        invoice2.Date = DateTime.Today;
                        invoice2.CVC = 100;
                        invoice2.CardOwner = "-";
                        invoice2.Card = 0;

                        string sqles = @"insert into dbo.Invoice (Amount, Date, Status, Card, CardOwner, CVC) values (@Amount, @Date, @Status, @Card, @CardOwner, @CVC); SELECT MAX(ID) FROM dbo.Invoice;";
                        inID2 = (SqlDataAccess.SaveData(sqles, invoice2)).ToString();
                        inID2 = db.Invoices.OrderByDescending(u => u.Id).FirstOrDefault().Id.ToString();
                    }

                    rent.Status = "In rent";
                    rent.Invoice = invoice;
                    rent.Item = item;
                    rent.Comments = item.Description;

                    string sqle = @"insert into dbo.Invoice (Amount, Date, Status, Card, CardOwner, CVC) values (@Amount, @Date, @Status, @Card, @CardOwner, @CVC); SELECT MAX(ID) FROM dbo.Invoice;";
                    inID = (SqlDataAccess.SaveData(sqle, invoice)).ToString();
                    inID = db.Invoices.OrderByDescending(u => u.Id).FirstOrDefault().Id.ToString();

                    if (checkBox != null)
                    {
                        sqle = @"insert into dbo.Rent (StartDate, EndDate, Comments, Transport_Id, Item_Id, Invoice_Id, InvoiceT_Id) values (@StartDate, @EndDate, @Comments, " + tID+", "+itID+", "+inID+", "+inID2+");";
                        SqlDataAccess.SaveData(sqle, rent);
                    }
                    else
                    {
                        sqle = @"insert into dbo.Rent (StartDate, EndDate, Comments, Item_Id, Invoice_Id) values (@StartDate, @EndDate, @Comments, " + itID+", "+inID+");";
                        SqlDataAccess.SaveData(sqle, rent);
                    }
                    

                    //db.Invoices.Add(invoice);
                    //db.Rents.Add(rent
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