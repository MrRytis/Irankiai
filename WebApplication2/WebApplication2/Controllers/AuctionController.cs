using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using DataLibrary.Logic;
using DataLibrary.Models;
using static DataLibrary.Logic.Processor;

namespace WebApplication2.Controllers
{
    public class AuctionController : Controller
    {




        List<AuctionModel> auctionList = new List<AuctionModel>() {
                    new AuctionModel(){ Id=4, Date=Convert.ToDateTime("11/23/2010"), End_Date = Convert.ToDateTime("11/23/2019"), Status = "On", Description = "aaaa", Price = 12 },
                    new AuctionModel(){ Id=5, Date=Convert.ToDateTime("11/23/2011"), End_Date = Convert.ToDateTime("11/23/2019"), Status = "On", Description = "aaaa", Price = 12 },
                    new AuctionModel(){ Id=6, Date=Convert.ToDateTime("11/23/2012"), End_Date = Convert.ToDateTime("11/23/2019"), Status = "On", Description = "aaaa", Price = 12 }
                    //new AuctionModel(){ Id=4, Date=Convert.ToDateTime("10/23/2010"), End_Date = Convert.ToDateTime("11/23/2019"), Status = "On", Description = "aaaa", Price = 12 },
                    //new AuctionModel(){ Id=5, Date=Convert.ToDateTime("09/17/2010"), End_Date = Convert.ToDateTime("11/23/2019"), Status = "On", Description = "aaaa", Price = 12 },
                    //new AuctionModel(){ Id=6, Date=Convert.ToDateTime("12/23/2010"), End_Date = Convert.ToDateTime("11/23/2019"), Status = "On", Description = "aaaa", Price = 12 },
                    //new AuctionModel(){ Id=7, Date=Convert.ToDateTime("10/13/2010"), End_Date = Convert.ToDateTime("11/23/2019"), Status = "On", Description = "aaaa", Price = 12 }
                    
                };

        // GET: Student
        public ActionResult Index()
        {
            return View(auctionList);
        }

        public ActionResult Edit(int Id)
        {
            //Get the student from studentList sample collection for demo purpose.
            //Get the student from the database in the real application
            var std = auctionList.Where(s => s.Id == Id).FirstOrDefault();

            return View(std);
        }

        [HttpPost]
        public ActionResult Edit(AuctionModel std)
        {
            //write code to update student 

            return RedirectToAction("Index");
        }


    }
}