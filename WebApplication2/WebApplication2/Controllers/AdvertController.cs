using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AdvertController : Controller
    {



        List<AdvertModel> advertlist = new List<AdvertModel>() {
                    new AdvertModel(){Id=4, Valid_from=Convert.ToDateTime("11/23/2010"), Valid_to = Convert.ToDateTime("11/23/2019"),Title = "HEHE",  Status = "On", Description = "aaaa", Price = 12 },
                    new AdvertModel(){Id=4,Valid_from=Convert.ToDateTime("11/23/2011"), Valid_to = Convert.ToDateTime("11/23/2019"),Title = "HEHE", Status = "On", Description = "aaaa", Price = 12 },
                    new AdvertModel(){Id=4,Valid_from=Convert.ToDateTime("11/23/2012"), Valid_to = Convert.ToDateTime("11/23/2019"),Title = "HEHE", Status = "On", Description = "aaaa", Price = 12 }
                    //new AuctionModel(){ Id=4, Date=Convert.ToDateTime("10/23/2010"), End_Date = Convert.ToDateTime("11/23/2019"), Status = "On", Description = "aaaa", Price = 12 },
                    //new AuctionModel(){ Id=5, Date=Convert.ToDateTime("09/17/2010"), End_Date = Convert.ToDateTime("11/23/2019"), Status = "On", Description = "aaaa", Price = 12 },
                    //new AuctionModel(){ Id=6, Date=Convert.ToDateTime("12/23/2010"), End_Date = Convert.ToDateTime("11/23/2019"), Status = "On", Description = "aaaa", Price = 12 },
                    //new AuctionModel(){ Id=7, Date=Convert.ToDateTime("10/13/2010"), End_Date = Convert.ToDateTime("11/23/2019"), Status = "On", Description = "aaaa", Price = 12 }
                    
                };

        public ActionResult Edit(int Id)
        {
            //Get the student from studentList sample collection for demo purpose.
            //Get the student from the database in the real application
            var std = advertlist.Where(s => s.Id == Id).FirstOrDefault();

            return View(std);
        }

        [HttpPost]
        public ActionResult Edit(AdvertModel std)
        {
            //write code to update student 

            return RedirectToAction("Index");
        }
        
        public ActionResult ViewAdvertList()
        {
            return View(advertlist);
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

            var std = advertlist.Where(s => s.Id == Id).FirstOrDefault();

            return View(std);
        }



        // GET: Advert
        public ActionResult Index()
        {
            return View();
        }
    }
}