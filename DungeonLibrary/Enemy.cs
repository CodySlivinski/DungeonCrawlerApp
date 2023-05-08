using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public abstract class Enemy : Character
    {
        private int _minDamage;
        private int _maxDamage;

        public string Description { get; set; }
        public int MaxDamage { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value < 0)
                    _minDamage = 0;
                else if (value >= _maxDamage)
                    _minDamage = 0;
                else
                    _minDamage = value;
            }
        }

        public Enemy(string name, int hitChance, int block, int maxLife, int minDamage, int maxDamage, string description)
            : base(name, hitChance, block, maxLife)
        {
            if (maxDamage < -minDamage || minDamage <= 0)
            {
                throw new ArgumentException("Min Damage must be between zero and Max Damage");
            }
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Description = description;
        }
        public Enemy() { }

        public override string ToString()
        {
            return $"-*-*-*-* {Name} *-*-*-*-\n" +
                $"Challenge Time: {Life} / {MaxLife}\n" +
                $"Hit Chance: {HitChance}\n" +
                $"Block: {Block}\n" +
                $"Damage potential: {MinDamage} / {MaxDamage}\n{Description}";
        }
        public override int CalcDamage()
        {
            return new Random().Next(MinDamage, MaxDamage + 1);
        }

    }
}
