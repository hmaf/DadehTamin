using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadehTamin_DataAccess.Data;
using DadehTamin_Model.Models;
using Newtonsoft.Json;

namespace DadehTamin.Controllers
{
    public class CustomerController : Controller
    {
        private MyContext _context;

        public CustomerController(MyContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult List()
        {
            var res = _context.Customers.ToList();
            
            return PartialView(res);
        }

        public IActionResult Update(int id)
        {
            var customer = _context.Customers.Find(id);
            return PartialView(customer);
        }
        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return View("Index");
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Json("create");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var res= _context.Customers.Find(id);
            _context.Customers.Remove(res);
            _context.SaveChanges();
            return View("Index");
        }
    }
}
