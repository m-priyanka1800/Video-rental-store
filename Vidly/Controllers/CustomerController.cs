using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Models.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        public ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType);

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            Customer customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.ID== id);
            if (customer != null)
            {
                return View(customer);
            }
            return HttpNotFound();
        }

        public ActionResult New()
        {
            CustomerViewModel customerViewModel = new CustomerViewModel
            {
                customer = new Customer(),
                cust_membershipTypes = _context.MembershipTypes.ToList()
            };
            return View("Save", customerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                CustomerViewModel customerViewModel = new CustomerViewModel
                {
                    customer = customer,
                    cust_membershipTypes = _context.MembershipTypes.ToList()
                };
                return View("Save", customerViewModel);
            }
            if (customer.ID == 0)
                _context.Customers.Add(customer);
            else
            {
                var custInDB =_context.Customers.Single(c => c.ID == customer.ID);
                custInDB.Name = customer.Name;
                custInDB.DateofBirth = customer.DateofBirth;
                custInDB.MembershipTypeID = customer.MembershipTypeID;
                custInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();

            return RedirectToAction("Index","Customer");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.Single(c => c.ID == id);

            if (customer == null)
                return HttpNotFound();

            var newCustomerViewModel = new CustomerViewModel { customer = customer, cust_membershipTypes = _context.MembershipTypes.ToList() };            
            return View("Save",newCustomerViewModel);
        }
    }
}