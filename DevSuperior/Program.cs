using System;
using System.Globalization;

namespace Course
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Entre od dados do produto:");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Preço: ");
            double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Quantidade no estoque: ");
            int quantidade = int.Parse(Console.ReadLine());

            Produto produto01 = new Produto(nome, preco, quantidade);

            double valorTotal = produto01.ValorTotalEmEstoque();

            Console.WriteLine();
            Console.WriteLine($"Dados do produto: {produto01}");

            Console.WriteLine();
            Console.Write("Digite o número de produtos a ser adicionado ao estoque: ");
            int modificadorDeEstoque = int.Parse(Console.ReadLine());
            produto01.AdicionarProdutos(modificadorDeEstoque);

            Console.WriteLine();
            Console.WriteLine($"Dados atualizados: {produto01}");

            Console.WriteLine();
            Console.Write("Digite o número de produtos a ser removido do estoque: ");
            modificadorDeEstoque = int.Parse(Console.ReadLine());
            produto01.RemoverProdutos(modificadorDeEstoque);

            Console.WriteLine();
            Console.WriteLine($"Dados atualizados: {produto01}");
        }
    }
}



/*
=========================================================
================= AULAS PASSADAS ========================
=========================================================

//4.01 - Construtores
using System;
using System.Globalization;

namespace Course
{
    class Program
    {
        public static void Main (string[] args)
        {

            Console.WriteLine("Entre od dados do produto:");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Preço: ");
            double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Quantidade no estoque: ");
            int quantidade = int.Parse(Console.ReadLine());

            Produto produto01 = new Produto(nome, preco, quantidade);

            double valorTotal = produto01.ValorTotalEmEstoque();

            Console.WriteLine();
            Console.WriteLine($"Dados do produto: {produto01}");

            Console.WriteLine();
            Console.Write("Digite o número de produtos a ser adicionado ao estoque: ");
            int modificadorDeEstoque = int.Parse(Console.ReadLine());
            produto01.AdicionarProdutos(modificadorDeEstoque);

            Console.WriteLine();
            Console.WriteLine($"Dados atualizados: {produto01}");

            Console.WriteLine();
            Console.Write("Digite o número de produtos a ser removido do estoque: ");
            modificadorDeEstoque = int.Parse(Console.ReadLine());
            produto01.RemoverProdutos(modificadorDeEstoque);

            Console.WriteLine();
            Console.WriteLine($"Dados atualizados: {produto01}");
        }
    }
}

-******************************************************************************

//3.10 Membros estáticos - PT 02
    using System;
using System.Globalization;

namespace Course
{
    class Program
    {
        public static void Main(string[] args)
        {

            Console.Write("Entre o valor do raio: ");
            double raio = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double circ = Calculadora.Circunferencia(raio);

            Console.WriteLine($"Circunferencia {circ:F2}");
            double volume = Calculadora.Volume(raio);
            Console.WriteLine($"Volume {volume:F2}");
            Console.WriteLine($"Pi: {Calculadora.Pi}");


        }
    }
}


//3.09 Membros estáticos - PT 01
    using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Course
{
    class Program
    {

        static double Pi = 3.14;
        static void Main (string[] args)
        {
            Console.Write("Entre o valor do raio: ");
            double raio = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double circ = Circunferencia(raio);

            Console.WriteLine($"Circunferencia {circ:F2}");
            double volume = Volume(raio);
            Console.WriteLine($"Volume {volume:F2}");
            Console.WriteLine($"Pi: {Pi}");


        }

        static double Circunferencia (double r)
        {
            return 2 * Pi * r;
        }

        static double Volume (double r)
        {
            return 4.0 / 3.0 * Pi * Math.Pow(r , 3);
        }
    }
}

-------------------------------------------------

//3.08
    namespace Course {

using System;
using System.Globalization;

    class Program {
        static void Main(string[] args) {

            Produto produto01 = new Produto();;

            Console.WriteLine("Entre od dados do produto:");
            Console.Write("Nome: ");
            produto01.Nome = Console.ReadLine();
            Console.Write("Preço: ");
            produto01.Preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Quantidade no estoque: ");
            produto01.Quantidade = int.Parse(Console.ReadLine());

            double valorTotal = produto01.ValorTotalEmEstoque();

            Console.WriteLine();
            Console.WriteLine($"Dados do produto: {produto01}");

            Console.WriteLine();
            Console.Write("Digite o número de produtos a ser adicionado ao estoque: ");
            int modificadorDeEstoque = int.Parse(Console.ReadLine());
            produto01.AdicionarProdutos(modificadorDeEstoque);

            Console.WriteLine();
            Console.WriteLine($"Dados atualizados: {produto01}");

            Console.WriteLine();
            Console.Write("Digite o número de produtos a ser removido do estoque: ");
            modificadorDeEstoque = int.Parse(Console.ReadLine());
            produto01.RemoverProdutos(modificadorDeEstoque);

            Console.WriteLine();
            Console.WriteLine($"Dados atualizados: {produto01}");



        }

    }
}  

---------------------------------------------------------

//3.07
    namespace Course {
    class Program {
        static void Main(string[] args) {

            Produto produto01 = new Produto();;

            Console.WriteLine("Entre od dados do produto:");
            Console.Write("Nome: ");
            produto01.Nome = Console.ReadLine();
            Console.Write("Preço: ");
            produto01.Preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Quantidade no estoque: ");
            produto01.Quantidade = int.Parse(Console.ReadLine());

            double valorTotal = produto01.ValorTotalEmEstoque();

            Console.WriteLine();
            Console.WriteLine($"Dados do produto: {produto01}");

            Console.WriteLine();
            Console.Write("Digite o número de produtos a ser adicionado ao estoque: ");
            int modificadorDeEstoque = int.Parse(Console.ReadLine());
            produto01.AdicionarProdutos(modificadorDeEstoque);

            Console.WriteLine();
            Console.WriteLine($"Dados atualizados: {produto01}");

            Console.WriteLine();
            Console.Write("Digite o número de produtos a ser removido do estoque: ");
            modificadorDeEstoque = int.Parse(Console.ReadLine());
            produto01.RemoverProdutos(modificadorDeEstoque);

            Console.WriteLine();
            Console.WriteLine($"Dados atualizados: {produto01}");



        }

    }
} 

----------------------------------------------------------

//3.06 Segundo Problema Exemplo
    using System;
using System.Globalization;


namespace Course {
    class Program {
        static void Main(string[] args) {

            Produto produto01 = new Produto();;

            Console.WriteLine("Entre od dados do produto:");
            Console.Write("Nome: ");
            produto01.Nome = Console.ReadLine();
            Console.Write("Preço: ");
            produto01.Preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Quantidade no estoque: ");
            produto01.Quantidade = int.Parse(Console.ReadLine());

            double valorTotal = produto01.ValorTotalEmEstoque();

            Console.WriteLine();
            Console.WriteLine($"Dados do produto: {produto01}");

            Console.WriteLine();
            Console.Write("Digite o número de produtos a ser adicionado ao estoque: ");
            int modificadorDeEstoque = int.Parse(Console.ReadLine());
            produto01.AdicionarProdutos(modificadorDeEstoque);

            Console.WriteLine();
            Console.WriteLine($"Dados atualizados: {produto01}");

            Console.WriteLine();
            Console.Write("Digite o número de produtos a ser removido do estoque: ");
            modificadorDeEstoque = int.Parse(Console.ReadLine());
            produto01.RemoverProdutos(modificadorDeEstoque);

            Console.WriteLine();
            Console.WriteLine($"Dados atualizados: {produto01}");

        }

    }
} 

==========================================================================

// 3.05 - Criando um método para obter Reaproveitamento e Delegação.
 
using System;
using System.Globalization;


namespace Course {
    class Program {
        static void Main(string[] args) {

            Triangulo x, y;

            x = new Triangulo();
            y = new Triangulo();

            Console.WriteLine("Entre com as medidas do triângulo X:");
            x.A = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            x.B = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            x.C = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Entre com as medidas do triângulo Y:");
            y.A = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            y.B = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            y.C = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double areaX = x.Area();

            double areaY = y.Area();

            Console.WriteLine($"Área de X = {areaX.ToString("F4", CultureInfo.InvariantCulture)})");
            Console.WriteLine($"Área de Y = {areaY.ToString("F4", CultureInfo.InvariantCulture)}");


        }

    }
}  
*/