using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Lab 4, Dungeon Crawler, av Andreé Mattsson och Johan Andersson ITHS Höst 2019

namespace DungeonCrawlerVersion61
{
    class Program
    {
        static void Main(string[] args)
        {
            Map map = Map.CreateMap();
            Player player = new Player();
            EndOfGame endOfGame = new EndOfGame();

            Console.WriteLine(
                "Welcome to dungeon crawler!\n" 
                + "The goal of this game is to reach the end with as much healthpoints left as possible.\n" 
                + "You will lose healthpoints on every move you make and you will have to fight some monsters on the way.\n"
                + "There is also some doors that you will need to find a key to open\n"
                + "Good luck!\n"
                + "Press any key to start");
            Console.ReadKey();
            Console.Clear();

            do
            {
                Console.WriteLine("Your current healthpoints is " + player.playerHealthPoints + "\n" +
                    "Your current attack damage is " + player.playerAttackDamage);
                player.PlayerSwordsInInventory();
                player.PlayerKeysInInventory();                               
                map.PrintMap(player);
                player.PlayerMoveAndRoomAction(map, player);
                Console.Clear();

            } while (player.playerHealthPoints > 0);

            endOfGame.EndingGame(player);
        }
    }
}
