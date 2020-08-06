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
                default:
                    {
                        return path + "runda_0.txt";
                    }
            }
        }
    }
}
