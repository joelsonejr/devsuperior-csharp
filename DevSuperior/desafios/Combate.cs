using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Challenge {
    public class Combate {
        public static void Main (string[] args){

            Console.WriteLine();
            Console.WriteLine("Digite os dados do primeiro campeão:");
            Warrior campeaoA = RegisterChampion();

            Console.WriteLine();    
            Console.WriteLine("Digite os dados do segundo campeão:");
            Warrior campeaoB = RegisterChampion();

            Console.WriteLine();
            Console.Write("Quantos turnos você deseja executar: ");
            int turnos = int.Parse(Console.ReadLine());

            int round = 1;

            while (turnos >0) {

                campeaoA.TakeDamage(campeaoB);
                campeaoB.TakeDamage(campeaoA);
            

                Console.WriteLine();
                Console.WriteLine($"Resultado do turno {round}:");
                Console.WriteLine(campeaoA.Status());
                Console.WriteLine(campeaoB.Status());

                if (campeaoA.Life <= 0 || campeaoB.Life <= 0) {
                    Console.WriteLine();
                    Console.WriteLine("FIM DO COMBATE");
                    return;
                }

                turnos--;
                round++;
            }
            
            Console.WriteLine();
            Console.WriteLine("FIM DO COMBATE");
            
        }

        public static Warrior RegisterChampion () {
            
            Console.Write("Nome: ");
            string name = Console.ReadLine();
            Console.Write("Vida inicial: ");
            int life = int.Parse(Console.ReadLine());
            Console.Write("Ataque: ");
            int attack = int.Parse(Console.ReadLine());
            Console.Write("Armadura: ");
            int armor = int.Parse(Console.ReadLine());

            Warrior champion = new Warrior(name, life, attack, armor);

            return champion;
        }
    }

}