using FundamentalsMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Mvc;

namespace FundamentalsMVC.Controllers
{
    public class HomeController : Controller
    {
        ObjectCache cache = MemoryCache.Default;
        List<Customer> customers;

        public HomeController()
        {
            customers = cache["customers"] as List<Customer>;
            if (customers == null)
            {
                customers = new List<Customer>();
            }
        }

        public void SaveCache()
        {
            cache["customers"] = customers;
        }

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

        public ActionResult ViewCustomer(string id)
        {
            Customer customer = customers.FirstOrDefault(c => c.Id == id);
            if(customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            customer.Id = Guid.NewGuid().ToString();
            customers.Add(customer);
            SaveCache();

            return RedirectToAction("CustomerList");
        }

        public ActionResult EditCustomer(string id)
        {
            Customer customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        [HttpPost]
        public ActionResult EditCustomer(Customer customer, string id)
        {
            var customerToEdit = customers.FirstOrDefault(c => c.Id == id);
            if (customerToEdit == null)
            {
                return HttpNotFound();
            }
            customerToEdit.Name = customer.Name;
            customerToEdit.Telephone = customer.Telephone;
            SaveCache();

            return RedirectToAction("CustomerList");
        }

        public ActionResult DeleteCustomer(string id)
        {
            Customer customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        [HttpPost]
        [ActionName("DeleteCustomer")]
        public ActionResult ConfirmDeleteCustomer(string id)
        {
            Customer customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            customers.Remove(customer);

            return RedirectToAction("CustomerList");
        }

        public ActionResult CustomerList()
        {
            return View(customers);
        }
    }
}