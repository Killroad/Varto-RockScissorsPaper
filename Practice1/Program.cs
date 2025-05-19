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
                    totalRounds++;
                }
                else
                {
                    Console.WriteLine("\u2753 Невідомий варіант. Введіть 'так' або 'ні'.");
                }
            }
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
