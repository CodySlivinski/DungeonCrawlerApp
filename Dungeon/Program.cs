using DungeonLibrary;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

namespace Dungeon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int score = 0;
            #region Introduction
            Console.Title = "Cranky Grandma";
            Console.WriteLine("It's a hard life being a cranky Grandma. You wake up early in the morning, long before any task could ever need to be done. Then the day begins. You must battle through annoying neighbors, rambunctious grand children, cats stuck in trees, crossword puzzles and many more befor you ever get to finally lay down for a nap. To you I say good luck. I hope you get your chores done before nap time arives. Buid yourself a cranky grandma and fight your way through your chores and acomplish as much as possible before you lay down for a nap. The more you get done the higher the score.\n\n");
            #endregion

            #region Player and Weapon select
            Console.WriteLine("Please Select Your Difficulty:\n" +
                "1 - Easy\n" +
                "2 - Normal\n" +
                "3 - Hard\n");
            string dif = Console.ReadLine();
            Console.Clear();
            decimal difMult;
            switch (dif)
            {
                case "1":
                    Console.WriteLine("You chose easy\n");
                    difMult = 1.25m;
                    break;
                case "2":
                    Console.WriteLine("You chose Normal\n");
                    difMult = 1;
                    break;
                case "3":
                    Console.WriteLine("You chose Hard\n");
                    difMult = .75m;
                    break;
                default:
                    Console.WriteLine("Invalid Selection, Super Duper Hard Difficulty Chosen\n");
                    difMult = .2m;
                    break;
            }
            Weapon wep = new Weapon();
            Player player = new Player("",0,0,0,Race.Knitter, wep);
            Console.WriteLine("Now we must create your Cranky Grandma. Pick a type of grandma from the list Below. Be aware that each type has a bonus.\n");
            Console.WriteLine($"1 - Knitter - A focused and experienced knitter with hand eye coodination far superior to your average grandma. Giving a bonus HitChance.\n" +
                $"2 - Bingo Star - The star of the show. Always shouting Bingo even when the card isnt full. Your focus on being a star has led to a bonus in MaxLife.\n" +
                $"3 - Puzzle Champion - No challenege can overcome a puzzle champion. With determination and maximum concentration your Block is naturally boosted.\n" +
                $"4 - Bible Thumper - All things are achievable through the power of Christ in your eyes. With the lord on your side you get a bonus to your MaxLife.\n" +
                $"5 - Shoe Throwing Expert - Doesnt matter if your foe is next to you or three rooms away. Your mastery of the aerodynamics of the shoe you wear has given you a bonus HitChance.\n");
            string userChoice = Console.ReadLine();
            Console.Clear();
            switch(userChoice)
            {
                case "1":
                    Console.WriteLine("You chose Knitter");
                    player.PlayerRace = Race.Knitter;
                    break;
                case "2":
                    Console.WriteLine("Your chose Bingo Star");
                    player.PlayerRace = Race.Bingo_Star;
                    break;
                case "3":
                    Console.WriteLine("You chose Puzzle Champion");
                    player.PlayerRace = Race.Puzzle_Champion;
                    break;
                case "4":
                    Console.WriteLine("You Chose Bible Thumer");
                    player.PlayerRace = Race.Bible_Thumper;
                    break;
                case "5":
                    Console.WriteLine("You Chose Shoe Throwing Expert");
                    player.PlayerRace = Race.Shoe_Throwing_Expert;
                    break;
                default:
                    Console.WriteLine("Well you picked wrong so your a Chain Smoker. Which will severly hinder all stats. Good Luck!!!");
                    player.PlayerRace = Race.Chain_Smoker;
                    break;
            }
            Console.WriteLine("\nNow that you know the type of granny you are, we should adress your name. What is your name dear old lady?");
            player.Name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Ahhh -{player.Name}- what a.... um... great choice.\n" +
                $"Now its time to build some stats. Your stats will be adjusted by the difficulty you selected in the beggining.\nPress Enter to Roll for your HitChance.");
            Console.ReadKey();
            Console.Clear();
            player.HitChance = (int)(new Random().Next(50, 80) * difMult);
            Console.WriteLine($"Nice you now have a HitChance of {player.HitChance}\n" +
                $"Press enter to Roll for your Block Stat.");
            Console.ReadKey();
            player.Block = (int)(new Random().Next(40, 70) * difMult);
            Console.WriteLine($"Way to go you have a Block of {player.Block}\n" +
                $"One more to go. Press enter to Roll for your MaxLife stat.");
            Console.ReadKey();
            player.MaxLife = (int)(new Random().Next(70,80) * difMult);
            player.Life = player.MaxLife;
            Console.WriteLine($"There you got it! A Max Life of {player.MaxLife}\n" +
                $"Now comes for the fun part. We must build a weapon!!!\n");
           
            Console.WriteLine("What would you like to use as your weapon granny?\n" +
                "1 - The Good Book\n" +
                "2 - A Rolled Newspaper\n" +
                "3 - Your Shoe\n" +
                "4 - Your Cane\n");
            userChoice = Console.ReadLine();
            Console.Clear();
            switch (userChoice)
            {
                case "1":
                    Console.WriteLine("You chose The Good Book");
                    wep.WeaponType = WeaponType.Good_Book;
                    break;
                case "2":
                    Console.WriteLine("You chose A Rolled Newspaper");
                    wep.WeaponType = WeaponType.Rolled_Newspaper;
                    break;
                case "3":
                    Console.WriteLine("You chose Your Shoe");
                    wep.WeaponType = WeaponType.Shoe;
                    break;
                case "4":
                    Console.WriteLine("You Chose Your Cane");
                    wep.WeaponType = WeaponType.Cane;
                    break;
                default:
                    Console.WriteLine("Invalid selection you must resort to Profanity as a weapon");
                    wep.WeaponType= WeaponType.Profanity;
                    break;
            }
            Console.WriteLine("Now we must decide upon a good name for your weapon of choice. Please enter the name below.");
            wep.Name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"{wep.Name} a fitting name for such a device.\n");
            Console.WriteLine("Once again we must roll some randomish numbers to apply some stats.\n" +
                "Press enter to Roll for your MaxDamage");
            Console.ReadKey();
            wep.MaxDamage = (int)(new Random().Next(20, 40) * difMult);
            Console.WriteLine($"Could of been better but your MaxDamage is {wep.MaxDamage}\n" +
                $"Now press enter to roll for your MinDamage");
            Console.ReadKey();
            wep.MinDamage = (int)(new Random().Next(1, 15)* difMult);
            Console.WriteLine($"Not so bad! You landed a MinDamage of {wep.MinDamage}\n" +
                $"Press enter to Roll for your Bonus HitChance.");
            Console.ReadKey();
            wep.BonusHitChance =new Random().Next(1,10 );
            Console.WriteLine($"You have a Bonus HitChance of {wep.BonusHitChance}\n" +
                $"Right then, let's have a look at your granny.\n" +
                $"---------------------------------------\n" +
                $"{player}\n" +
                $"---------------------------------------\n" +
                $"Lets dive in and get some stuff acomplished before nap time.\n" +
                $"Press Enter to begin your challenges before you must take a nap");
            Console.ReadKey();
            Console.Clear();

            #endregion

            #region Main game loop
            bool lose = false;
            do
            {
                Console.WriteLine(GetRoom());
                Enemy enemy = GetEnemy();
                Console.WriteLine($"\nBeware for now you must defeat\n\n{enemy}");

                bool reload = false;
                do
                {
                    Console.WriteLine($"\nPlease Choose an action:\n" +
                        $"A - Attack\n" +
                        $"R - Turn and Run (slowly)\n" +
                        $"P - Player Info\n" +
                        $"E - Enemy Info\n" +
                        $"X - Exit\n");

                    ConsoleKey choice = Console.ReadKey(true).Key;
                    Console.Clear();

                    switch (choice)
                    {
                        case ConsoleKey.A:
                            Combat.DoBattle(player, enemy);
                            if (enemy.Life <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"\nYou defeated {enemy.Name}!\n");
                                Console.ResetColor();
                                reload = true;
                                score++;
                            }
                            else if (player.Life <= 0)
                            {
                                lose = true;
                            }
                            break;
                        case ConsoleKey.R:
                            Console.WriteLine("You turn and wobble away");
                            Combat.DoAttack(enemy, player);
                            reload = true;
                            break;
                        case ConsoleKey.P:
                            Console.WriteLine(player);
                            Console.WriteLine($"You have defeated {score} challenges");
                            break;
                        case ConsoleKey.E:
                            Console.WriteLine($"Enemy Info:\n{enemy}");
                            break;
                        case ConsoleKey.X:
                            Console.WriteLine("Getting too old for this I see");
                            lose = true;
                            break;
                        default:
                            Console.WriteLine("Put your glasses on Granny you didn't pick a valid option.");
                            break;
                    }
                    if (player.Life <= 0)
                    {
                        Console.WriteLine("Alright there Oldy Locks it's naptime");
                    }
                } while (!reload && !lose);


            } while (!lose);
            Console.WriteLine($"You have defeated {score} challenges and finally now have to lay down for a nap.");

            #endregion
        }
        
        private static string GetRoom()
        {
            string[] rooms =
            {
                "You enter a spare bedroom with a musty odor and you feel as if it may be the first time you've been in this room in ages. The corner is filled with boxes and all the furniture is wrapped to keep it from aging. You peak into the closet only to find your next challenge before naptime..",
                "You enter your den where the smoke from years of smoking has stained the walls yellow. The ceiling has a plastered texture to it and the couch looks as if has never been set on. Empty rocks glasses sit on every end table you look towards the front door where you notice your next challenge before naptime.",
                "Into your favorite room of the house, the dinning room attachted to the kitche. Memories of years of holiday dinners run through your mind only to be swept away by your next challenge before naptime.",
                "You walk into your backyard. The grass overgrown slighlty and the remnants of your garden lay to waist agaist your shed falling apart. Just there at the property line you notice your next challenge before naptime.",
                "You walk into your living room. Antiques fill each corner for ceiling to roof, most of them dating even befor your time. A moment of piece settles in until you look out the sliding back door and notice your next challenge before naptime. "
            };
            Random rand = new Random();
            int index = rand.Next(rooms.Length);
            return rooms[index];
        }

        private static Enemy GetEnemy()
        {
            Enemy gc1 = new GrandChild();
            Enemy gc2 = new GrandChild("Jason", 60, 40, 50, 10, 20, "Your teenage grandchild just here because his mom told him he had to be", 16);
            Enemy gc3 = new GrandChild("Sarah", 70, 50, 60, 15, 30, "Your eldest grandchild. Usually she only wants one thing, to dip her fingers into your savings", 21);
            Enemy n1 = new Neighbor();
            Enemy n2 = new Neighbor("Stan", 60, 40, 50, 10, 20, "Stan is a dear old neighor but boy does he like to waste your time talking about grass.", false);
            Enemy n3 = new Neighbor("Ethel", 70, 50, 60, 15, 30, "The grandma next door. She thinks she knows better and she is out to prove it.", true);
            Enemy c1 = new Cat();
            Enemy c2 = new Cat("Bitter", 60, 40, 50, 10, 20, "The roaming cat of the house. Never to be found when wanted and only to be found when inconvenient", false);
            Enemy c3 = new Cat("Ethel Cat", 70, 50, 50, 15, 30, "The fat annoying cat you dislike so much you named it after your neighbor Ethel. As always she just got done eating and wants more food", true);
            Enemy cw1 = new CrossWord();
            Enemy cw2 = new CrossWord("The puzzle book", 60, 40, 50, 10, 20, "The crossword puzzle book you get every year for christmas. You've seen all these before but your memory just isnt what it used to be, this may take some time.", false);
            Enemy cw3 = new CrossWord("The Sunday Paper Crossword", 70, 50, 50, 15, 30, "You've had your coffee now it is time to put your wits to the test. Lets see if we can get this puzzle done.", true);

            Enemy[] enemys =
            {
                gc1, gc1, gc1, gc1,
                gc2, gc2, gc2,
                gc3, gc3,
                n1, n1, n1, n1,
                n2, n2, n2, 
                n3, n3,
                c1, c1, c1, c1,
                c2, c2, c2,
                c3, c3,
                cw1, cw1, cw1, cw1,
                cw2, cw2, cw2,
                cw3, cw3,
            };
            return enemys[new Random().Next(enemys.Length)];
        }
    }
}