using System;
using System.Collections.Generic;

namespace PartyGame
{
    public class LevelService
    {
        //public List<Level> Levels { get; set; }
        //public int CurrentLevel { get; set; }

        //public LevelService()
        //{
        //    Levels = new List<Level>();
        //}

        public int SetLevel()
        {
            Console.Clear();
            Console.Write("Enter difficulty level (1 / 2 / 3): ");
            int level = Convert.ToInt32(Console.ReadLine());
            //CurrentLevel = level;

            AddLevels();

            Console.Clear();

            return level;
        }

        private void AddLevels()
        {
            for (int i = 0; i < 3; i++)
            {
                var level = new Level();
                level.Id = i + 1;
            }
        }
    }
}
