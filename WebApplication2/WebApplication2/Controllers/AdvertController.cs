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
    public class AdvertController : Controller
    {
        private DBcontext db = new DBcontext();


        public ActionResult Edit(int Id)
        {
            //Get the student from studentList sample collection for demo purpose.
            //Get the student from the database in the real application
            var std = db.Adverts.ToList().Where(s => s.Id == Id).FirstOrDefault();

            return View(std);
        }

        public ActionResult Create()
        {
            var std = new AdvertModel();

            return View(std);
        }

        [HttpPost]
        public ActionResult Edit(AdvertModel std)
        {
            if (ModelState.IsValid)
            {
                var advert = db.Adverts.ToList().Where(s => s.Id == std.Id).FirstOrDefault();
                advert.Description = std.Description;
                advert.Price = std.Price;
                advert.Status = std.Status;
                advert.Title = std.Title;
                advert.Valid_from = std.Valid_from;
                advert.Valid_to = std.Valid_to;

                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Create(AdvertModel std)
        {
            if (ModelState.IsValid)
            {

                AdvertModel data = new AdvertModel
                {
                    Valid_from = std.Valid_from,
                    Valid_to = std.Valid_to,
                    Title = std.Title,
                    Price = std.Price,
                    Status = std.Status,
                    Description = std.Description
                };

                string sql = @"insert into dbo.Advert (Valid_from, Valid_to, Title, Price, Status, Description) values (@Valid_from, @Valid_to, @Title, @Price, @Status, @Description);";

                SqlDataAccess.SaveData(sql, data);

                return RedirectToAction("Index", "Home");

            }

            return View();
        }

        public ActionResult ViewAdvertList()
        {
            return View(db.Adverts.ToList());
        }

        //[HttpGet]
        //public ActionResult Details(double id)
        //{
        //    ViewBag.Message = "Auctions List";

        //    var data = LoadAuctions();
        //    List<AdvertModel> auctions = new List<AdvertModel>();

        //    foreach (var row in data)
        //    {
        //        if (id == row.Id)
        //        {
        //            auctions.Add(new AdvertModel
        //            {
        //                Date = row.Date,
        //                End_Date = row.End_Date,
        //                Status = row.Status,
        //                Description = row.Description,
        //                Price = row.Price
        //            });
        //        }
        //    }


        //    return View(auctions);
        //}

        public ActionResult Details(int Id)
        {
            var std = db.Adverts.ToList().Where(s => s.Id == Id).FirstOrDefault();

            return View(std);
        }



        // GET: Advert
        public ActionResult Index()
        {
            return View();
        }
    }
}