using System;

namespace DungeonCrawlerVersion61
{
    class Door : GameObject
    {
        private const string Symbol = "D";

        public Door(int horizontal, int vertical) : base(horizontal, vertical)
        {

        }
        public override string GetSymbol()
        {
            return Symbol;
        }
    }
}

