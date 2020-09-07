using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    public class Customer : IComparable<Customer> , IEquatable<Customer>
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public string Adress { get; set; }

        public Customer(string name, int id, string adress)
        {
            Name = name;
            ID = id;
            Adress = adress;
        }

        public int CompareTo(Customer other) => string.Compare(Name,other.Name,StringComparison.OrdinalIgnoreCase);


        public bool Equals(Customer other)
        {
            if (Name == other.Name && ID == other.ID)
                return true;
            return false;
        }

        public override string ToString()
        {
            return $"Name: {Name} , ID: {ID} , Adress: {Adress}";
        }
    }
}
