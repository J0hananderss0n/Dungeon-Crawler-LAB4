using System;
namespace DungeonCrawlerVersion61
{
    class Trap : GameObject, IActionable
    {
        private const string Symbol = "T";
        public Trap(int horizontal, int vertical) : base(horizontal, vertical)
        {
        }
        public override string GetSymbol()
        {
            return Symbol;
        }
        public override void Action(Player player)
        {
            Console.Clear();
            Console.WriteLine("You just walked on a trap and lost 50 healthpoints");
            player.playerHealthPoints -= 50;
            Console.ReadKey(true);
        }
    }
}