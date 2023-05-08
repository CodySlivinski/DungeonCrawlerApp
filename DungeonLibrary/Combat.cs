using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Combat
    {
        public static void DoAttack(Character attacker, Character defender)
        {
            int chance = attacker.CalcHitChance() - defender.CalcBlock();
            Random rand = new Random();
            int roll = rand.Next(1, 101);
            if (roll <= chance)
            {
                int damage = attacker.CalcDamage();
                if (roll > 80)
                {
                    damage += 10;
                    defender.Life -= damage;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Critical Hit!!! 10 added to your damage!");
                    Console.WriteLine($"{attacker.Name} hit {defender.Name} for {damage} minutes.");
                }
                defender.Life -= damage;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{attacker.Name} hit {defender.Name} for {damage} minutes.");
                Console.ResetColor();
            }
            else
            {
                if (roll < 2)
                {
                    attacker.Life = attacker.Life - 10;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"What a waste of time {attacker.Name} docked 10 minutes from itself");
                    Console.ResetColor();

                }
                else
                {
                    Console.WriteLine($"{attacker.Name} missed!");
                }
            }
        }
        public static void DoBattle(Player player, Enemy enemy)
        {
            DoAttack(player, enemy);
            if (enemy.Life >0)
            {
                DoAttack(enemy, player);
            }
        }
    }
}
