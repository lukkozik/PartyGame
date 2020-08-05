using System;
using System.Collections.Generic;

namespace PartyGame
{
    public class PlayerService
    {
        public List<Player> Players { get; set; }

        public PlayerService()
        {
            Players = new List<Player>();
        }

        public List<Player> CreatePlayers()
        {
            Console.Clear();
            Console.Write("Enter number of players: ");
            int numberOfPlayers = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            AddNewPlayerView(numberOfPlayers);

            return Players;
        }

        public void AddNewPlayerView(int numberOfPlayers)
        {
            for (int i = 0; i < numberOfPlayers; i++)
            {              
                Console.WriteLine($"*** ADD PLAYER ({i + 1}/{numberOfPlayers})***");
                Console.WriteLine();

                AddNewPlayer(i);

                Console.Clear();

                PrintPlayersList(Players);
            }
        }
        
        public void AddNewPlayer(int playerId)
        {
            var player = new Player();

            player.Id = playerId;

            Console.Write("Name: ");
            player.Name = Console.ReadLine();

            Console.Write("Gender (M / F): ");
            player.Gender = Convert.ToChar(Console.ReadLine().ToUpper().Trim());

            Players.Add(player);
        }
        
        public static void PrintPlayersList(List<Player> players)
        {
            Console.WriteLine("Players:");

            foreach (var player in players)
            {
                Console.Write($"   {player.Id}. ");
                if (player.Gender == 'F')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                Console.WriteLine($"{player.Name}");
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }
}
