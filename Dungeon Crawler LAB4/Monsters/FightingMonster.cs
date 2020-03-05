using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace DungeonCrawlerVersion61.Monsters
{
    internal class FightingMonsters : MonsterBase, IFightMonster
    {
        public FightingMonsters(int monsterDamage, int monsterHealth, string monsterName) : base(monsterDamage, monsterHealth, monsterName)
        {
        }
        public void Fight(Player player)
        {
            Console.WriteLine(
                $"You see a monster in the room. It's {monsterName}!\n" +
                $"{monsterName} has {monsterDamage} in damage and {monsterHealth} healthpoints.\n" +
                $"You have {player.playerAttackDamage} in damage\n" +
                $"Press any key when you are ready to fight {monsterName}");
            Console.ReadKey(true);
            Console.Clear();
            bool turn = true; // true = player turn, false = monster turn
            do
            {
                if (turn == true)
                {
                    Console.WriteLine($"You hit the {monsterName} for {player.playerAttackDamage} ");
                    monsterHealth = monsterHealth - player.playerAttackDamage;
                    Console.WriteLine($"{monsterName} have {monsterHealth} left");                   
                    Thread.Sleep(1000);
                    turn = false;
                }
                else if (turn == false)
                {
                    Console.WriteLine($"{monsterName} hit you for {monsterDamage}");
                    player.playerHealthPoints = player.playerHealthPoints - monsterDamage;
                    Console.WriteLine("You have " + player.playerHealthPoints + " left");
                    Thread.Sleep(1000);
                    turn = true;
                }
            } 

            while (player.playerHealthPoints > 0 && monsterHealth > 0);
                Thread.Sleep(1000);
                Console.Clear();

                if (monsterHealth > 0)
                {
                    Console.WriteLine($"You lost the fight against {monsterName}");
                    EndOfGame endOfGame = new EndOfGame();
                    endOfGame.EndingGame(player);
                }
                else
                {
                    Console.WriteLine($"After a hard fight against {monsterName} you are victorious!");
                }
        }
    }
}