using System;
using System.Globalization;


namespace Course {
    class DesafioImposto {
        static void Main(string[] args) {

            Console.WriteLine();
        
            Console.Write("Digite sua renda anual com salário: ");
            double salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Digite sua renda anual com prestação de serviços: ");
            double ganhoPrestacaoServicos = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Digite sua renda anual com ganho de capital: ");
            double ganhoCapital = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Digite seus gastos médicos: ");
            double gastosMedicos = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Digite seus gastos educacionais: ");
            double gastosEducacionais = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double impostoSobreSalario;
            double impostoServicos = 0;
            double impostoGanhoCapital = 0;
            double impostoBrutoTotal, impostoDevido;
            double maximoDedutivel = 0;
            double gastosDedutiveis;
            double abatimento;
            double taxaSalario;

            if (salario/12 < 3000)
            {
                taxaSalario = 0;
            }
            else if (salario/12 < 5000)
            {
                taxaSalario =  0.1;
            }
            else 
            {
                taxaSalario = 0.2;
            }

            impostoSobreSalario = calculaImposto(salario, taxaSalario);


            if (ganhoPrestacaoServicos > 0 )
            {
                impostoServicos = calculaImposto(ganhoPrestacaoServicos, 0.15);
            }


            if (ganhoCapital > 0)
            {
                impostoGanhoCapital = calculaImposto(ganhoCapital, 0.2);
            }


            impostoBrutoTotal = impostoSobreSalario + impostoServicos + impostoGanhoCapital;

            gastosDedutiveis = gastosEducacionais + gastosMedicos;

            maximoDedutivel = calculaImposto(impostoBrutoTotal, 0.3);


            if (gastosDedutiveis >= maximoDedutivel) 
            {
                abatimento = maximoDedutivel;
            }
            else 
            {
                abatimento = gastosDedutiveis;
            }


            impostoDevido = impostoBrutoTotal - abatimento;

            imprimirRelatorio(impostoSobreSalario, impostoServicos, impostoGanhoCapital, maximoDedutivel, gastosDedutiveis, impostoBrutoTotal, abatimento, impostoDevido);

        }

        static double calculaImposto(double valor, double taxa) 
            {
                return valor * taxa;
            }

        static void imprimirRelatorio(double impSalario, double impServicos, 
            double impCapital, double maxDedutivel, double gastosDedutiveis, 
            double impTotal, double abatimento, double impDevido)   
        {
            Console.WriteLine();
            Console.WriteLine("RELATÓRIO DE IMPOSTO DE RENDA");
            Console.WriteLine();
            Console.WriteLine("CONSOLIDADO DE RENDA:");
            Console.WriteLine($"Imposto sobre salário: {impSalario:F2}");
            Console.WriteLine($"Imposto sobre serviços: {impServicos:F2}");
            Console.WriteLine($"Imposto sobre ganho de capital: {impCapital:F2}");
            Console.WriteLine();
            Console.WriteLine("DEDUÇÕES:");
            Console.WriteLine($"Máximo dedutível: {maxDedutivel:F2}");
            Console.WriteLine($"Gastos dedutíveis: {gastosDedutiveis:F2}");
            Console.WriteLine();
            Console.WriteLine("RESUMO:");
            Console.WriteLine($"Imposto bruto total: {impTotal:F2}");
            Console.WriteLine($"Abatimento: {abatimento:F2}");
            Console.WriteLine($"Imposto devido: {impDevido:F2}");
        }

    }
} 