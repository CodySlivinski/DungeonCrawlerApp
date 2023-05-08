using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class Neighbor : Enemy
    {
        public bool IsGrandma { get; set; }

        public Neighbor(string name, int hitChance, int block, int maxLife, int minDamage, int maxDamage, string description, bool isGrandma)
           : base(name, hitChance, block, maxLife, minDamage, maxDamage, description)
        {
            IsGrandma = isGrandma;
        }
        public Neighbor()
        {
            Name = "Betty";
            HitChance = 40;
            Block = 40;
            MaxLife = 30;
            MinDamage = 5;
            MaxDamage = 25;
            Life = MaxLife;
            Description = "A long time neighbor Betty who always wants to complain about lines at the store.";
            IsGrandma = false;
        }

        public override string ToString()
        {
            return base.ToString() + $"An annoying neighbor who {(IsGrandma ? "unfortunately is also a grandmother so has a bonus HitChance" : "is always getting on your nerves")}";
        }

        public override int CalcHitChance()
        {
            int calculatedHC = HitChance;
            if (IsGrandma)
            {
                calculatedHC += 10;
            }
            return calculatedHC;
        }


    }
}
