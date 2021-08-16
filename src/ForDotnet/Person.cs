using System.Collections.Generic;

namespace ForDotnet
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double HeightInInches { get; set; }
        public Dictionary<string, Address> Addresses { get; set; }
        public List<Address2> Addr { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
    public class Address2
    {
        public string Key { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public override string ToString()
        {
            return $"Key:{Key}, Street:{Street}, City:{City}, State:{State}, Zip:{Zip}";
        }
    }
}