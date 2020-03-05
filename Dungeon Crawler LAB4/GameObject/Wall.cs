

using System;

namespace DungeonCrawlerVersion61
{
    class Wall : GameObject
    {
        private const string Symbol = "#";

        public Wall(int horizontal, int vertical) : base(horizontal, vertical)
        {

        }
        public override string GetSymbol()
        {
            return Symbol;
        }

    }
}
