using PartyGame.App.Abstract;
using PartyGame.Domain.Entity;
using System;

namespace PartyGame.App.Concrete
{
    public class LevelService : ILevelService
    {
        public int SetLevel()
        {
            int level = 0;

            while (level < 1 || level > 3)
            {
                Console.Clear();
                Console.Write("Enter difficulty level (1 / 2 / 3): ");
                var input = Console.ReadLine();

                int inputValue;
                if (int.TryParse(input, out inputValue))
                {
                    level = inputValue;
                }
            }

            AddLevels();

            Console.Clear();

            return level;
        }

        public void AddLevels()
        {
            for (int i = 0; i < 3; i++)
            {
                var level = new Level();
                level.Id = i + 1;
            }
        }
    }
}
