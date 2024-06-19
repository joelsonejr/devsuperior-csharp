using System;

namespace Challenge {
    public class Warrior {
        public string Name {get; set;}
        public int Life {get; set;}
        public int Attack {get; set;}
        public int Armor {get;set; }

        public Warrior (string name, int life, int attack, int armor){
            Name = name;
            Life = life;
            Attack = attack;
            Armor = armor;
        }


        public void TakeDamage (Warrior champion) { 
            int attack = (champion.Attack - Armor);

            if (attack <= 0){
                Life -= 1;
            } else {
                Life -= attack;
            }
        }

        public string Status() {
            if (Life > 0) {
                return ($"{Name}: {Life} de vida");
            } else {
                Life = 0;
                return ($"{Name}: {Life} de vida (morreu)");
            }
        }

    }
}