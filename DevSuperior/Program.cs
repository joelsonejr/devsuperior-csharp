﻿


/*
=========================================================
================= AULAS PASSADAS ========================
=========================================================

//4.08 - Modificadores de Acesso

Membro da classe:       Pode ser acessado por:
public                  própria classe, subclasse no assembly, classes do assembly, subclasses fora do assembly, clsses fora do assembly
protected internal      própria classe, subclasse no assembly, classes do assembly, subclasses fora do assembly
internal                própria classe, subclasse no assembly, classes do assembly
protected               própria classe, subclasse no assembly, subclasses fora do assembly
private protected       própria classe, subclasse no assembly
private                 própria classe


//4.07 - Ordem sugerida para implementação de membros de Classe
    - Atributos privados
    - Propriedades autoimplementadas
    - Construtores
    - Propriedades customizadas
    - Outros médotos da classe

//4.06 - Auto Properties

    using System.Globalization;

    namespace Course 
    {
        class Produto
        {
            private string _nome;
            public double Preco {get; private set;}  //auto propertie
            public int Quantidade {get; private set;} //auto propertie

            //Construtor padrão
            public Produto()
            {
                
            }

            //Construtor com 3 argumentos
            public Produto(string nome, double preco, int quantidade)
            {
                _nome = nome;
                Preco = preco;
                Quantidade = quantidade;
            }
            //Construtor com 2 argumentos
            public Produto(string nome, double preco)
            {
                _nome = nome;
                Preco = preco;
                Quantidade = 5;
            }

            public double ValorTotalEmEstoque()
            {
                return Quantidade * Preco;
            }

            //Implementação de propertie, definindo as operações de get e set
            public string Nome {
                get { return _nome;}
                set {
                    if (value != null && value.Length > 1){
                    _nome = value;
                }
                }
            }




            public void AdicionarProdutos (int quantity)
            {
                Quantidade += quantity;
            }

            public void RemoverProdutos(int quantity)
            {
                Quantidade -= quantity;
            }
            
            public override string ToString()
            {
                return _nome 
                    + ", $" 
                    + Preco.ToString("F2",CultureInfo.InvariantCulture) 
                    + ", "
                    + Quantidade
                    + " unidades, Total: $ "
                    + ValorTotalEmEstoque().ToString("F2", CultureInfo.InvariantCulture);
            }
        }
    }

    using System;
    using System.Globalization;

    namespace Course{
        class Program {
            public static void Main(string[] args){
                Produto p = new Produto("TV", 500.00, 10);

                p.Nome = "TV 4k";

                Console.WriteLine(p.Nome);
                Console.WriteLine(p.Preco.ToString("F2", CultureInfo.InvariantCulture));
            }
        }
    }

///////////////////////////////////////////////////////////////

//4.05 - Properties
    using System.Globalization;

    namespace Course 
    {
        class Produto
        {
            private string _nome;
            private double _preco;
            private int _quantidade;

            //Construtor padrão
            public Produto()
            {
                
            }

            //Construtor com 3 argumentos
            public Produto(string nome, double preco, int quantidade)
            {
                _nome = nome;
                _preco = preco;
                _quantidade = quantidade;
            }
            //Construtor com 2 argumentos
            public Produto(string nome, double preco)
            {
                _nome = nome;
                _preco = preco;
                _quantidade = 5;
            }

            public double ValorTotalEmEstoque()
            {
                return _quantidade * _preco;
            }

            //Implementação de propertie, definindo as operações de get e set
            public string Nome {
                get { return _nome;}
                set {
                    if (value != null && value.Length > 1){
                    _nome = value;
                }
                }
            }

            public double Preco {
                get { return _preco;}
            }

            public int Quantidade {
                get { return _quantidade;}
            }

            public void AdicionarProdutos (int quantity)
                                    {
                _quantidade += quantity;
            }

            public void RemoverProdutos(int quantity)
            {
                _quantidade -= quantity;
            }
            
            public override string ToString()
            {
                return _nome 
                    + ", $" 
                    + _preco.ToString("F2",CultureInfo.InvariantCulture) 
                    + ", "
                    + _quantidade
                    + " unidades, Total: $ "
                    + ValorTotalEmEstoque().ToString("F2", CultureInfo.InvariantCulture);
            }
        }
    }   

    using System;
    using System.Globalization;

    namespace Course {
        class Program {
            public static void Main (string[] args) {

                Produto p = new Produto("TV", 500.00, 10);

                p.Nome = "T";

                Console.WriteLine(p.Nome);
                Console.WriteLine(p.Preco);

            }
        }
    }

**************************************************************************



//4.04 - Encapsulamento
    using System;
    using System.Globalization;

    namespace Course {
        class Program {
            static void Main (string[] args) {
                Produto p = new Produto("TV", 500.00, 10);

                p.SetNome("T");

                Console.WriteLine(p.GetNome());
            }
        }
    }

    using System.Globalization;

    namespace Course 
    {
        class Produto
        {
            private string _nome;
            private double _preco;
            private int _quantidade;

            //Construtor padrão
            public Produto()
            {
                
            }

            //Construtor com 3 argumentos
            public Produto(string nome, double preco, int quantidade)
            {
                _nome = nome;
                _preco = preco;
                _quantidade = quantidade;
            }
            //Construtor com 2 argumentos
            public Produto(string nome, double preco)
            {
                _nome = nome;
                _preco = preco;
                _quantidade = 5;
            }

            public double ValorTotalEmEstoque()
            {
                return _quantidade * _preco;
            }

            public string GetNome() {
                return _nome;
            }

            public void SetNome(string nome) {
                if (nome != null && nome.Length > 1){
                    _nome = nome;
                }
            }

            public double GetPreco() {
                return _preco;  
            }

            public int GetQuantidade() {
                return _quantidade;
            }
            
            public void AdicionarProdutos (int quantity)
            {
                _quantidade += quantity;
            }

            public void RemoverProdutos(int quantity)
            {
                _quantidade -= quantity;
            }
            
            public override string ToString()
            {
                return _nome 
                    + ", $" 
                    + _preco.ToString("F2",CultureInfo.InvariantCulture) 
                    + ", "
                    + _quantidade
                    + " unidades, Total: $ "
                    + ValorTotalEmEstoque().ToString("F2", CultureInfo.InvariantCulture);
            }
        }
    }

**************************************************************************

//4.03 - Sobrecarga
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

            Produto p3 = new Produto {
                Nome = "TV", 
                Preco = 500.00, 
                Quantidade = 20
            };

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

*******************************************************

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