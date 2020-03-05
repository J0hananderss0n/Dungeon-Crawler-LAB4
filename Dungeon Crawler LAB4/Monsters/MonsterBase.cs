using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawlerVersion61.Monsters
{
    class MonsterBase
    {
        public int monsterDamage { get; set; }
        public int monsterHealth { get; set; }
        public string monsterName { get; set; }

        public MonsterBase(int monsterDamage, int monsterHealth, string monsterName)
        {
            this.monsterDamage = monsterDamage;
            this.monsterHealth = monsterHealth;
            this.monsterName = monsterName;
        }


    }
}
