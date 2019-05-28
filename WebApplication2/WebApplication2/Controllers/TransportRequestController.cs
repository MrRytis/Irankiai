using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.DAL;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class TransportRequestController : Controller
    {
        private DBcontext db = new DBcontext();

        public ActionResult ViewTransportRequests()
        {
            return View(db.TransportRequests.ToList().Where(x => x.Status.Equals("Created")));
        }

        public ActionResult Routes(int Id)
        { 
            var std = db.TransportRequests.ToList().Where(s => s.Id == Id).FirstOrDefault();

            return View(std);
            
        }

        [HttpPost]
        public ActionResult Routes(TransportRequestModel std)
        {
            //if (ModelState.IsValid)
            //{
                var advert = db.TransportRequests.ToList().Where(s => s.Id == std.Id).FirstOrDefault();
                advert.Notes = std.Notes;
                //advert.Pickup_Time = std.Pickup_Time;
                //advert.Delivery_Time = std.Delivery_Time;
                advert.Status = "Paid";

                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            //}

            //return View();
        }
    }
}