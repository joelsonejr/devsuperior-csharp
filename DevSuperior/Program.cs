//5.13 - Listas - Parte 2
using System;
using System.Globalization;
using System.Collections.Generic;

namespace Course {
    class Program {
        public static void Main(string[] args) {

            List<string> list = new List<string>();

            //Adicionando itens é no final da lista.
            list.Add("Sabrina");
            list.Add("Kênia");
            list.Add("Ana Beatriz");
            list.Add("Viviane");
            list.Add("Amanda");

            foreach (string obj in list) {
                Console.WriteLine(obj);
            }

            //Inseringo ítens em uma determinada posição da lista
            list.Insert(2, "Cassia");
            
            Console.WriteLine();
            foreach (string obj in list) {
             Console.WriteLine(obj);
            }

            Console.WriteLine();
            //Contanto quantidade de ítens da lista
            Console.WriteLine(list.Count());

            Console.WriteLine();
            //Encontrar na lista a primeirta ocorrência de um elemento que
            //satisfaça um predicado. No exemplo abaixo, será a 
            //primeira ocorrência de um nome começando pela letra A.
            string s1 = list.Find(x => x[0] == 'A');
            Console.WriteLine($"Primeiro nome iniciado pela letra A: {s1}");

            //Encontrar na lista a última ocorrência de um elemento que
            //satisfaça um predicado.
            string s2 = list.FindLast(x => x[0] == 'A');
            Console.WriteLine($"Primeiro nome terminado pela letra A: {s2}");

            //Encontrar a primeira posição de um elemento que satisfaça um 
            //predicado.
            int pos1 = list.FindIndex(x => x[0] == 'K');
            Console.WriteLine(pos1);

            //Encontrar a primeira posição de um elemento que satisfaça um 
            //predicado.
            int pos2 = list.FindLastIndex(x => x[0] == 'A');
            Console.WriteLine(pos2);

            //Filtrar a lista com base em um predicado
            List<string> list2 = list.FindAll(x => x.Length >= 6 );
            foreach (string name in list2) {
                Console.WriteLine(name);
            }

            //Remover elementos da lista
            Console.WriteLine();
            list.Remove("Viviane");
            foreach (string name in list) {
            Console.WriteLine(name);
            }

            //Remover todas as ocorrências com base em um predicado
            list.RemoveAll(x => x[0] == 'A');
            Console.WriteLine();
            foreach (string name in list) {
            Console.WriteLine(name);
            }
            //Caso o método não encontre o objeto informado, ele simplesmente
            //ignora.

            //Remover um elemento de acordo com a posição dele.
            list.RemoveAt(2);
            Console.WriteLine();
            foreach (string name in list) {
            Console.WriteLine(name);
            }

            //Removendo os elementos de uma faixa
            //(n, nn) posição inicial, quantos elementos serão removidos a partir
            //dali.
            list.RemoveRange(0, 2);
            Console.WriteLine();
            Console.WriteLine("Removendo");
            foreach (string name in list) {
            Console.WriteLine(name);
            }






        }
    }
}

