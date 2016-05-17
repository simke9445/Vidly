using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        public ViewResult Index()
        {
            var customers = GetCustomers();

            return View(customers);
        }

        public ViewResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(x => x.Id == id);

            return View(customer);
        }

        private List<Customer> GetCustomers()
        {
            return new List<Customer>()
            {
                new Customer() {Name = "Marry Jane", Id = 1},
                new Customer() {Name = "Wildy Wild", Id = 2}
            };
        } 
    }
}