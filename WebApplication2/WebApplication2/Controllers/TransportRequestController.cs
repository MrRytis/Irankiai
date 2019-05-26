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
            return View(db.TransportRequests.ToList().Where(x => x.Status.Equals("Not approved")));
        }
    }
}