using System;
using System.Collections.Generic;
using System.Text;

namespace PartyGame
{
    class Helpers
    {
        public static void ColorName(Player player)
        {
            if (player.Gender == 'F')
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            Console.Write($"{player.Name}");
            Console.ResetColor();
        }

        public static string SetPath(Player rolledPlayer, int level)
        {
            string path = @"C:\PartyGame\";
            switch (level)
            {
                case 1:
                    {
                        if (rolledPlayer.Gender == 'M')
                        {
                            return path + "runda_1M.txt";
                        }
                        else
                        {
                            return path + "runda_1F.txt";
                        }
                    }
                case 2:
                    {
                        if (rolledPlayer.Gender == 'M')
                        {
                            return path + "runda_2M.txt";
                        }
                        else
                        {
                            return path + "runda_2F.txt";
                        }
                    }
                case 3:
                default:
                    {
                        if (rolledPlayer.Gender == 'M')
                        {
                            return path + "runda_3M.txt";
                        }
                        else
                        {
                            return path + "runda_3F.txt";
                        }
                    }
            }
        }

        public static int SetNumberOfPlayers()
        {
            int numberOfPlayers = 0;

            while (numberOfPlayers < 2)
            {
                Console.Clear();
                Console.Write("Enter number of players: ");
                var input = Console.ReadLine();

                int inputValue;
                if (int.TryParse(input, out inputValue))
                {
                    numberOfPlayers = inputValue;
                }
            }

            Console.Clear();

            return numberOfPlayers;
        }

        public static string SetPlayerName()
        {
            string name = "";
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.Write("Name: ");
                name = Console.ReadLine().ToUpper().Trim();

                if (string.IsNullOrWhiteSpace(name))
                {
                    ClearCurrentConsoleLine();
                }                    
            }

            return name;
        }

        public static char SetPlayerGender()
        {
            string gender = "";
            while (string.IsNullOrWhiteSpace(gender) || !(gender == "M" || gender == "F"))
            {
                Console.Write("Gender (M / F): ");
                gender = Console.ReadLine().ToUpper().Trim();

                ClearCurrentConsoleLine();
            }

            return Convert.ToChar(gender);
        }

        public static void ClearCurrentConsoleLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);            
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
