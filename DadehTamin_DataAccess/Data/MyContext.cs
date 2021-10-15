using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DadehTamin_Model.Models;
using Microsoft.EntityFrameworkCore;

namespace DadehTamin_DataAccess.Data
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext> options):base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(new Customer()
                {
                    Customer_Id = 1,
                    Name = "هادی",
                    Family = "مفتوحی",
                    BirthDate = DateTime.Parse("1376 - 03 - 26"),
                    City = "میاندوآب",
                    Child = 0
                }, new Customer()
                {
                    Customer_Id = 2,
                    Name = "مینا",
                    Family = "رشتی",
                    BirthDate = DateTime.Parse("1379 - 08 - 22"),
                    City = "رشت",
                    Child = 2
                }, new Customer()
                {
                    Customer_Id = 3,
                    Name = "علی",
                    Family = "رضایی",
                    BirthDate = DateTime.Parse("1379 - 08 - 22"),
                    City = "تبریز",
                    Child = 0
                },new Customer()
                {
                    Customer_Id = 4,
                    Name = "احمد",
                    Family = "مولایی",
                    BirthDate = DateTime.Parse("1379 - 08 - 22"),
                    City = "تبریز",
                    Child = 1
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
