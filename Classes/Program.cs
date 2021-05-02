using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Add();
            customerManager.Read();
            customerManager.Update();
            customerManager.Delete();

            Console.ReadLine();

            ProductManager productManager = new ProductManager();
            productManager.Add();
            productManager.Read();
            productManager.Update();
            productManager.Delete();

            Console.ReadLine();

            Customer customer = new Customer();
            customer.Id = 1;
            customer.FirstName = "Cem";
            customer.LastName = "Kırmızı";
            customer.City = "Argentina";

            //other
            Customer customer2 = new Customer()
            {
                Id = 2, FirstName = "Yılmaz", LastName = "Turuncu", City = "Cuba"
            };

            Console.WriteLine(customer.City);
            Console.WriteLine(customer2.City);

            Console.ReadLine();
        }
    }
}
