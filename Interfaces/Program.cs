using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {




            ICustomerDal[] customerDals = new ICustomerDal[3]
            {
                new OracleCustomerDal(),
                new SqlServerCustomerDal(),
                new MySqlCustomerDal()
            };

            foreach (var customerDal in customerDals)
            {
                customerDal.Add();
            }




            /*
            CustomerManager customerManager = new CustomerManager();
            customerManager.Add(new OracleCustomerDal());
            customerManager.Add(new SqlServerCustomerDal());
            customerManager.Add(new MySqlCustomerDal());
            */




            PersonManager personManager = new PersonManager();

            Customer customer = new Customer()
            {
                Id = 1,
                FirstName = "Emre",
                LastName = "Erme",
                Address = "Manhattan"
            };

            Console.ReadLine();

            Student student = new Student()
            {
                Id = 1,
                FirstName = "Derin",
                LastName = "Gökyüzü",
                Department = "Software Developer"
            };

            personManager.Add(customer);
            personManager.Add(student);

            Console.ReadLine();
        }


        interface IPerson
        {
            int Id { get; set; }
            string FirstName { get; set; }
            string LastName { get; set; }

        }

        class Customer : IPerson
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public string Address { get; set; }
        }

        class Student : IPerson
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public string Department { get; set; }
        }

        class PersonManager
        {
            public void Add(IPerson person)
            {
                Console.WriteLine(person.FirstName);
            }
        }

    }
}
