using System;
using System.ComponentModel.DataAnnotations;
using GetHashCodeAndEquals.Entities;

namespace GetHashCodeAndEquals
{
    class Program
    {
        static void Main(string[] args)
        {
            Client a = new Client { Name = "Maria", Email = "maria@mail.com" };
            Client b = new Client { Name = "Joan", Email = "joan@mail.com" };
            Client c = new Client { Name = "Lucy", Email = "joan@mail.com" };

            Console.WriteLine(a.Equals(b));
            Console.WriteLine(b.Equals(c));
            Console.WriteLine(b == c);
            Console.WriteLine(a.GetHashCode());
            Console.WriteLine(b.GetHashCode());
            Console.WriteLine(c.GetHashCode());


        }
    }
}