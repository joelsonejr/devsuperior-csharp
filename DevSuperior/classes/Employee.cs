using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;

namespace Course {
    class Employee {
        public int Id {get; set;}
        public string? Name {get; set;}

        public double Salary {get; set;}

        public Employee () {

        }

        public Employee (int id, string name, double salary) {
            Id = id;
            Name = name;
            Salary = salary;
        }

        public void SalaryIncrease (double percentage){

            Salary += Salary * 0.1;

        }
        public override string ToString()
        {
            return  Id
                + ", "
                + Name
                + ", "
                + Salary.ToString("F2", CultureInfo.InvariantCulture);

        }
    }
}