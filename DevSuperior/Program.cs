using System;
using Course.Entities;

namespace Course
{
    class Program
    {
        public static void Main(string[] args)
        {
            Department department = CreateDepartment();

            Console.Write("Quantos funcionários tem o departamento: ");
            int employeeNumber = int.Parse(Console.ReadLine());

            CreateEmployee(employeeNumber, department);

            ShowReport(department);
        }

        public static Address CreateAddress(string email, string phone)
        {   
            Address add = new Address(email, phone);

            return add;
        }

        public static Department CreateDepartment()
            {
                Console.Write("Nome do departamento: ");
                string deptName = Console.ReadLine();
                Console.Write("Dia do pagamento: ");
                int deptPayDay = int.Parse(Console.ReadLine());
                Console.Write("Email: ");
                string deptEmail = Console.ReadLine();
                Console.Write("Telefone: ");
                string deptPhone = Console.ReadLine();

                Address deptAddress = CreateAddress(deptEmail, deptPhone);
                Department dept = new Department(deptName, deptPayDay, deptAddress);

                return dept;
            }

        public static void CreateEmployee(int amount, Department dept)
        {
            for (int i = 0; i < amount; i++)
            {
                Console.WriteLine($"Dados do funcionário {i+1}: ");
                Console.Write("Nome: ");
                string empName = Console.ReadLine();
                Console.Write("Salário: ");
                double empSalary = double.Parse(Console.ReadLine());

                Employee emp = new Employee(empName, empSalary);

                dept.AddEmployee(emp);
                
            }
        }

        public static void ShowReport(Department dept) 
        {
            Console.WriteLine(dept);
        }
    }
}