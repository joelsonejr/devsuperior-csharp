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

           RunGame(turnos, round, campeaoA, campeaoB);
            
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

        public static void RunGame(int turnos, int round, Warrior champA, Warrior champB) {
             while (turnos >0) {

                champA.TakeDamage(champB);
                champB.TakeDamage(champA);
            

                Console.WriteLine();
                Console.WriteLine($"Resultado do turno {round}:");
                Console.WriteLine(champA.Status());
                Console.WriteLine(champB.Status());

                if (champA.Life <= 0 || champB.Life <= 0) {
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
    }

}