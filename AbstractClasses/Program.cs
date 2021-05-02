using System;

namespace AbstractClasses
{
    class Program
    {
        static void Main(string[] args)
        {

            Database database = new Oracle();
            database.Add();
            database.Delete();

            Database database2 = new SqlServer();
            database2.Add();
            database2.Delete();

            Database database3 = new PostgreSql();
            database3.Add();
            database3.Delete();

            Console.ReadLine();
        }
    }

    abstract class Database
    {
        public void Add()
        {
            Console.WriteLine("Added by default");
        }
        public abstract void Delete();
    }

    class SqlServer : Database
    {
        public override void Delete()
        {
            Console.WriteLine("Deleted by SqlServer");
        }
    }
    class Oracle : Database
    {
        public override void Delete()
        {
            Console.WriteLine("Deleted by Oracle");
        }
    }

    class PostgreSql : Database
    {
        public override void Delete()
        {
            Console.WriteLine("Deleted by PostgreSql");
        }
    }
}
