using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DadehTamin_DataAccess.Data;
using DadehTamin_Model.Models;
using System.Text.Json.Serialization;

namespace DadehTamin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyContext _context;

        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(int page=1)
        {
            var res = _context.Customers.ToList();
            int take = 8;
            int skip = (page - 1) * take;
            int pageCount = res.Count / take;
            int s = pageCount * 8;
            if (res.Count>s)
            {
                pageCount += 1;
            }
            ViewBag.pageCount = pageCount;
            return View();
        }
        [HttpGet]
        public JsonResult List(int page=1)
        {
            var res = _context.Customers.ToList();
            int take = 6;
            int skip = (page - 1) * take;
            int pageCount = res.Count / take;
            //var s = _context.Customers.Where(a=>a.Customer_Id==skip);
            List<Customer> customer = res.Skip(skip).Take(take).ToList();
            
            return Json(customer,new Newtonsoft.Json.JsonSerializerSettings());
        }

        public JsonResult GetId(int id)
        {
            ViewBag.id = id;
            var result = _context.Customers.Find(id);
            return Json(result, new Newtonsoft.Json.JsonSerializerSettings());
        }
        [HttpPost]
        public IActionResult Create(Customer c)
        {
            _context.Customers.Add(c);
            _context.SaveChanges();
            return Json("test");
        }

        [HttpPost]
        public JsonResult Update(Customer c)
        {
            
            return Json("ok");
        }
       
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return Json("test");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
