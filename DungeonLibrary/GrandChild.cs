using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class GrandChild : Enemy
    {
        public int Age { get; set; }

        public GrandChild(string name, int hitChance, int block, int maxLife, int minDamage, int maxDamage, string description, int age)
           : base(name, hitChance, block, maxLife, minDamage, maxDamage, description)
        {
            Age = age;
        }

        public GrandChild()
        {
            Name = "Sonny";
            HitChance = 40;
            Block = 40;
            MaxLife = 30;
            MinDamage = 5;
            MaxDamage = 25;
            Life = MaxLife;
            Description = "Your youngest grandson who is ready for a diaper change.";
            Age = 1;
        }

        public override string ToString()
        {
            return base.ToString() + $"At the age of {Age} {(Age > 18 ? "your grandchild is always draining your pockets" : "your grandchild is always looking to wear you down.")}";
        }

        public override int CalcDamage()
        {
                int min = MinDamage;
                int max = MaxDamage;
                if (Age > 18)
                {
                    min += 10;
                    max += 5;
                }
            return new Random().Next(min, max + 1);
            
        }
    }
}
