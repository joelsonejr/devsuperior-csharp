using System;
using System.Globalization;

namespace Course {
    class Exercicio401 {
        public static void Main(string[] args) {
 
            Console.Write("Entre o número da conta: ");
            int numeroConta = int.Parse(Console.ReadLine());

            Console.Write("Entre o titular da conta: ");
            string? titular = Console.ReadLine();

            Console.Write("Haverá depósito inicial (s/n): ");
            char inicializar = char.Parse(Console.ReadLine());

            ContaCorrente conta;

            if (inicializar == 's'){
                Console.Write("Entre o valor de deposito inicial: ");
                double depositoInicial = double.Parse(Console.ReadLine());

                conta = new ContaCorrente(numeroConta, titular, depositoInicial);
            } 
            else {
                 conta = new ContaCorrente(numeroConta, titular);
            }

            Console.WriteLine();
            Console.WriteLine("Dados da conta: ");
            Console.WriteLine(conta);

            Console.WriteLine();
            Console.Write("Entre um valor para depósito: ");
            double deposito = double.Parse(Console.ReadLine());

            conta.Depositar(deposito);
            Console.WriteLine("Dados da conta atualizados: ");
            Console.WriteLine(conta);


            Console.WriteLine();
            Console.Write("Entre um valor para saque: ");
            double saque = double.Parse(Console.ReadLine());

            conta.Sacar(saque);
            Console.WriteLine("Dados da conta atualizados: ");
            Console.WriteLine(conta);

            Console.WriteLine();
            Console.Write("Deseja alterar o titular (s/ n) : ");
            char alteraTitular = char.Parse(Console.ReadLine());

            if (alteraTitular == 's'){
                Console.Write("Digite o novo nome do titular: ");
                string novoNome = Console.ReadLine();

                conta.AlterarTitular(novoNome);

                Console.WriteLine();
                Console.WriteLine("Dados da conta atualizados: ");
                Console.WriteLine(conta);
            }

        }

    }
}