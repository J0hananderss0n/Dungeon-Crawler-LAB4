using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawlerVersion61
{
    class Chest : GameObject, IActionable
    {
        private const string Symbol = "C";

        public Chest(int horizontal, int vertical) : base(horizontal, vertical)
        {

        }
        public override string GetSymbol()
        {
            return Symbol;
        }

        public override void Action(Player player)
        {
            if (player.position.horizontal == 1 && player.position.vertical == 5 || player.position.horizontal == 7 && player.position.vertical == 3)
            {
                Console.WriteLine("You picked up a normal key");
                Console.ReadKey(true);
                player.normalKey = true;
            }
            else if (player.position.horizontal == 1 && player.position.vertical == 9)
            {
                Console.WriteLine("You picked up a red key.");
                Console.ReadKey(true);
                player.redKey = true;
            }
            else if (player.position.horizontal == 5 && player.position.vertical == 10)
            {
                Console.WriteLine("You picked up a blue key.");
                Console.ReadKey(true);
                player.blueKey = true;
            }
        }
    }
}
