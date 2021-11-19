using FundamentalsMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FundamentalsMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        public ActionResult CustomerList()
        {
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer() { Name = "Bruno", Telephone = "99999999999" });
            customers.Add(new Customer() { Name = "Lara", Telephone = "99999999888" });

            return View(customers);
        }
    }
}