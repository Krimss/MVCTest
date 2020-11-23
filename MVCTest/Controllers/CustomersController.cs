using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MVCTest.Models;
using MVCTest.Models.ModelView;
using Newtonsoft.Json;

namespace MVCTest.Controllers
{
    public class CustomersController : Controller
    {
        IGenericRepository<Customer> customerRepository;
        IGenericRepository<Founder> founderRepository;
     
        public CustomersController(IGenericRepository<Customer> rep, IGenericRepository<Founder> rep2) {
            customerRepository = rep;
            founderRepository = rep2;
        }
        public IActionResult Index()
        {
            return View(customerRepository.Get());
        }
        public IActionResult AddCustomer() {
            return View(new GenericModelView<Customer> { Model = new Customer { CustomerID = 0 } });
        }
        [HttpPost]
        public ViewResult AddCustomer(GenericModelView<Customer> customer) {
            customer.Model.DateAdd = DateTime.Now;
            customer.Model.DateUpdate = DateTime.Now;
            if (customer.Model.Type == "Индивидуальный предприниматель" && customer.BindId.Count > 1) {
                ModelState.AddModelError("","Для типа индивидуальный предприниматель может быть только один основатель");
            }
            else {
                var fs = new List<Founder>();
                foreach (var f in customer.BindId)
                {
                    fs.Add(founderRepository.GetById(f));
                }
                customer.Model.Founders= fs;
            }
            if (ModelState.IsValid)
            {
                customerRepository.Save(customer.Model);
                return View("Added");
            }
            else
                return View();
        }
        public IActionResult Edit(int customerID) {
            var c = customerRepository.GetById(customerID);

            return View("AddCustomer", new GenericModelView<Customer> {Model=c,BindId= c.Founders.Select(x=>x.FounderID).ToList() });
        }

        [HttpPost]
        public ViewResult Edit(GenericModelView<Customer> customer) {
            customer.Model.DateUpdate = DateTime.Now;
            if (customer.Model.Type == "Индивидуальный предприниматель" && customer.BindId.Count > 1)
            {
                ModelState.AddModelError("", "Для типа индивидуальный предприниматель может быть только один основатель");
            }
            else
            {
                var fs = new List<Founder>();
                foreach (var f in customer.BindId)
                {
                    fs.Add(founderRepository.GetById(f));
                }
                customer.Model.Founders=fs;
            }
            if (ModelState.IsValid)
            {
                customerRepository.Update(customer.Model);

                ViewBag.message = "Изменён";
                ViewBag.message1 = "Изменить";
                return View("Added");
            }
            else return View("AddCustomer",customer);
        }

        [HttpPost]
        public JsonResult Customers([FromBody] object request)
        {
            var id = JsonConvert.DeserializeObject<Dictionary<string, int>>(request.ToString())["id"];
            var f = Json(customerRepository.Get()
                    .Select(f => new {
                        ID = f.CustomerID,
                        fio = f.name,
                        isSelected = f.Founders.Select(x => x.FounderID).Contains(id)
                    }));
            return f;
        }
    }
}
