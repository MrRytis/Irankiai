﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        public ActionResult InvoiceForm()
        {
            return View();
        }
    }
}