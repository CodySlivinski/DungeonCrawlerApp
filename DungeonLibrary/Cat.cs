using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class Cat : Enemy
    {
        public bool IsHungry { get; set; }

        public Cat(string name, int hitChance, int block, int maxLife, int minDamage, int maxDamage, string description, bool isHungry)
           : base(name, hitChance, block, maxLife, minDamage, maxDamage, description)
        {
            IsHungry = isHungry;
        }

        public Cat()
        {
            Name = "Kitty";
            HitChance = 40;
            Block = 40;
            MaxLife = 30;
            MinDamage = 5;
            MaxDamage = 25;
            Life = MaxLife;
            Description = "A baby kitten looking for some attention";
            IsHungry = false;
        }

        public override string ToString()
        {
            return base.ToString() + $"A cat out {(IsHungry ? "looking for food and ready to eat whatever is insight" : "looking to steal your time")}";
        }
        public override int CalcDamage()
        {
            int min = MinDamage;
            int max = MaxDamage;
            if (IsHungry)
            {
                min += 10;
                max += 5;
            }
            return new Random().Next(min, max + 1);
        }
    }
} 
