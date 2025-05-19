using System;

namespace Practice1
{
    internal class Program
    {
        static void Main()
        {
            string name = GetName();
            int age = GetAge();

            if (age < 12)
            {
                Console.WriteLine("\n\u274C Ви можете грати лише з 12 років!");
                return;
            }

            RunGame(name, age);
        }

        static string GetName()
        {
            while (true)
            {
                Console.Write("\n\uD83D\uDC64 Введіть ваш нікнейм: ");
                string name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("\u26A0\uFE0F Ім'я не може бути порожнім.");
                }
                else return name.Trim();
            }
        }

        static int GetAge()
        {
            while (true)
            {
                Console.Write("\n\uD83D\uDC76 Введіть ваш вік: ");
                if (int.TryParse(Console.ReadLine(), out int age) && age > 0)
                {
                    return age;
                }
                else
                {
                    Console.WriteLine("\u26A0\uFE0F Введіть коректний вік (число).");
                }
            }
        }

        static void RunGame(string name, int age)
        {
            int totalRounds = 0;
            int totalWins = 0;
            Random random = new Random();

            while (true)
            {
                DisplayStats(name, age, totalRounds, totalWins);
                Console.Write("\n\u2694\uFE0F Вирушаємо в бій? (так/ні): ");
                string answer = Console.ReadLine().Trim().ToLower();

                if (answer == "ні")
                {
                    Console.WriteLine($"\n\uD83D\uDC4B Бувай, {name}! До зустрічі!");
                    break;
                }
                else if (answer == "так")
                {
                    int wins = 0;
                    int losses = 0;

                    for (int i = 1; i <= 3; i++)
                    {
                        Console.WriteLine($"\nРаунд {i}/3:");
                        WeaponType userChoice = GetUserWeapon();
                        WeaponType enemyChoice = (WeaponType)random.Next(1, 4);

                        ShowWeapons(userChoice, enemyChoice);

                        int result = DetermineRoundResult(userChoice, enemyChoice);

                        if (result == 1)
                        {
                            Console.WriteLine("\u2705 Ви виграли раунд!");
                            wins++;
                        }
                        else if (result == -1)
                        {
                            Console.WriteLine("\u274C Ви програли раунд.");
                            losses++;
                        }
                        else
                        {
                            Console.WriteLine("\uD83D\uDD01 Нічия.");
                        }

                        totalRounds++;
                    }

                    if (wins == 3 || (wins == 2 && losses == 1))
                    {
                        totalWins++;
                        Console.WriteLine($"\n\uD83C\uDFC6 Ви виграли бій!");
                    }
                    else
                    {
                        Console.WriteLine($"\n\uD83D\uDE14 Ви програли бій.");
                    }
                }
                else
                {
                    Console.WriteLine("\u2753 Невідомий варіант. Введіть 'так' або 'ні'.");
                }
            }
        }

        static WeaponType GetUserWeapon()
        {
            while (true)
            {
                Console.Write("Оберіть зброю (камінь/ножиці/папір): ");
                string input = Console.ReadLine().Trim().ToLower();

                switch (input)
                {
                    case "камінь": return WeaponType.Rock;
                    case "папір": return WeaponType.Paper;
                    case "ножиці": return WeaponType.Scissors;
                    default:
                        Console.WriteLine("\u26A0\uFE0F Невідома зброя. Спробуйте ще раз.");
                        break;
                }
            }
        }

        static void ShowWeapons(WeaponType user, WeaponType enemy)
        {
            Console.WriteLine("\nВи:    " + GetWeaponArt(user));
            Console.WriteLine("Противник: " + GetWeaponArt(enemy));
        }

        static string GetWeaponArt(WeaponType weapon)
        {
            return weapon switch
            {
                WeaponType.Rock => "[КАМІНЬ]",
                WeaponType.Paper => "[ПАПІР]",
                WeaponType.Scissors => "[НОЖИЦІ]",
                _ => "[Невідомо]"
            };
        }

        static int DetermineRoundResult(WeaponType user, WeaponType enemy)
        {
            if (user == enemy) return 0;
            if ((user == WeaponType.Rock && enemy == WeaponType.Scissors) ||
                (user == WeaponType.Scissors && enemy == WeaponType.Paper) ||
                (user == WeaponType.Paper && enemy == WeaponType.Rock))
            {
                return 1;
            }
            return -1;
        }

        static void DisplayStats(string name, int age, int rounds, int wins)
        {
            Console.WriteLine("\n+-----------------------------+");
            Console.WriteLine($"| Гравець: {name.PadRight(20)}|");
            Console.WriteLine($"| Вік: {age.ToString().PadRight(24)}|");
            Console.WriteLine($"| Зіграно раундів: {rounds.ToString().PadRight(11)}|");
            Console.WriteLine($"| Перемог: {wins.ToString().PadRight(20)}|");
            Console.WriteLine("+-----------------------------+");
        }
    }
}