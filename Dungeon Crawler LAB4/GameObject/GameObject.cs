using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawlerVersion61
{
    public abstract class GameObject
    {
        public int horizontal { get; set; }
        public int vertical { get; set; }

        public GameObject(int horizontal, int vertical)
        {
            this.horizontal = horizontal;
            this.vertical = vertical;
        }

        public virtual string GetSymbol()
        {
            return "";
        }
       

        public virtual void Action(Player player)
        {
            
        }
    }
}
