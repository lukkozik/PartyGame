using PartyGame.App.Concrete;
using PartyGame.App.Helpers;
using PartyGame.Domain.Entity;
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
            Player randomPlayer = players[DrawPlayer(players, currentPlayer)];
            string quest = DrawQuest(randomPlayer, level);

            WriteQuest(randomPlayer, quest, currentPlayer, players);

            return randomPlayer;
        }

        public static void RepeatRound(Player randomPlayer, int level, Player currentPlayer, List<Player> players)
        {
            Console.Clear();

            if (!string.IsNullOrWhiteSpace(randomPlayer.Name))
            {
                string quest = DrawQuest(randomPlayer, level);
                WriteQuest(randomPlayer, quest, currentPlayer, players);
            }
            else
            {
                Console.WriteLine("Press [SPACE] to start game");
                Console.WriteLine();
            }
        }

        private static int DrawPlayer(List<Player> players, Player currentPlayer)
        {
            int randomPlayerId = -1;

            while (currentPlayer.Id == randomPlayerId || randomPlayerId == -1)
            {
                var random = new Random();
                randomPlayerId = random.Next(0, players.Count);
            }

            return randomPlayerId;
        }

        private static string DrawQuest(Player randomPlayer, int level)
        {
            string path = Helpers.SetPath(randomPlayer, level);
            var quests = string.Concat(string.Concat(File.ReadAllText(path).Split("\n\n")).Split('\n')).Trim().Split(".;");
            var random = new Random();

            return quests[random.Next(0, quests.Length - 1)];
        }

        private static void WriteQuest(Player randomPlayer, string quest, Player currentPlayer, List<Player> players)
        {
            var nextPlayer = players[(currentPlayer.Id + 1) % players.Count];

            Console.Clear();
            Helpers.ColorName(currentPlayer);
            Console.Write("  ==>  ");

            Helpers.ColorName(randomPlayer);
            Console.WriteLine(": ");
            Console.WriteLine(quest);

            Console.WriteLine();
            Console.Write("Next turn: ");
            Helpers.ColorName(nextPlayer);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        public static bool GameNextMove(ref Player randomPlayer, int level, ref Player currentPlayer, List<Player> players, ref int roundCounter)
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
                        RepeatRound(randomPlayer, level, currentPlayer, players);
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
                        randomPlayer = NextRound(players, level, currentPlayer);
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
