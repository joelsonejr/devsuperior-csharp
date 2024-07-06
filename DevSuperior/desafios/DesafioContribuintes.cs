using System;
using System.Globalization;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Course;

namespace Challenge {
    class DesafioContribuintes {
        //TODO: Criar o override do ToString na classe TaxPayer
        //TODO: Detalhar a lógica de cada um dos métodos da classe
        //TODO: Concluir a lógica da classe DesafioContribuintes
        public static void Main(string[] args) {
            Console.Write("Quantos contribuintes você vai digitar: ");
            int numberOfRegisters = int.Parse(Console.ReadLine());

            List<TaxPayer> taxPayersRegisters = new List<TaxPayer>();

            for (int i = 0; i < numberOfRegisters; i++) {
                TaxPayer taxPayer = new TaxPayer();

                Console.WriteLine($"Digite os dados do {i + 1}o contribuinte: ");
                
                Console.Write("Renda anual com salário: ");
                taxPayer.SalaryIncome = double.Parse(Console.ReadLine());
                Console.WriteLine("Renda anual com prestação de serviço: ");
                taxPayer.ServicesIncome = double.Parse(Console.ReadLine());
                Console.Write("Renda anual com ganho de capital: ");
                taxPayer.CapitalIncome = double.Parse(Console.ReadLine()); 
                Console.WriteLine("Gastos médicos: ");
                taxPayer.HelthSpending = double.Parse(Console.ReadLine());
                Console.Write("Gastos educacionais: ");
                taxPayer.EducationSpending = double.Parse(Console.ReadLine());


            }
        }

        public static void PrintTaxPayerInfo(List<TaxPayer> taxPList) {
            foreach(TaxPayer taxPayer in taxPList) {
                Console.WriteLine(taxPayer);
            }
        }
    }
}