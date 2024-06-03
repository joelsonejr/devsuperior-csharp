using System;
using System.Globalization;


namespace Course {
    class DesafioImposto {
        static void Main(string[] args) {
        
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

            if (salario/12 < 3000)
            {
                impostoSobreSalario = 0;
            }
            else if (salario/12 < 5000)
            {
                impostoSobreSalario = salario * 0.1;
            }
            else 
            {
                impostoSobreSalario = salario * 0.2;
            }


            if (ganhoPrestacaoServicos > 0 )
            {
                impostoServicos = ganhoPrestacaoServicos * 0.15;
            }


            if (ganhoCapital > 0)
            {
                impostoGanhoCapital = ganhoCapital * 0.2;
            }


            impostoBrutoTotal = impostoSobreSalario + impostoServicos + impostoGanhoCapital;


            gastosDedutiveis = gastosEducacionais + gastosMedicos;

            if (gastosDedutiveis > 0) 
            {

                if (gastosDedutiveis > impostoBrutoTotal * 0.3) 
                {
                    maximoDedutivel = impostoBrutoTotal * 0.3;
                }
                else
                {
                    maximoDedutivel = gastosDedutiveis;
                }
            }

            abatimento = maximoDedutivel;
            impostoDevido = impostoBrutoTotal - abatimento;


            
            Console.WriteLine();
            Console.WriteLine("RELATÓRIO DE IMPOSTO DE RENDA");
            Console.WriteLine();
            Console.WriteLine("CONSOLIDADO DE RENDA:");
            Console.WriteLine($"Imposto sobre salário: {impostoSobreSalario:F2}");
            Console.WriteLine($"Imposto sobre serviços: {impostoServicos:F2}");
            Console.WriteLine($"Imposto sobre ganho de capital: {impostoGanhoCapital:F2}");
            Console.WriteLine();
            Console.WriteLine("DEDUÇÕES:");
            Console.WriteLine($"Máximo dedutível: {maximoDedutivel:F2}");
            Console.WriteLine($"Gastos dedutíveis: {gastosDedutiveis:F2}");
            Console.WriteLine();
            Console.WriteLine("RESUMO:");
            Console.WriteLine($"Imposto bruto total: {impostoBrutoTotal:F2}");
            Console.WriteLine($"Abatimento: {abatimento:F2}");
            Console.WriteLine($"Imposto devido: {impostoDevido:F2}");


        }

    }
} 