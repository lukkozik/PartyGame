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
    }
}
