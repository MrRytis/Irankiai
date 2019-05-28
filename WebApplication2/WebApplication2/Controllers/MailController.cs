using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Web.Mvc;
using System.Net;
using WebApplication2.DAL;

namespace WebApplication2.Controllers
{
    public class MailController : Controller
    {
        private static DBcontext db = new DBcontext();

        public static void CheckUnpaid()
        {
            var unpaid = db.Invoices.Where(x => x.Status == "Unpaid").ToList();
            if (unpaid != null)
            {
                SendMail();
            }
        }
        public static void SendMail()
        {
            MailMessage mail = new MailMessage();
            mail.To.Add("rytis.janceris@gmail.com");
            mail.From = new MailAddress("rytis.ltu@gmail.com");
            mail.Subject = "sub";

            mail.Body = "Hello, here is reminder of unpaid rent. Go to website and pay for your rent";

            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential
                 ("rytis.ltu@gmail.com", "slaptazodis123");
            smtp.Port = 587;

            //Or your Smtp Email ID and Password
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                //something fcked up
            }
        }
    }
}