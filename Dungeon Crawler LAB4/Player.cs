using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DungeonCrawlerVersion61
{
    public class Player
    {

        public Position position { get; set; }

        public int playerHealthPoints = 500;        
        public int playerAttackDamage = 5;
        public bool bronzeSword = false;
        public bool silverSword = false;
        public bool redKey = false;
        public bool blueKey = false;
        public bool normalKey = false;

        public Player()
        {
            position = new Position(1, 1);
        }

        public int UpdatePlayerDamage ()
        {
            if (bronzeSword == true && silverSword == true)
            {
                return playerAttackDamage = 12;
            }
            else if (bronzeSword == true)
            {
                return playerAttackDamage = 8;
            }
            else if (silverSword == true)
            {
                return playerAttackDamage = 7;
            }
            else
                return playerAttackDamage = 5;
        }

        public void PlayerMoveAndRoomAction(Map map, Player player)
        {
            while (true)
            {
                var input = Console.ReadKey(true);
                Console.WriteLine();
                if (!IsValidMovementInput(input.Key))
                {
                    Console.WriteLine("Invalid input..\n" +
                        "Use W,A,S,D to move ");
                    continue;
                }

                var newPosition = GetNewPositionFromMovement(input.Key, this.position);
                var gameObject = map.gameObjects.Where(go => go.horizontal == newPosition.horizontal && go.vertical == newPosition.vertical).FirstOrDefault();

                if (gameObject is Wall)
                {
                    Console.WriteLine("You hit a wall and lost 15 HP.");
                    this.playerHealthPoints -= 15;
                    Console.WriteLine(playerHealthPoints);
  
                    Thread.Sleep(1000);
                    return;
                }
                if (gameObject is Door)
                {
                    if (newPosition.horizontal == 2 && newPosition.vertical == 3 && normalKey == true || newPosition.horizontal == 7 && newPosition.vertical == 4 && normalKey == true)
                    {
                        Console.WriteLine("You opened the door");
                        Console.ReadKey(true);
                        normalKey = false;
                        map.gameObjects.Remove(gameObject);
                    }
                    else if (newPosition.horizontal == 6 && newPosition.vertical == 8 && redKey == true)
                    {
                        Console.WriteLine("You opened the red door");
                        Console.ReadKey(true);
                        player.redKey = false;
                        map.gameObjects.Remove(gameObject);
                    }
                    else if (newPosition.horizontal == 10 && newPosition.vertical == 9 && blueKey == true)
                    {
                        Console.WriteLine("You opened the blue door");
                        Console.ReadKey(true);
                        player.blueKey = false;
                        map.gameObjects.Remove(gameObject);
                    }
                    else
                    {
                        Console.WriteLine("The door is locked. Go and find a key to open it");
                        Console.ReadKey(true);
                        return;
                    }
                }
                               
                if (gameObject is IActionable)
                {
                    var actionable = (IActionable)gameObject;
                    gameObject.Action(player);
                    map.gameObjects.Remove(gameObject);                    
                }

                this.position = newPosition;
                playerHealthPoints -= 5; //Healthpoints lost on every move
                return;             
            }            
        }

        private bool IsValidMovementInput(ConsoleKey playerInput)
        {
            return playerInput == ConsoleKey.W || playerInput == ConsoleKey.D || playerInput == ConsoleKey.S || playerInput == ConsoleKey.A;
        }

        private Position GetNewPositionFromMovement(ConsoleKey playerInput, Position position)
        {
            switch (playerInput)
            {
                case ConsoleKey.W:
                    return new Position(position.horizontal, position.vertical - 1);
                    
                case ConsoleKey.D:
                    return new Position(position.horizontal + 1, position.vertical);
                    
                case ConsoleKey.S:
                    return new Position(position.horizontal, position.vertical + 1);
                    
                case ConsoleKey.A:
                    return new Position(position.horizontal -1, position.vertical);
                    
            }
            //This should never happend...
            return new Position(1, 1);
        }

        public void PlayerSwordsInInventory()
        {
            if (bronzeSword == true && silverSword == true)
            {
                Console.WriteLine("You have combined a bronze and a silver sword, and now have the golden sword");
            }
            else if (bronzeSword == true)
            {
                Console.WriteLine("You have the bronze sword");
            }
            else if (silverSword == true)
            {
                Console.WriteLine("You have the silver sword");
            }
        }
        public void PlayerKeysInInventory()
        {
            if (blueKey == true)
            {
                Console.WriteLine("You have the blue key");
            }
            if (redKey == true)
            {
                Console.WriteLine("You have the red key");
            }
            if (normalKey == true)
            {
                Console.WriteLine("You have a normal key");
            }
        }
    }
}
