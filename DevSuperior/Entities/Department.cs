using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;


namespace Course.Entities
{
    class Department {
        public string Name {get; set;}
        public int PayDay {get; set;}
        public Address Address {get; set;}
        public List<Employee02> Employee {get; set;} = new List<Employee02>();

        public Department() {}

        public Department(string name, int payDay, Address address)
        {
            Name = name;
            PayDay = payDay ;
            Address = address;
        }

        public void AddEmployee (Employee02 employee)
        {
            Employee.Add(employee);
        }

        public void RemoveEmployee (Employee02 employee) 
        {
            Employee.Remove(employee);
        }

        public double PayRoll() 
        {   
            double pay = 0;

            foreach (Employee02 emp in Employee)
            {
                pay += emp.Salary;
            }

            return pay;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine("FOLHA DE PAGAMENTO");
            sb.AppendLine($"Departamento de {Name} = R$ {PayRoll().ToString("F2", CultureInfo.InvariantCulture)}");
            sb.AppendLine($"Pagamento realizado no dia: {PayDay}");
            sb.AppendLine("Funcionários: ");

            foreach (Employee02 emp in Employee) 
            {
                sb.AppendLine(emp.Name);
            }

            sb.AppendLine($"Para dúvidas favor entrar em contato com: {Address.Email}");

            return sb.ToString();
        }
    }
}