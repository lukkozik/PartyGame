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
            Console.Write("Press any key to get back... ");
            Console.ReadKey();
            Console.Clear();
        }

        public static Player NextRound(List<Player> players, int level, Player currentPlayer)
        {
            Player rolledPlayer = players[DrawPlayer(players, currentPlayer)];
            string task = DrawTask(rolledPlayer, level);

            WriteTask(rolledPlayer, task, currentPlayer, players);

            return rolledPlayer;
        }

        public static void RepeatRound(Player rolledPlayer, int level, Player currentPlayer, List<Player> players)
        {
            Console.Clear();

            if (!string.IsNullOrWhiteSpace(rolledPlayer.Name))
            {
                string task = DrawTask(rolledPlayer, level);
                WriteTask(rolledPlayer, task, currentPlayer, players);
            }
            else
            {
                Console.WriteLine("Press [SPACE] to start game");
                Console.WriteLine();
            }
        }

        private static int DrawPlayer(List<Player> players, Player currentPlayer)
        {
            int rolledPlayerId = -1;

            while (currentPlayer.Id == rolledPlayerId || rolledPlayerId == -1)
            {
                var random = new Random();
                rolledPlayerId = random.Next(0, players.Count);
            }

            return rolledPlayerId;
        }

        private static string DrawTask(Player rolledPlayer, int level)
        {
            string path = Helpers.SetPath(rolledPlayer, level);
            var tasks = string.Concat(string.Concat(File.ReadAllText(path).Split("\n\n")).Split('\n')).Trim().Split(".;");
            var random = new Random();

            return tasks[random.Next(0, tasks.Length - 1)];
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
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        public static bool GameNextMove(ref Player rolledPlayer, int level, ref Player currentPlayer, List<Player> players, ref int roundCounter)
        {
            var gameOperation = Console.ReadKey();

            switch (gameOperation.KeyChar)
            {
                case '1':
                    {
                        ShowGameSettings(players, level);
                    }
                    break;
                case '2':
                    {
                        RepeatRound(rolledPlayer, level, currentPlayer, players);
                    }
                    break;
                case '0':
                    {
                        return false;
                    }
                case ' ':
                    {
                        currentPlayer = players[roundCounter % players.Count];
                        roundCounter++;
                        rolledPlayer = NextRound(players, level, currentPlayer);
                    }
                    break;
                default:
                    {
                        Console.Clear();
                        Console.WriteLine("Action you entered does not exist");
                        Console.WriteLine();
                    }
                    break;
            }

            return true;
        }

    }
}