/*
=========================================================
================= AULAS PASSADAS ========================
=========================================================

//5.12 Listas - Parte 1

using System;
using System.Globalization;
using System.Collections.Generic; // necessário para acessar a classe lista.

namespace Course {
    class Program {
        public static void Main(string[] args) {

            List<string> list = new List<string>(); //instaciando uma lista vazia.

            List<string> list2 = new List<string> {"Márcis", "Joana"};
        }
    }
}

///////////////////////////////////////////////////////////

//5.11 - Laço Foreach
using System;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main(string[] args) {

            string[] vect = new string[] { "Ana", "Barbara", "Silvia"};

            foreach (string s in vect) {
                Console.WriteLine(s);
            }

        }
    }
}

//////////////////////////////////////////////////////////////

//5.10 - Boxing e Unboxing

//////////////////////////////////////////////////////////

//5.09 Modificadores de parâmetros Out e Ref
using System;
using System.ComponentModel.Design.Serialization;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main(string[] args) {

            int a = 10;
            Calculator.Triple(ref a); //ref faz com que o parametro da função possa
            //alterar o valor (seja referência) da variável original. 

            Console.WriteLine(a);

            int triple;
            Calculator.Triple2(a, out triple);
            // Funcionamento similar ao ref, mas não exige que a variável de saída
            // tenha sido inicializada.
            Console.WriteLine(triple);
        }
    }
}

/////////////////////////////////////////////////////////

//5.08 - Modificador de parâmetros Params

using System;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main (string[] args) {
            //O Params do método Sum garante que a quantidade de parâmetros 
            // seja variável.
            int s1 = Calculator.Sum(2, 3, 4);
            int s2 = Calculator.Sum(2, 3, 4, 5, 6, 7);

            Console.WriteLine(s1);
            Console.WriteLine(s2);
        }
    }
}

////////////////////////////////////////////////////

//5.06 - Vetores, parte 2

using System;
using System.Globalization;
using System.Reflection.Metadata;

namespace Course {
    class Program {
        public static void Main (string[] args){
            Console.Write("Digite a quantidade de produtos: ");
            int quantidadeProdutos = int.Parse(Console.ReadLine());

            Product[] listaProdutos = new Product[quantidadeProdutos];

            // Versão 01 do Loop
            // for (int i = 0; i < quantidadeProdutos; i++) {
            //     Product p = new Product();

            //     Console.Write($"Digite o nome produto {i + 1}: ");
            //     p.Nome = Console.ReadLine();
            //     Console.Write($"Digite o preço do produto {i + 1}: ");
            //     p.Preco = double.Parse(Console.ReadLine());

            //     listaProdutos[i] = p;
            // }

            // Versão 02 do Loop
            for (int i = 0; i < quantidadeProdutos; i++) {
                Console.WriteLine();
                Console.WriteLine($"Digite os dados do produto {i + 1}");
                Console.Write("Nome: ");
                string nome = Console.ReadLine();
                Console.Write("Preço: ");
                double preco = double.Parse(Console.ReadLine());
            

                Product p = new Product(nome, preco);

                listaProdutos[i] = p;
            }

            double somaPrecos = 0;

            for (int i = 0; i < listaProdutos.Length; i ++){
                somaPrecos += listaProdutos[i].Preco;
            }

            double media = somaPrecos / listaProdutos.Length;
            
            Console.WriteLine($"Average Price = {media:F2}");


        }
    }
}

////////////////////////////////////////////////////////

//5.05 - Vetores, parte 1
using System;
using System.Globalization;

namespace Course {
    class Program {

        public static void Main(string[] args) {

            Console.Write("Digite o valor de N: ");
            int n = int.Parse(Console.ReadLine());

            double[] alturas = new double[n];

            for (int i = 0; i < n; i++) {
                Console.Write($"Digite a altura da pessoa {i}: ");
                alturas[i] = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            }

            double alturaMedia = 0;

            for (int i = 0; i < alturas.Length; i++) {
                alturaMedia += alturas[i];
            }

            double media = alturaMedia / alturas.Length;
            Console.WriteLine($"Altura média igual = {media:F2}");

            
        }
    }
}

///////////////////////////////////////////////////////

// 5.04 - Nullable
using System;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main(string[] args) {

            // double x = null;  - Dá erro
            // Nullable<double> x = null; 
            double? x = null;

            double? y = 10.0;

            Console.WriteLine(x.GetValueOrDefault()); // Pega o valor da variável, ou o valor padrão do Tipo da variável.
            Console.WriteLine(y.GetValueOrDefault());

            Console.WriteLine(x.HasValue); // Informa se dentro da varíavel existe/ não existe um valor. 
            Console.WriteLine(y.HasValue);

            // Console.WriteLine(x.Value); // Pega o valor diretamente de "dentro do x". Caso seja feito em cima de um objeto que está valendo nulo, dispara uma excessão. 
            // Console.WriteLine(y.Value);

            if (x.HasValue) { Console.WriteLine(x.Value);}
             else Console.WriteLine("x é nulo");

            //Nullish coalescing operator
            double z = x ?? 5;
            double a = y ?? 5;

            Console.WriteLine(a);
            Console.WriteLine(z);


        }
    }
}

///////////////////////////////////////////////////////////

// 5.03 - Desalocação de Memória - Garbage Collector e Escopo Local.

// 5.02 - Tipos Referência vs Tipos valor

using System;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main (string[] args) {

            Point p;

            p.X = 10;
            p.Y = 20;

            Console.WriteLine(p);

            p = new Point();
            Console.WriteLine(p); 

        }
    }
}

/////////////////////////////////////////////////////////////////////////////

//4.08 - Modificadores de Acesso

assembly == projeto.
subclasse é um conceito de herança.
* Dentro de uma solução, podem haver vários projetos.

Própria classe
    public
    protected internal
    internal
    protected
    private protected
    private
Subclasse no Assembly
    public
    protected internal
    internal
    protected
    private protected
Classes do Assembly
    public
    protected internal
    internal
Subclasses fora do Assembly
    public
    protected internal
    protected
Classes fora do Assembly
    public
    private


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