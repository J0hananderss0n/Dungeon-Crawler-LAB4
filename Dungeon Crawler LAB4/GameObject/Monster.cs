using System;
using DungeonCrawlerVersion61.Monsters;
namespace DungeonCrawlerVersion61
{
    class Monster : GameObject, IActionable
    {
        private const string Symbol = "M";
        public Monster(int horizontal, int vertical) : base(horizontal, vertical)
        {
        }
        public override string GetSymbol()
        {
            return Symbol;
        }
        public override void Action(Player player)
        {
            Console.Clear();
            Random random = new Random();
            int randomNumber = random.Next(1, 4);
            player.UpdatePlayerDamage();
            
            if (randomNumber == 1)
            {
                IFightMonster Giant = new FightingMonsters(2, 10, "Mr Giant");
                Giant.Fight(player);
            }
            else if (randomNumber == 2)
            {
                IFightMonster MonsterSnake = new FightingMonsters(5, 20, "Sir Snake");
                MonsterSnake.Fight(player);
                Console.WriteLine("When you killed Sir Snake he dropped a bronze sword\n" +
                                  "You pick up the sword");                
                player.bronzeSword = true;
            }
            else if (randomNumber == 3)
            {
                IFightMonster MonsterCat = new FightingMonsters(10, 10, "Miss Cat");
                MonsterCat.Fight(player);
                Console.WriteLine("After killing Miss Cat you found a silver sword in the corner of the room\n" +
                                  "You pick up the sword");
                player.silverSword = true;                  
            }
            else if (randomNumber == 4)
            {
                IFightMonster MonsterDragon = new FightingMonsters(8, 15, "Monster Dragon");
                MonsterDragon.Fight(player);
            }
            Console.ReadKey(true);
        }        
    }
}