using System;

namespace RecapDemo2
{
    class Program
    {
        static void Main(string[] args)
        {

            CustomerManager customerManager = new CustomerManager();

            //customerManager.Logger = new DatabaseLogger();
            //customerManager.Logger = new MailLogger();
            //customerManager.Logger = new CustomerManager();

            customerManager.Logger = new FileLogger();

            customerManager.Add();

            Console.ReadLine();
        }
    }


    class CustomerManager
    {

        public ILogger Logger { get; set; }

        public void Add()
        {
            Logger.Log();
            Console.WriteLine("Customer added!");
        }
    }



    class DatabaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to database!");
        }
    }

    class FileLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to file!");
        }
    }

    class MailLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to mail!");
        }
    }

    class SmsLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to sms!");
        }
    }


    interface ILogger
    {
        void Log();
    }
}
