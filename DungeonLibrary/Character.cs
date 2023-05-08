using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public abstract class Character
    {
        private int _life;
        private int _maxLife;

        public string Name {  get; set; }
        public int HitChance { get; set; }
        public int Block { get; set; }
        public int MaxLife { get; set; }
        public int Life
        {
            get { return _life; }
            set
            {
                if (value <= MaxLife)
                {
                    _life = value;
                }
                else
                {
                    _life = MaxLife;
                }
            }
        }

        public Character (string name, int hitChance, int block, int maxlife)
        {
            Name = name;
            HitChance = hitChance;
            Block = block;
            MaxLife = maxlife;
            Life = maxlife;
        }
        public Character() { }

        
        public override string ToString()
        {
            return $"-*-*-*-* {Name} *-*-*-*-\n" +
                $"Minutes Till Nap: {Life} / {MaxLife}\n" +
                $"Hit Chance: {HitChance}\n" +
                $"Block: {Block}\n";
        }
        public virtual int CalcBlock()
        {
            return Block;
        }
        public virtual int CalcHitChance()
        {
            return HitChance;
        }
        public abstract int CalcDamage();
    }
}
