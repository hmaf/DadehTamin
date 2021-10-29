using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DadehTamin_Core.DTOs.Customer;
using DadehTamin_DataAccess.Data;
using DadehTamin_Model.Models;

namespace DadehTamin_Core.Services
{
    public class CustomerService : ICustomerServiece
    {
        private MyContext _context;

        public CustomerService(MyContext context)
        {
            _context = context;
        }


        public Tuple<List<Customer>, int> GetAllCustomer(int pageId = 1)
        {
            int take = 5;
            int skip = (pageId - 1) * take;
            int count = _context.Customers.Count() / take;

            if ((count % 2) != 0)
            {
                count += 1;
            }

            return Tuple.Create(_context.Customers.Skip(skip).Take(take)
                    .OrderByDescending(c => c.Customer_Id).ToList(), count);
        }

        public void AddCustomer(CustomerViewModel customer)
        {
            Customer c = new Customer();
            c.BirthDate = customer.BirthDate;
            c.Child = customer.Child;
            c.City = customer.City;
            c.Family = customer.Family;
            c.Name = customer.Name;
            _context.Customers.Add(c);
            _context.SaveChanges();
        }

        public void DeleteCustomer(int id)
        {
            var res = GetCustomerById(id);
            _context.Customers.Remove(res);
            _context.SaveChanges();
        }

        public void EditCustomer(CustomerViewModel customer)
        {
            var res = GetCustomerById(customer.Customer_Id);
            res.BirthDate = customer.BirthDate;
            res.Child = customer.Child;
            res.Family = customer.Family;
            res.Name = customer.Name;
            _context.Customers.Update(res);
            _context.SaveChanges();
        }

        public Customer GetCustomerById(int id)
        {
            return _context.Customers.Find(id);
        }
    }
}
