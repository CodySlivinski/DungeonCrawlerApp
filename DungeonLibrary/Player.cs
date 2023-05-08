using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class Player : Character
    {
        public Race PlayerRace { get; set; }
        public Weapon EquippedWeapon { get; set; }

        public Player(string name, int hitChance, int block, int maxLife, Race playerRace, Weapon equippedWeapon)
            : base(name, hitChance, block, maxLife)
        {
            PlayerRace = playerRace;
            EquippedWeapon = equippedWeapon;

            switch (PlayerRace)
            {
                case Race.Knitter:
                    HitChance += 5;
                    break;
                case Race.Bingo_Star:
                    MaxLife += 5;
                    Life = MaxLife;
                    break;
                case Race.Puzzle_Champion:
                    Block += 5;
                    break;
                case Race.Bible_Thumper:
                    MaxLife += 5;
                    Life = MaxLife;
                    break;
                case Race.Shoe_Throwing_Expert:
                    HitChance += 5;
                    break;
                case Race.Chain_Smoker:
                    MaxLife -= 10;
                    Life = MaxLife;
                    Block -= 10;
                    HitChance -= 5;
                    break;         
            }
        }
        public Player() { }
        public override string ToString()
        {
            string raceDescription = "";
            switch (PlayerRace)
            {
                case Race.Knitter:
                    raceDescription = "A focused and experienced knitter with hand eye coodination far superior to your average grandma. Giving a bonus HitChance";
                    break;
                case Race.Bingo_Star:
                    raceDescription = "The star of the show. Always shouting Bingo even when the card isnt full. Your focus on being a star has led to a bonus in MaxLife";
                    break;
                case Race.Puzzle_Champion:
                    raceDescription = "No challenege can overcome a puzzle champion. With determination and maximum concentration your Block is naturally boosted";
                    break;
                case Race.Bible_Thumper:
                    raceDescription = "All things are achievable through the power of Christ in your eyes. With the lord on your side you get a bonus to your MaxLife";
                    break;
                case Race.Shoe_Throwing_Expert:
                    raceDescription = "Doesnt matter if your foe is next to you or three rooms away. Your mastery of the aerodynamics of the shoe you wear has given you a bonus HitChance";
                    break;
                case Race.Chain_Smoker:
                    raceDescription = "A chain smoker through and through. Youre going to struggle";
                    break;
            }
            return base.ToString() + $"Granny Type: {PlayerRace}\n" +
                $"{raceDescription}\n" +
                $"Weapon: {EquippedWeapon}\n" +
                $"-------------------------------------------\n"; 
        }
        public override int CalcDamage()
        {
            return new Random().Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
        }
        public override int CalcHitChance()
        {
            return base.CalcHitChance() + EquippedWeapon.BonusHitChance;
        }
    }
}
