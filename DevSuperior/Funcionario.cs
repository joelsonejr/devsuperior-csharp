using System.Globalization;

namespace Course
{
    class Funcionario
    {
        public string Nome;
        public double SalarioBruto;
        public double Imposto;

        public double SalarioLiquido()
        {
            return SalarioBruto - Imposto;
        }

        public void AumentarSalario(double percentual)
        {   

            SalarioBruto += (percentual / 100) * SalarioBruto;
        }

        public override string ToString()
        {
            return Nome
                + ", "
                + "$ "
                + SalarioLiquido().ToString("F2", CultureInfo.InvariantCulture);
        }


    }
}