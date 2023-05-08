using System.Net.Http.Headers;

namespace DungeonLibrary
{
    public class Weapon
    {
        private int _minDamage;
        private int _maxDamage;
        public int MaxDamage { get; set; }
        public string Name { get; set; }
        public int BonusHitChance { get; set; }
        public WeaponType WeaponType { get; set; }
        public int MinDamage { get; set; }
      

        public Weapon(string name, int minDamage, int maxDamage, int bonusHitChance, WeaponType weaponType)
        {
            Name = name;
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            BonusHitChance = bonusHitChance;
            WeaponType = weaponType;
            
            switch (weaponType)
            {
                case WeaponType.Cane:
                    MaxDamage += 5;
                    MinDamage += 5;
                    break;
                case WeaponType.Shoe:
                    BonusHitChance += 5;
                    break;
                case WeaponType.Rolled_Newspaper:
                    BonusHitChance += 5;
                    break;
                case WeaponType.Profanity:
                    BonusHitChance -= 5;
                    break;
                case WeaponType.Good_Book:
                    MaxDamage += 5;
                    MinDamage += 5;
                    break;
            }
        }
        public Weapon() { }

        public override string ToString()
        {
            return $"{Name} \n" +
                $"A- {WeaponType}\n" +
                $"Bonus HitChance: {BonusHitChance}\n" +
                $"Damage Range: {MinDamage} / {MaxDamage}\n";
        }

    }
}