using System;

namespace CustomersApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var customers = InitializeCustomerArray();

            foreach (Customer customer in customers)
                Console.WriteLine(customer);

            Console.WriteLine("\nFirst sort:\n");
            Array.Sort(customers);
            foreach (var customer in customers)
                Console.WriteLine(customer);

            Console.WriteLine("\nSecond sort:\n");
            AnotherCustomerComparer comparer = new AnotherCustomerComparer();
            Array.Sort(customers,comparer);
            foreach (var customer in customers)
                Console.WriteLine(customer);

        }

        private static Customer[] InitializeCustomerArray()
        {
            var customers = new Customer[5];

            customers[0] = new Customer("idan", 21548462, "5'th avenue");
            customers[1] = new Customer("danny", 51265485, "4'th avenue");
            customers[2] = new Customer("gil", 4985123, "3'rd avenue");
            customers[3] = new Customer("adir", 5489484, "2'nd avenue");
            customers[4] = new Customer("david", 1235487, "1'st avenue");

            return customers;
        }
    }
}
