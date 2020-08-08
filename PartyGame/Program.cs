using System;
using System.Collections.Generic;

namespace PartyGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var actionService = new MenuActionService();
            actionService = Initialize(actionService);

            var players = new List<Player>();
            int level = 1;
            bool continueMainLoop = true;

            while (continueMainLoop)
            {
                Console.Clear();

                if (players.Count > 0)
                {
                    PlayerService.PrintPlayersList(players);
                }
                else
                {
                    Console.WriteLine("No players added");
                }

                Console.WriteLine($"Level: {level}");
                Console.WriteLine();

                var mainMenu = actionService.GetMenuActionByMenuName("Main");

                foreach (var item in mainMenu)
                {
                    Console.WriteLine($"{item.Id}. {item.Name}");
                }

                var operation = Console.ReadKey();                

                switch (operation.KeyChar)
                {
                    case '1':
                        {
                            var playerService = new PlayerService();
                            players = playerService.CreatePlayers();
                        }
                        break;
                    case '2':
                        {
                            var levelService = new LevelService();
                            level = levelService.SetLevel();

                            
                        }
                        break;
                    case '3':
                        {
                            StartGameView(players, level);
                        }
                        break;
                    case '0':
                        {
                            continueMainLoop = false;
                            Console.Clear();
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
            }
        }

        private static MenuActionService Initialize(MenuActionService actionService)
        {
            actionService.AddNewAction(1, "Choose number of players", "Main");
            actionService.AddNewAction(2, "Choose difficulty level", "Main");
            actionService.AddNewAction(3, "Start game", "Main");
            actionService.AddNewAction(0, "Exit game", "Main");

            return actionService;
        }

        private static void StartGameView (List<Player> players, int level)
        {
            
            bool continueLoop = true;
            int roundCounter = 0;
            
            Console.Clear();

            while (continueLoop)
            {
                var rolledPlayer = new Player();
                var currentPlayer = new Player(); 
                level = ProgressBar(roundCounter, players, level);
                
                Console.WriteLine("      1. Show game settings");
                Console.WriteLine("      2. Repeat round");
                Console.WriteLine("      0. Get back");
                Console.WriteLine();
                Console.WriteLine("[SPACE]. Next round");

                //Console.WriteLine("MAIN: rolledPlayer.Name = " + rolledPlayer.Name);
                //Console.WriteLine("MAIN: currentPlayer.Name = " + currentPlayer.Name);
                //Console.ReadKey();
                //GameNextMove(rolledPlayer, level, currentPlayer, players, ref roundCounter);

                var gameOperation = Console.ReadKey();

                switch (gameOperation.KeyChar)
                {
                    case '1':
                        {
                            Game.ShowGameSettings(players, level);
                        }
                        break;
                    case '2':
                        {
                            Game.RepeatRound(rolledPlayer, level, currentPlayer, players);
                        }
                        break;
                    case '0':
                        {
                            continueLoop = false;
                        }
                        break;
                    case ' ':
                        {
                            currentPlayer = players[roundCounter % players.Count];
                            roundCounter++;
                            rolledPlayer = Game.NextRound(players, level, currentPlayer);
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
            }
        }

        private static int ProgressBar(int roundCounter, List<Player> players, int level)
        {
            int progress = (int)((float)(roundCounter) / (players.Count * 8) * 100);

            if (progress > 100)
            {
                progress -= (level - 1) * 100;
            }

            Console.WriteLine($"ROUND PROGRESS: {progress}%");
            Console.WriteLine();

            if (progress == 100)
            {
                level++;
            }
            return level;
        }

        private static bool GameNextMove(Player rolledPlayer, int level, Player currentPlayer, List<Player> players, ref int roundCounter)
        {
            var gameOperation = Console.ReadKey();

            switch (gameOperation.KeyChar)
            {
                case '1':
                    {
                        Game.ShowGameSettings(players, level);
                    }
                    break;
                case '2':
                    {
                        Game.RepeatRound(rolledPlayer, level, currentPlayer, players);
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
                        rolledPlayer = Game.NextRound(players, level, currentPlayer);
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
