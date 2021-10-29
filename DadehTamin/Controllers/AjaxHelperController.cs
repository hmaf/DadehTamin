using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadehTamin_Core.Services;

namespace DadehTamin.Controllers
{
    public class AjaxHelperController : Controller
    {
        private ICustomerServiece _customerServiece;

        public AjaxHelperController(ICustomerServiece customerServiece)
        {
            _customerServiece = customerServiece;
        }

        public IActionResult Index()
        { 
           return View();
        }

        public IActionResult ShowCustomer(int pageid=1)
        {
            return View(_customerServiece.GetAllCustomer(pageid));
        }


    }
}
