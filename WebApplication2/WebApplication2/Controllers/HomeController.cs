using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using DataLibrary.DataAccess;
using DataLibrary.Logic;
using WebApplication2.Models;
using static DataLibrary.Logic.Processor;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            MailController.SendMail();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult SubmitBid(double id)
        {
            var data = LoadAuctions();
            List<AuctionModel> auctions = new List<AuctionModel>();

            foreach (var row in data)
            {
                if (id == row.Id)
                {

                    //auctions.Add(
                    var datas =  new AuctionModel
                    {
                        Date = row.Date,
                        End_Date = row.End_Date,
                        Status = row.Status,
                        Description = row.Description,
                        Price = row.Price
                    };

                    string sql = @"insert into dbo.Auction (Date, End_Date, Status, Description, Price) values (@Date, @End_Date, @Status, @Description, @Price);";

                    SqlDataAccess.SaveData(sql, datas);

                    return RedirectToAction("Index", "Home");
                }
            }

            return View(auctions);
        }
    }
}