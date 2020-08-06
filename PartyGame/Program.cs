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
            int level = 0;

            bool continueMainLoop = true;

            while (continueMainLoop)
            {
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

                            PlayerService.PrintPlayersList(players);
                            Console.WriteLine($"Level: {level}");
                            Console.WriteLine();
                        }
                        break;
                    case '3':
                        {
                            Console.Clear();
                            
                            var rolledPlayer = new Player();
                            var currentPlayer = new Player();
                            bool continueLoop = true;
                            int i = 0;

                            while (continueLoop)
                            {
                                
                                
                                Console.WriteLine("      1. Show game settings");
                                Console.WriteLine("      2. Reroll task");
                                Console.WriteLine("      0. Get back");
                                Console.WriteLine();
                                Console.WriteLine("[SPACE]. Next round");

                                var gameOperation = Console.ReadKey();

                                switch (gameOperation.KeyChar)
                                {
                                    case '1':
                                        {
                                            Game.ShowGameSettings(players, level);
                                            Console.Write("Press any key to get back... ");
                                            Console.ReadKey();
                                            Console.Clear();
                                        }
                                        break;
                                    case '2':
                                        {
                                            Console.Clear(); 
                                            Game.RerollTask(rolledPlayer, level, currentPlayer, players);
                                        }
                                        break;
                                    case '0':
                                        {
                                            continueLoop = false;
                                            Console.Clear();
                                        }
                                        break;
                                    case ' ':
                                        {
                                            currentPlayer = players[i % players.Count];
                                            i++;
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
    }
}
