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
    public class FoundersController : Controller
    {
        IGenericRepository<Customer> customerRepository;
        IGenericRepository<Founder> founderRepository;
       
        public FoundersController(IGenericRepository<Customer> rep, IGenericRepository<Founder> rep2)
        {
            customerRepository = rep;
            founderRepository = rep2;
        }
        public IActionResult Index()
        {
            return View(founderRepository.Get());
        }
        public IActionResult AddFounder()
        {
            return View(new GenericModelView<Founder> { Model=new Founder {FounderID=0 } });
        }
        [HttpPost]
        public ViewResult AddFounder(GenericModelView<Founder> founder)
        {
            founder.Model.DateAdd = DateTime.Now;
            founder.Model.DateUpdate = DateTime.Now;
            var cs = new List<Customer>();
            foreach (var f in founder.BindId)
            {
                cs.Add(customerRepository.GetById(f));
            }
            founder.Model.Customers = cs;
            if (ModelState.IsValid)
            {
                founderRepository.Save(founder.Model);
                return View("Added");
            }
            else
                return View();
        }
        public IActionResult Edit(int founderID)
        {
            var c = founderRepository.GetById(founderID);

            return View("AddFounder", new GenericModelView<Founder> { Model = c, BindId = c.Customers.Select(x => x.CustomerID).ToList() });
        }

        [HttpPost]
        public ViewResult Edit(GenericModelView<Founder> founder)
        {
            founder.Model.DateUpdate = DateTime.Now;
            var cs = new List<Customer>();
            foreach (var f in founder.BindId)
            {
                cs.Add(customerRepository.GetById(f));
            }
            founder.Model.Customers = cs;

            if (ModelState.IsValid)
            {
                founderRepository.Update(founder.Model);
                return View("Added");
            }
            else return View("AddFounder", founder);
        }

        [HttpPost]

        public JsonResult Founders([FromBody] object request)
        {
            var id = JsonConvert.DeserializeObject<Dictionary<string, int>>(request.ToString())["id"];
            var f = Json(founderRepository.Get()
                    .Select(f => new {
                        ID = f.FounderID,
                        fio = f.FIO,
                        isSelected = f.Customers.Select(x => x.CustomerID).Contains(id)
                    }));
            return f;
        }
    }
}
