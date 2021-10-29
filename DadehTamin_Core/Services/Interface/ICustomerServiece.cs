using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DadehTamin_Core.DTOs.Customer;
using DadehTamin_Model.Models;

namespace DadehTamin_Core.Services
{
    public interface ICustomerServiece
    {
        Tuple<List<Customer>,int> GetAllCustomer(int pageId=1);
        void AddCustomer(CustomerViewModel customer);
        void DeleteCustomer(int id);
        void EditCustomer(CustomerViewModel customer);
        Customer GetCustomerById(int id);
    }
}
