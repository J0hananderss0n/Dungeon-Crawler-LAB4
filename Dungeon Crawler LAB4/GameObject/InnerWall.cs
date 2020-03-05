using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawlerVersion61
{
    class InnerWall : GameObject
    {
        private const string Symbol = "#";

        public InnerWall(int horizontal, int vertical) : base(horizontal, vertical)
        {

        }

        public override string GetSymbol()
        {
            return Symbol;
        }
    }
}
