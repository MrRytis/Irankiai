using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class RentController : Controller
    {
        
        List<RentModel> data = new List<RentModel>()
        {
            new RentModel() {Id=1, EndDate=Convert.ToDateTime("2015/11/23"), StartDate=Convert.ToDateTime("2015/11/23"), Status="In process", Comments="In perfect condition", Invoice=new InvoiceModel() { Id = 1, Amount = 12.25, Date = Convert.ToDateTime("2018/11/23"), Status = "Unpaid" }, Item = new ItemModel() { Id = 1, Description = null, Image = null, Name = "Sony XM3", Price = 2.25 } }
        };

        // GET: Rent
        public ActionResult RentList()
        {
            //Get list data
            return View(data);
        }

        public ActionResult DeclineRent(int id)
        {
            //remove items from list
            return RedirectToAction("RentList");
        }

        public ActionResult Rent()
        {
            List<string> selection = new List<string>() { "a", "b", "c" };
            ViewData["selection"] = selection;
           
            return View();
        }
    }
}