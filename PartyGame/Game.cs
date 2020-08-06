using System;
using System.Collections.Generic;
using System.IO;

namespace PartyGame
{
    public class Game
    {
        public PlayerService Players { get; set; }
        public Level GameLevel { get; set; }

        public static void ShowGameSettings(List<Player> players, int level)
        {
            Console.Clear();
            PlayerService.PrintPlayersList(players);
            Console.WriteLine($"Level: {level}");
            Console.WriteLine();
        }

        public static Player NextRound(List<Player> players, int level, Player currentPlayer)
        {
            Player rolledPlayer = players[RollPlayer(players, currentPlayer)];
            string task = RollTask(rolledPlayer, level);

            WriteTask(rolledPlayer, task, currentPlayer, players);

            return rolledPlayer;
        }

        private static int RollPlayer(List<Player> players, Player currentPlayer)
        {
            int rolledPlayerId = -1;

            while (currentPlayer.Id == rolledPlayerId || rolledPlayerId == -1)
            {
                var random = new Random();
                rolledPlayerId = random.Next(0, players.Count);
            }

            return rolledPlayerId;
        }

        private static string RollTask(Player rolledPlayer, int level)
        {
            string path = Helpers.SetPath(rolledPlayer, level);
            var tasks = string.Concat(string.Concat(File.ReadAllText(path).Split("\n\n")).Split('\n')).Trim().Split(".;");
            var random = new Random();

            return tasks[random.Next(0, tasks.Length - 1)];
        }

        public static void RerollTask(Player rolledPlayer, int level, Player currentPlayer, List<Player> players)
        {
            Console.Clear(); 
            
            if (rolledPlayer.Id > 0)
            {
                string task = RollTask(rolledPlayer, level);
                WriteTask(rolledPlayer, task, currentPlayer, players);
            }
            else
            {
                Console.WriteLine("Press [SPACE] to start game");
                Console.WriteLine();
            }
        }

        private static void WriteTask(Player rolledPlayer, string task, Player currentPlayer, List<Player> players)
        {
            var nextPlayer = players[(currentPlayer.Id + 1) % players.Count];

            Console.Clear();
            Helpers.ColorName(currentPlayer);
            Console.Write("  ==>  ");

            Helpers.ColorName(rolledPlayer);
            Console.Write(": ");
            Console.WriteLine(task);

            Console.WriteLine();
            Console.Write("Next turn: ");
            Helpers.ColorName(nextPlayer);
            Console.Write(": ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
