using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using DataLibrary.DataAccess;
using DataLibrary.Logic;
using WebApplication2.DAL;
using WebApplication2.Models;
using static DataLibrary.Logic.Processor;

namespace WebApplication2.Controllers
{
    public class AuctionController : Controller
    {

        private DBcontext db = new DBcontext();


        //List<AuctionModel> auctionList = new List<AuctionModel>() {
          //          new AuctionModel(){ Id=4, Date=Convert.ToDateTime("11/23/2010"), End_Date = Convert.ToDateTime("11/23/2019"), Status = "On", Description = "aaaa", Price = 12 },
           //         new AuctionModel(){ Id=5, Date=Convert.ToDateTime("11/23/2011"), End_Date = Convert.ToDateTime("11/23/2019"), Status = "On", Description = "aaaa", Price = 12 },
             //       new AuctionModel(){ Id=6, Date=Convert.ToDateTime("11/23/2012"), End_Date = Convert.ToDateTime("11/23/2019"), Status = "On", Description = "aaaa", Price = 12 }
                    //new AuctionModel(){ Id=4, Date=Convert.ToDateTime("10/23/2010"), End_Date = Convert.ToDateTime("11/23/2019"), Status = "On", Description = "aaaa", Price = 12 },
                    //new AuctionModel(){ Id=5, Date=Convert.ToDateTime("09/17/2010"), End_Date = Convert.ToDateTime("11/23/2019"), Status = "On", Description = "aaaa", Price = 12 },
                    //new AuctionModel(){ Id=6, Date=Convert.ToDateTime("12/23/2010"), End_Date = Convert.ToDateTime("11/23/2019"), Status = "On", Description = "aaaa", Price = 12 },
                    //new AuctionModel(){ Id=7, Date=Convert.ToDateTime("10/13/2010"), End_Date = Convert.ToDateTime("11/23/2019"), Status = "On", Description = "aaaa", Price = 12 }
                    
             //   };

        // GET: Student
        //Deprecated
        public ActionResult Index()
        {
            return View(db.Auctions.ToList());
        }


        public ActionResult EditPrice(int Id)
        {
            //Get the student from studentList sample collection for demo purpose.
            //Get the student from the database in the real application
            var std = db.Auctions.ToList().Where(s => s.Id == Id).FirstOrDefault();

            return View(std);
        }

        [HttpPost]
        public ActionResult EditPrice(AuctionModel std)
        {
            var auction = db.Auctions.ToList().Where(s => s.Id == std.Id).FirstOrDefault();
            if (ModelState.IsValid && std.Price > auction.Price)
            {
                
                auction.Price = std.Price;

                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View();
        }



        public ActionResult Edit(int Id)
        {
            //Get the student from studentList sample collection for demo purpose.
            //Get the student from the database in the real application
            var std = db.Auctions.ToList().Where(s => s.Id == Id).FirstOrDefault();

            return View(std);
        }

        [HttpPost]
        public ActionResult Edit(AuctionModel std)
        {
            if (ModelState.IsValid)
            {
                var auction = db.Auctions.ToList().Where(s => s.Id == std.Id).FirstOrDefault();
                auction.Date = std.Date;
                auction.End_Date = std.End_Date;
                auction.Status = std.Status;
                auction.Description = std.Description;
                auction.Price = std.Price;

                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public ActionResult Create()
        {
            var std = new AuctionModel();

            return View(std);
        }

        [HttpPost]
        public ActionResult Create(AuctionModel std)
        {
            if (ModelState.IsValid)
            {

                AuctionModel data = new AuctionModel
                {
                    Date = std.Date,
                    End_Date = std.End_Date,
                    Status = std.Status,
                    Description = std.Description,
                    Price = std.Price 
                };

                string sql = @"insert into dbo.Auction (Date, End_Date, Status, Description, Price) values (@Date, @End_Date, @Status, @Description, @Price);";

                SqlDataAccess.SaveData(sql, data);

                return RedirectToAction("Index", "Home");

            }

            return View();
        }

        //deprecated
        public ActionResult AuctionSignUp()
        {
            ViewData["Message"] = "Auction Sign Up";

            return View();
        }

        //deprecated
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AuctionSignUp(AuctionModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateAuction(model.Date,
                    model.End_Date,
                    model.Status,
                    model.Description,
                    model.Price);
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult ViewAuctions()
        {
            return View(db.Auctions.ToList());
        }

        public ActionResult Details(int Id)
        {
            var std = db.Auctions.ToList().Where(s => s.Id == Id).FirstOrDefault();

            return View(std);
        }

        //What???
        //deprecated
        [HttpGet]
        public ActionResult ViewAuction(double price = 123)
        {
            ViewBag.Message = "Auctions List";

            var data = LoadAuctions();
            List<AuctionModel> auctions = new List<AuctionModel>();

            foreach (var row in data)
            {
                if (price == row.Price)
                {
                    auctions.Add(new AuctionModel
                    {
                        Date = row.Date,
                        End_Date = row.End_Date,
                        Status = row.Status,
                        Description = row.Description,
                        Price = row.Price
                    });
                }
            }


            return View(auctions);
        }

    }
}