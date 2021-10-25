using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DadehTamin_DataAccess.Utility;
using DadehTamin_Model.Models;
using Microsoft.Data.SqlClient;

namespace DadehTamin_DataAccess.Data
{
    public class CustomerDataAccessLayer
    {
        private string connectionString = ConnectionString.CName;

        public IEnumerable<Customer> GetAllCustomers()
        {
            List<Customer> lstCustomers = new List<Customer>();
            using (SqlConnection con=new SqlConnection(connectionString))
            {
                SqlCommand cmd=new SqlCommand("cpGetAllCustomers",con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Customer customer=new Customer();
                    customer.Customer_Id = Convert.ToInt32(rdr["Customer_Id"]);
                    customer.Name = rdr["Name"].ToString();
                    customer.Family = rdr["Family"].ToString();
                    customer.BirthDate = Convert.ToDateTime(rdr["BirthDate"]); 
                    customer.City = rdr["City"].ToString();
                    customer.Child = Convert.ToInt32(rdr["Child"]);

                    lstCustomers.Add(customer);
                }
                con.Close();
            }

            return lstCustomers;
        }

        public void AddCustomer(Customer customer)
        {
            using (SqlConnection con=new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("cpAddCustomers", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", customer.Name);
                cmd.Parameters.AddWithValue("@Family", customer.Family);
                cmd.Parameters.AddWithValue("@BirthDate", customer.BirthDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@City", customer.City);
                cmd.Parameters.AddWithValue("@Child", customer.Child);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            using (SqlConnection con =new SqlConnection(connectionString))
            {
                SqlCommand cmd=new SqlCommand("cpUpdateCustomers", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Customer_Id", customer.Customer_Id);
                cmd.Parameters.AddWithValue("@Name", customer.Name);
                cmd.Parameters.AddWithValue("@Family", customer.Family);
                cmd.Parameters.AddWithValue("@BirthDate", customer.BirthDate);
                cmd.Parameters.AddWithValue("@City", customer.City);
                cmd.Parameters.AddWithValue("@Child", customer.Child);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Customer GetCustomerDate(int? id)
        {
            Customer customer=new Customer();

            using (SqlConnection con=new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Customers WHERE Customer_Id= " + id;
                SqlCommand cmd=new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    customer.Customer_Id = Convert.ToInt32(rdr["Customer_Id"]);  
                    customer.Name = rdr["Name"].ToString();
                    customer.Family = rdr["Family"].ToString();
                    customer.BirthDate = Convert.ToDateTime(rdr["BirthDate"]);
                    customer.City = rdr["City"].ToString();
                    customer.Child = Convert.ToInt32(rdr["Child"]);
                }
            }

            return customer;
        }

        public void DeleteCustomer(int? id)
        {
            using (SqlConnection con=new SqlConnection(connectionString))
            {
                SqlCommand cmd=new SqlCommand("cpDeleteCustomers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Customer_Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
