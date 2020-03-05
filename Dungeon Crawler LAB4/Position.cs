using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawlerVersion61
{
    public class Position
    {
        public int horizontal { get; set; }
        public int vertical { get; set; }

        public Position(int horizontal, int vertical)
        {
            this.horizontal = horizontal;
            this.vertical = vertical;            
        }
    }
}
