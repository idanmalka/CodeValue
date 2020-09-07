using System;
using System.Collections.Generic;

namespace CustomersApp
{

    public delegate bool CustomerFilter(Customer c);

    public class Program
    {
        //You should have used IEnumerable and yield.
        public static ICollection<Customer> GetCustomers(ICollection<Customer> collection, CustomerFilter filter)
        {
            List<Customer> newList = new List<Customer>();
            foreach (Customer c in collection)
            {
                if (filter(c))
                    newList.Add(c);
            }
            return newList;
        }

        public static bool Filter(Customer c)
        {
            return string.Compare(c.Name, "A", StringComparison.Ordinal) >=0 && string.Compare(c.Name, "K", StringComparison.Ordinal) <= 0;

        }
        public static void Main(string[] args)
        {
            var customers = InitializeCustomerArray();
            
            Console.WriteLine("Entire List:");

            //1. Consider extracting this to another method. You have used the same code multiple times.
            //2. The conveintion in C# is to start body expressions in a seperate line and with bracets "{ }", even for oneliners
            foreach (Customer customer in customers)
            {
                Console.WriteLine(customer);
            }

            Console.WriteLine("\nFiltered A-K List:");
            CustomerFilter filterAtoK = Program.Filter;
            var customerList = GetCustomers(customers, filterAtoK);
            foreach(Customer c in customerList)
                Console.WriteLine(c);
            Console.WriteLine();

            Console.WriteLine("Filtered L-Z List:");
            CustomerFilter filterLtoZ = delegate(Customer c)
            {
                return string.Compare(c.Name, "L", StringComparison.Ordinal) >= 0 && string.Compare(c.Name, "Z", StringComparison.Ordinal) <= 0;
            };
            customerList = GetCustomers(customers, filterLtoZ);
            foreach (Customer c in customerList)
                Console.WriteLine(c);
            Console.WriteLine();

            Console.WriteLine("Filtered by ID<100 List:");

            //This is enough: filterById = c => c.ID < 100
            //You didn't have to cast
            CustomerFilter filterById = new CustomerFilter((c)=>c.ID<100);
            customerList = GetCustomers(customers, filterById);
            foreach (Customer c in customerList)
                Console.WriteLine(c);
            Console.WriteLine();
        }

        private static Customer[] InitializeCustomerArray()
        {
            var customers = new Customer[7];

            customers[0] = new Customer("Idan", 1, "5'th avenue");
            customers[1] = new Customer("Danny", 2, "4'th avenue");
            customers[2] = new Customer("gil", 3, "3'rd avenue");
            customers[3] = new Customer("Adir", 4, "2'nd avenue");
            customers[4] = new Customer("david", 5, "1'st avenue");
            customers[5] = new Customer("Levign", 6, "6'th avenue");
            customers[6] = new Customer("Xina", 7777777, "7'th avenue");

            return customers;
        }
    }
}
