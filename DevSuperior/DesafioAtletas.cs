/* using System;
using System.Globalization;


namespace Course {
    class DesafioAtletas {
        static void Main(string[] args) {

            string inputNome = "";
            char inputSexo;
            double inputAltura = 0;
            double inputPeso, quantidadeAtletas;

            double pesoMedio = 0;
            double pesoMedioAtletas;
            double atletaMaisAlto = 0;
            string nomeAtletaMaisAlto = "";
            double quantidadeHomens = 0;
            double quantidadeMulheres = 0;
            double porcentagemHomens;
            double alturaMulheres = 0;
            double alturaMediaMulheres = 0;

            Console.Write("Qual a quantidade de atletas? ");
            quantidadeAtletas = double.Parse(Console.ReadLine());

            for (int i = 1; i <= quantidadeAtletas; i++)
            {
                Console.WriteLine($"Digite os dados do atleta número {i} : ");

                Console.Write("Nome: ");
                inputNome = Console.ReadLine();

                Console.Write("Sexo: ");
                inputSexo = char.ToUpper(char.Parse(Console.ReadLine()));

                if (inputSexo != 'M' && inputSexo != 'F')
                {   
                    Boolean verificarSexo = true;

                    while (verificarSexo)
                    {
                        Console.Write("Valor invalido! Favor digitar F ou M: ");
                        inputSexo = char.ToUpper(char.Parse(Console.ReadLine()));
                        if (inputSexo == 'M' || inputSexo == 'F') 
                        {
                            verificarSexo = false;
                        }
                    }
                    
                }


                Console.Write("Altura: ");
                inputAltura = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (inputAltura <= 0) 
                {   
                    inputAltura = verificarValorPositivo();
                }

                if (inputAltura > atletaMaisAlto)
                {
                    atletaMaisAlto = inputAltura;
                    nomeAtletaMaisAlto = inputNome;                    

                }

                if (inputSexo ==  'F') 
                {
                    quantidadeMulheres++;
                    alturaMulheres += inputAltura;
                }
                else 
                {
                    quantidadeHomens++;
                }

                Console.Write("Peso: ");
                inputPeso = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (inputPeso <= 0)
                {
                    inputPeso = verificarValorPositivo();
                }

                pesoMedio += inputPeso;

            }

            quantidadeAtletas = quantidadeMulheres + quantidadeHomens;
            pesoMedioAtletas = pesoMedio / quantidadeAtletas;
            porcentagemHomens = quantidadeHomens / quantidadeAtletas * 100;

            if (quantidadeMulheres > 0)
            {
                alturaMediaMulheres = alturaMulheres / quantidadeMulheres;
            }
            else 
            {
                alturaMediaMulheres = 0;
            }

            imprimirRelatorio(pesoMedioAtletas, nomeAtletaMaisAlto, porcentagemHomens, alturaMediaMulheres);

        }

        static double verificarValorPositivo()
        {
            Boolean rodarCheck = true;
            double inputValor = 0;

            while (rodarCheck)
            {
                Console.Write("Valor invalido! Favor digitar um valor positivo: ");
                inputValor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (inputValor > 0) 
                {
                    rodarCheck = false;
                }
            }

            return inputValor;
        }

        static void imprimirRelatorio(double pesoMedio, string maisAlto, double porcentagemHomens, double alturaMedia)
        {
            Console.WriteLine("");
            Console.WriteLine("RELATÓRIO:");
            Console.WriteLine($"Peso médio dos atletas: {pesoMedio:F2}");
            Console.WriteLine($"Atleta mais alto: {maisAlto}");
            Console.WriteLine($"Porcentagem de homens: {porcentagemHomens:F1} %");
            
            if (alturaMedia != 0)
            {
                Console.WriteLine($"Altura média das mulheres: {alturaMedia:F2}");
            }
            else 
            {
                Console.WriteLine("Não há mulheres cadastradas");
            }
        }

    }
}  */