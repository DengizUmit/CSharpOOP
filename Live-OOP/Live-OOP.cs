using System;

namespace YouTubeEgitim
{
    class Program
    {
        static void Main(string[] args)
        {
            ValueReferenceTypes();
            Manager();


            // IoC Container
            CustomerManager customerManager = new CustomerManager(new Customer(), new MilitaryCreditManager());
            customerManager.GiveCredit();
            CustomerManager customerManager2 = new CustomerManager(new Customer(), new TeacherCreditManager());
            customerManager.GiveCredit();
            CustomerManager customerManager3 = new CustomerManager(new Customer(), new CarCreditManager());
            customerManager.GiveCredit();


            Console.ReadLine();
        }

        private static void Manager()
        {
            CreditManager creditManager = new CreditManager(); // instance creation --> Stack, Heap(+)
            creditManager.Calculate();
            creditManager.Calculate();
            creditManager.Kredi();

            Customer customer = new Customer();
            customer.Id = 1;
            customer.City = "İstanbul";

            /*CustomerManager customerManager = new CustomerManager(customer);
            // customerManager.Save(id: 1, firstName: "Ghezal", lastName: "Eagle", natioanalIdentity: 73589);
            customerManager.Save();
            customerManager.Save();
            customerManager.Delete();*/



            Company company = new Company();
            company.Id = 3;
            company.CompanyName = "Enqura Information Technologies";
            company.TaxNumber = 10000;

            Person person = new Person();
            person.FirstName = "Abdullah";
            person.NationalIdentity = 25677;

            /*CustomerManager customerManager2 = new CustomerManager(new Company());
            CustomerManager customerManager3 = new CustomerManager(new Person());
            CustomerManager customerManager4 = new CustomerManager(new Customer());*/

            Customer c1 = new Customer();
            Customer c2 = new Person();
            Customer c3 = new Company();
        }

        private static void ValueReferenceTypes()
        {
            int number1 = 10;
            int number2 = 20;

            number1 = number2;
            number2 = 100;

            Console.WriteLine("number1");

            int[] numbers1 = new[] { 1, 2, 3 };
            int[] numbers2 = new[] { 10, 20, 30 };
            numbers1 = numbers2;

            numbers2[0] = 100;

            Console.WriteLine(numbers1[0]);
        }
    }



    class CreditManager
    {
        // sonar qube --> Test 
        public void Calculate()
        {
            Console.WriteLine("Hesaplandı.");
        }

        public void Kredi()
        {
            Console.WriteLine("Kredi verildi.");
        }
    }


    abstract class BaseCreditManager : ICreditManager
    {
        public abstract void Calculate();
        public virtual void Save()
        {
            Console.WriteLine("Kaydedildi");
        }
    }


    // Interface'in amacı yazılımdaki bağımlılıkları engellemek, if'lerden kurtulmaktır.
    interface ICreditManager
    {
        void Calculate();
        void Save();
    }

    class TeacherCreditManager : BaseCreditManager, ICreditManager
    {
        public override void Calculate()
        {
            // hesaplamalar
            Console.WriteLine("Öğretmen kredisi hesaplandı");
        }

        public override void Save()
        {
            //
            base.Save();
            //
        }

        // DRY --> Don't    Repeat    Yourself

        /*public void Save()
        {
            Console.WriteLine("Kaydedildi");
        }*/
    }

    class CarCreditManager : BaseCreditManager, ICreditManager
    {
        public override void Calculate()
        {
            // hesaplamalar
            Console.WriteLine("Araba kredisi hesaplandı");
        }

        /*public void Save()
        {
            Console.WriteLine("Kaydedildi");
        }*/
    }

    class MilitaryCreditManager : BaseCreditManager, ICreditManager
    {
        public override void Calculate()
        {
            Console.WriteLine("Asker kredisi hesaplandı");
        }

        /*public void Save()
        {
            Console.WriteLine("Kaydedildi");
        }*/
    }



    // SOLID

    class Customer
    {
        public Customer()
        {
            Console.WriteLine("müşteri nesnesi başlatıldı");
        }

        public Customer(int id, string city)
        {
            Id = id;
            City = city;
        }
        public int Id { get; set; }
        public string City { get; set; }
    }


    class Company : Customer
    {
        public string CompanyName { get; set; }
        public int TaxNumber { get; set; }
    }

    class Person : Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int NationalIdentity { get; set; }
    }



    // Katmanlı Mimariler
    class CustomerManager
    {
        private Customer _customer;
        private ICreditManager _creditManager;

        public CustomerManager(Customer customer, ICreditManager creditManager)
        {
            _customer = customer;
            _creditManager = creditManager;
        }
        public void Save()
        {
            Console.WriteLine("Müşteri kaydedildi");
        }
        public void Delete()
        {
            Console.WriteLine("Müşteri silindi");
        }

        public void GiveCredit()
        {
            _creditManager.Calculate();
            Console.WriteLine("Kredi verildi");
        }
    }
}
