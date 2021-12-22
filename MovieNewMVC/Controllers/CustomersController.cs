using MovieNewMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MovieNewMVC.ViewModel;

namespace MovieNewMVC.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Customers
        public ActionResult Index()
        {
            //var customers = _context.Customers.ToList();

            // var customers = _context.Customers.Include(c => c.MembershipType).ToList(); // commented because we r fetching this data from API
            //var customers = GetCustomers();

            // return View(customers); // commented because of API
            return View();
        }
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }
        // we got 3 error msgs, customerId is required, so we need to initialize customer in this procedure
        public ActionResult New()
        {
            var membership = _context.Memberships.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                // so its properties will be intialize and customerId will be zero ,not black
                Memberships = membership
            };
            return View("CustomerForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create(Customer customer)
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    Memberships = _context.Memberships.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if(customer.Id == 0 )
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                // now we need to update properties based on values on the form 
                //TryUpdateModel(customerInDb,"", new string[] {"Name","Email" }); // wit this the properties of this customer will be updated
                // on the based of key-value pair
                // don't use above approach,type manually all property 
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipId = customer.MembershipId;
                customerInDb.IsSunscribedToNewsletter = customer.IsSunscribedToNewsletter;
                // If you don't want to type all property then you can use auto mapper
                //Mapper.Map(customer, customerInDb);
                // so its look property in customer and map with same name in target object customerInDb
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                Memberships = _context.Memberships.ToList()
            };
            return View("CustomerForm",viewModel); // for this New View , we need ViewModel
        }
        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer {Id=1, Name ="John Smith"},
                new Customer {Id =2, Name="Marry Smith"}
            };
        }

    }
}