using System;
using System.Security;

namespace Course {
    class TaxPayer {
        public double SalaryIncome { get; set;}
        public double ServicesIncome {get; set;}
        public double CapitalIncome {get; set;}
        public double HelthSpending {get; set;}
        public double EducationSpending {get; set;}

        public TaxPayer() {

        }

        public static double SalaryTax() {
            return 0;
        }

        public static double ServicesTax() {
            return 0;
        }

        public static double CapitalTax() {
            return 0;
        }

        public static double GrossTax() {
            return 0;
        }

        public static double TaxRebate() {
            return 0;
        }

        public static double NetTax() {
            return 0;
        }


    }
}