using System;
using System.Globalization;

namespace Desafio
{
    class Bar
    {
        public static void Main(string[] args)
        {
            Bill bill = new Bill();

            Console.Write("Sexo: ");
            char inputGender = char.ToUpper(char.Parse(Console.ReadLine()));

            bill.Gender = ValidarSexo(inputGender);

            Console.Write("Quantidade de cervejas: ");
            bill.Beer = int.Parse(Console.ReadLine());

            Console.Write("Quantidade de refrigerantes: ");
            bill.SoftDrink = int.Parse(Console.ReadLine());

            Console.Write("Quantidade de espetinhos: ");
            bill.Barbecue = int.Parse(Console.ReadLine());

            double consumo = bill.Feeding();
            double couvert = bill.Cover();
            double ingresso = bill.Ticket();
            double valorAPagar = bill.Total();

            ImprimirRelatorio(consumo, couvert, ingresso, valorAPagar);
        }

        static void ImprimirRelatorio(double consumption, double couver, double ticket, double price)
        {
            Console.WriteLine();
            Console.WriteLine("RELATÓRIO:");
            Console.WriteLine($"Consumo = R$ {consumption:F2}");

            if (couver == 0)
            {
                Console.WriteLine("Isento de Couvert");
            }
            else
            {
                Console.WriteLine($"Couvert = R$ {couver:F2}");
            }

            Console.WriteLine($"Ingresso = R$ {ticket:F2}");

            Console.WriteLine();

            Console.WriteLine($"Valor a pagar = R$ {price:F2}");
        }

        static char ValidarSexo(char sexo) 
        {
            if (sexo != 'M' && sexo != 'F')
            {   
                Boolean verificarSexo = true;

                while (verificarSexo)
                {
                    Console.Write("Valor invalido! Favor digitar F ou M: ");
                    sexo = char.ToUpper(char.Parse(Console.ReadLine()));
                    if (sexo == 'M' || sexo == 'F') 
                    {
                        verificarSexo = false;
                    }
                }
                
            }
                return sexo;
        }

    }
}