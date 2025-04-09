using System;

namespace ClassGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            //PrintService printService = new PrintService();

            //Utilizando o PrintServiceParam que foi parametrizado com tipo genérico.
            PrintServiceParam<int> printService = new PrintServiceParam<int>();

            Console.Write("How many values? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int x = int.Parse(Console.ReadLine());
                printService.AddValue(x);
            }

            printService.Print();

            Console.WriteLine("First: " + printService.First());
        }
    }
}
