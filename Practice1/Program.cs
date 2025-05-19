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

            RunGame();
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

        static void RunGame()
        {
            // TODO: Play the game loop
            // TODO: Show statistics
        }

        // TODO: Add more methods

    }
}