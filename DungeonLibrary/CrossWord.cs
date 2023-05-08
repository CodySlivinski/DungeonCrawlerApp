using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class CrossWord : Enemy
    {
        public bool IsSundayPaper { get; set; }

        public CrossWord(string name, int hitChance, int block, int maxLife, int minDamage, int maxDamage, string description, bool isSundayPaper)
           : base(name, hitChance, block, maxLife, minDamage, maxDamage, description)
        {
            IsSundayPaper = isSundayPaper;
        }

        public CrossWord()
        {
            Name = "Weekly Paper Crossword";
            HitChance = 40;
            Block = 40;
            MaxLife = 30;
            MinDamage = 5;
            MaxDamage = 25;
            Life = MaxLife;
            Description = "A very doable crossword from the daily paper";
            IsSundayPaper = false;
        }

        public override string ToString()
        {
            return base.ToString() + $"A crossword from {(IsSundayPaper ? "the sunday paper making it longer and more challenging" : "a puzzle book you've done before")}";
        }

        public override int CalcBlock()
        {
            int calcBlock = Block;
            if (IsSundayPaper)
            {
                calcBlock += 10;
            }
            return calcBlock;
        }
    }
}
