using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadehTamin_DataAccess.Data;
using DadehTamin_Model.Models;

namespace DadehTamin.Controllers
{
    public class CustomersByAdoController : Controller
    {
        CustomerDataAccessLayer _customerDataAccessLayer=null;

        public CustomersByAdoController()
        {
            _customerDataAccessLayer=new CustomerDataAccessLayer();
        }
        // GET: CustomersByAdoController
        public ActionResult Index()
        {
            int take = 4;
            int count = _customerDataAccessLayer.GetAllCustomers().Count();
            ViewBag.pageCount = count/take;
            return View();
        }

        public IActionResult List(int pageid=1)
        {
            int take = 4;
            int skip = (pageid -1)*take;
            int count = _customerDataAccessLayer.GetAllCustomers().Count();
            ViewBag.pageId = pageid;
            var result = _customerDataAccessLayer.GetAllCustomers().OrderBy(c=>c.Customer_Id).Skip(skip).Take(take).ToList();
            return PartialView(result);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            
            _customerDataAccessLayer.AddCustomer(customer);
            return Json("create");
        }

        // GET: CustomersByAdoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomersByAdoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: CustomersByAdoController/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
             _customerDataAccessLayer.DeleteCustomer(id);
            return Json("");
        }
    }
}
