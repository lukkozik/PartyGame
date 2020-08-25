using PartyGame.Domain.Entity;
using System;
using System.Collections.Generic;

namespace PartyGame.App.Concrete
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
            int numberOfPlayers = Helpers.SetNumberOfPlayers();

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

            player.Name = Helpers.SetPlayerName();
            player.Gender = Helpers.SetPlayerGender();

            Players.Add(player);
        }

        public static void PrintPlayersList(List<Player> players)
        {
            Console.WriteLine("Players:");

            foreach (var player in players)
            {
                Console.Write($"   {player.Id + 1}. ");
                Helpers.ColorName(player);
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
