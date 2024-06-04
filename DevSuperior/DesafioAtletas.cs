using System;
using System.Globalization;


namespace Course {
    class DesafioImposto {
        static void Main(string[] args) {

            string inputNome;
            char inputSexo;
            double inputAltura, inputPeso, quantidadeAtletas;

            double pesoMedio = 0;
            string maisAlto = "";
            double quantidadeHomens;
            double quantidadeMulheres;
            double alturaMediaMulheres;

            Boolean runCheck = true;

            Console.Write("Qual a quantidade de atletas? ");
            quantidadeAtletas = double.Parse(Console.ReadLine());

            for (int i = 1; i <= quantidadeAtletas; i++)
            {
                Console.WriteLine($"Digite os dados do atleta número {i} : ");

                Console.Write("Nome: ");
                inputNome = Console.ReadLine();

                Console.Write("Sexo: ");
                inputSexo = char.Parse(Console.ReadLine());

                Console.Write("Altura: ");
                inputAltura = double.Parse(Console.ReadLine());

                if (inputAltura < 0) 
                {   
                    runCheck = true;

                    while (runCheck)
                    {
                        Console.Write("Valor invalido! Favor digitar um valor positivo: ");
                        inputAltura = double.Parse(Console.ReadLine());

                        if (inputAltura > 0) 
                        {
                            runCheck = false;
                        }
                    }
                }
                


                Console.Write("Peso: ");
                inputPeso = double.Parse(Console.ReadLine());

                Console.WriteLine();


            }


        }

    }
} 