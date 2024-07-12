using System;
using System.Security;

namespace Course {
    class TaxPayer {
        public double SalaryIncome { get; set;}
        public double ServicesIncome {get; set;}
        public double CapitalIncome {get; set;}
        public double HealthSpending {get; set;}
        public double EducationSpending {get; set;}

        public TaxPayer() {

        }

        public double SalaryTax() { //imposto sobre o salário
            double salaryTax = 0.0;

            if (SalaryIncome/12 < 3000)
            {
                salaryTax = 0;
            }
            else if (SalaryIncome/12 < 5000)
            {
                salaryTax =  0.1;
            }
            else 
            {
                salaryTax = 0.2;
            }



            return salaryTax * SalaryIncome;
        }

        public double ServicesTax() { //imposto sobre serviços
            double servicesTax = 0.0;

            if (ServicesIncome > 0) {
                servicesTax = 0.15 * ServicesIncome;
            }

            return servicesTax;
        }

        public double CapitalTax() { //imposto sobre ganho de capital
            double capitalTax = 0.0;

            if(CapitalIncome > 0) {
                capitalTax = 0.2 * CapitalIncome;
            }

            return capitalTax;
        }

        public double GrossTax() { //imposto bruto
            double grossTax = SalaryTax() + ServicesTax() + CapitalTax();

            return grossTax;
        }
        public double TaxRebate() { //abatimento no imposto
            double maxRebate = GrossTax() * 0.3;
            double deductible = HealthSpending + EducationSpending;
            double rebate;

            if(deductible > maxRebate) {
                rebate = maxRebate;
            }
            else {
                rebate = deductible;
            }

            return rebate;
        }

        public double NetTax() { //imposto líquido
            return GrossTax() - TaxRebate();
        }


    }
}