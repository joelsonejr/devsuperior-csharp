namespace Course
{
    class Exercicio302
    {
        public static void Main(string[] args)
        {
            Funcionario funcionario = new Funcionario();
            double percentual;

            Console.Write("Digite o nome do funcionário: ");
            funcionario.Nome = Console.ReadLine();

            Console.Write("Digite o salário bruto do funcionário: ");
            funcionario.SalarioBruto = double.Parse(Console.ReadLine());

            Console.Write("Digite o valor do imposto: ");
            funcionario.Imposto = double.Parse(Console.ReadLine());
            
            Console.WriteLine(funcionario);

            Console.Write("Digite a porcentagem para aumentar o salário: ");
            percentual = double.Parse(Console.ReadLine());

            funcionario.AumentarSalario(percentual);

            Console.Write("Dados atualizado: ");
            Console.WriteLine(funcionario);
        }
    }
}











/* using System;
using System.Globalization;

namespace Course
{
    class Exercicios301
    {
        static void Main(string[] args)
        {
            Retangulo ret = new Retangulo();
            double largura, altura, area, perimetro, diagonal;

            Console.WriteLine("Entre a largura e a altura do retângulo: ");
            ret.largura = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            ret.altura = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            area = ret.Area();
            perimetro = ret.Perimetro();
            diagonal = ret.Diagonal();

            Console.WriteLine($"AREA: {area:F2}");
            Console.WriteLine($"PERÍMETRO: {perimetro:F2}");
            Console.WriteLine($"DIAGONAL: {diagonal:F2}");

        }
    }
} */