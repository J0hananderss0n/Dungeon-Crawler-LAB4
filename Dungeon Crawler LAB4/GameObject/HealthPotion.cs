using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawlerVersion61
{
    class HealthPotion : GameObject, IActionable
    {
        private const string Symbol = "H";

        public HealthPotion(int horizontal, int vertical) : base(horizontal, vertical)
        {

        }
        public override string GetSymbol()
        {
            return Symbol;
        }

        public override void Action(Player player)
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 4);
            int healthPotionSize = 0;
            if(randomNumber == 1)
            {
                healthPotionSize = 50;
            }
            else if (randomNumber == 2)
            {
                healthPotionSize = 10;
            }
            else if (randomNumber == 3)
            {
                healthPotionSize = 25;
            }
            else if (randomNumber == 4)
            {
                healthPotionSize = 100;
            }
            player.playerHealthPoints = player.playerHealthPoints + healthPotionSize;
            Console.WriteLine("You increased your health with " + healthPotionSize + " healthpoints");
            Console.WriteLine("Your current healthpoints are " + player.playerHealthPoints);
            Console.ReadKey(true);
        }
    }
}
