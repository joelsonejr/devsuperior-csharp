using System;
using System.Globalization;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Course;

namespace Challenge {
    class DesafioContribuintes {
        public static void Main(string[] args) {
            Console.Write("Quantos contribuintes você vai digitar? ");
            int numberOfRegisters = int.Parse(Console.ReadLine());

            List<TaxPayer> taxPayersRegisters = new List<TaxPayer>();

            RegisterTaxPayer(numberOfRegisters, taxPayersRegisters);

            PrintTaxPayerInfo(taxPayersRegisters);
        }

        public static void RegisterTaxPayer(int registers, List<TaxPayer> payers) {
            for (int i = 0; i < registers; i++) {
                TaxPayer taxPayer = new TaxPayer();

                Console.WriteLine();
                Console.WriteLine($"Digite os dados do {i + 1}o contribuinte: ");
                Console.Write("Renda anual com salário: ");
                taxPayer.SalaryIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Renda anual com prestação de serviço: ");
                taxPayer.ServicesIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Renda anual com ganho de capital: ");
                taxPayer.CapitalIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);; 
                Console.Write("Gastos médicos: ");
                taxPayer.HealthSpending = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Gastos educacionais: ");
                taxPayer.EducationSpending = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                payers.Add(taxPayer);
            }
        }

        public static void PrintTaxPayerInfo(List<TaxPayer> taxPList) {
            int i = 0;

            foreach(TaxPayer taxPayer in taxPList) {
                i++;
                Console.WriteLine();
                Console.WriteLine($"Resumo do {i}o contribuinte:");
                Console.WriteLine($"Imposto bruto total: {taxPayer.GrossTax():F2}");
                Console.WriteLine($"Abatimento: {taxPayer.TaxRebate():F2}");
                Console.WriteLine($"Imposto devido: {taxPayer.NetTax():F2}");
            }
        }
    }
}