using System;

namespace Course.Entities
{
    public class Employee02
    {
        public string Name {get; set;}
        public double Salary {get; set;}

        public Employee02() {}

        public Employee02(string name, double salary) {
            Name = name;
            Salary = salary;
        }
    }
}