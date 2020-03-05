using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonCrawlerVersion61
{
    public class Map
    {

        public static char[,] exploredSquares = new char[12, 12] {  {'#' , '#' , '#' , '#' , '#' , '#' , '#' , '#' , '#' , '#' , '#' , '#'},
                                                                    {'#' , 'E' , ' ' , 'H' , 'I' , ' ' , ' ' , ' ' , ' ' , 'M' , 'H' , '#'},
                                                                    {'#' , ' ' , 'I' , 'I' , 'I' , ' ' , 'I' , ' ' , 'I' , 'I' , 'I' , '#'},
                                                                    {'#' , ' ' , 'D' , ' ' , ' ' , ' ' , 'I' , ' ' , 'C' , 'I' , 'G' , '#'},
                                                                    {'#' , ' ' , 'T' , ' ' , 'I' , 'I' , 'I' , 'D' , 'I' , 'I' , ' ' , '#'},
                                                                    {'#' , 'M' , 'I' , 'I' , 'I' , ' ' , ' ' , ' ' , 'I' , 'H' , ' ' , '#'},
                                                                    {'#' , 'C' , 'I' , ' ' , ' ' , ' ' , 'I' , 'T' , ' ' , 'I' , ' ' , '#'},
                                                                    {'#' , 'I' , 'I' , ' ' , 'I' , 'I' , 'I' , ' ' , ' ' , 'I' , ' ' , '#'},
                                                                    {'#' , ' ' , ' ' , ' ' , 'I' , ' ' , 'D' , ' ' , ' ' , 'I' , ' ' , '#'},
                                                                    {'#' , 'M' , 'I' , ' ' , 'I' , ' ' , 'I' , 'I' , ' ' , 'I' , 'D' , '#'},
                                                                    {'#' , 'C' , 'I' , ' ' , ' ' , ' ' , 'C' , 'I' , ' ' , 'M' , ' ' , '#'},
                                                                    {'#' , '#' , '#' , '#' , '#' , '#' , '#' , '#' , '#' , '#' , '#' , '#'} };



        public List<GameObject> gameObjects { get; set; }

        public void PrintMap(Player player)
        {
            for (int vertical = 0; vertical < exploredSquares.GetLength(0); vertical++)
            {
                for (int horizontal = 0; horizontal < exploredSquares.GetLength(1); horizontal++)
                {
                    var gameObject = gameObjects.Where(go => go.horizontal == horizontal && go.vertical == vertical).FirstOrDefault();

                    if (player.position.vertical == vertical && player.position.horizontal == horizontal)
                    {
                        Console.Write("@");
                    }
                    else if (gameObject is Wall)
                    {
                        Console.Write("#");
                    }
                    else if (ShouldWeRenderGameObject(player, horizontal, vertical))
                    {
                        if(gameObject == null)
                        {
                            Console.Write(" ");
                        }
                        else
                        {
                            // Changing InnerWall to Wall after its printed first time to make it stay on map
                            Console.Write(gameObject.GetSymbol());
                            if (gameObject is InnerWall)
                            {
                                gameObjects.Remove(gameObject);
                                gameObjects.Add(new Wall(horizontal, vertical));
                            }
                        }                        
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine("");
            }            
        }

        private bool ShouldWeRenderGameObject(Player player, int horizontal, int vertical)
        {
            if ((player.position.vertical - 1) == vertical && player.position.horizontal == horizontal)
            {
                return true;
            }
            else if (player.position.vertical == vertical && (player.position.horizontal + 1) == horizontal)
            {
                return true;
            }
            else if ((player.position.vertical + 1) == vertical && player.position.horizontal == horizontal)
            {
                return true;
            }
            else if (player.position.vertical == vertical && (player.position.horizontal - 1) == horizontal)
            {
                return true;
            }           

            return false;
        }

        public static Map CreateMap()
        {
            var map = new Map();
            map.gameObjects = new List<GameObject>();
            for (int vertical = 0; vertical < exploredSquares.GetLength(0); vertical++)
            {
                for (int horizontal = 0; horizontal < exploredSquares.GetLength(1); horizontal++)
                {
                    if (exploredSquares[vertical, horizontal] == '#')
                    {
                        map.gameObjects.Add(new Wall(horizontal, vertical));
                    }
                    else if (exploredSquares[vertical, horizontal] == 'T')
                    {
                        map.gameObjects.Add(new Trap(horizontal, vertical));
                    }
                    else if (exploredSquares[vertical, horizontal] == 'D')
                    {
                        map.gameObjects.Add(new Door(horizontal, vertical));
                    }
                    else if (exploredSquares[vertical, horizontal] == 'M')
                    {
                        map.gameObjects.Add(new Monster(horizontal, vertical));
                    }
                    else if (exploredSquares[vertical, horizontal] == 'C')
                    {
                        map.gameObjects.Add(new Chest(horizontal, vertical));
                    }
                    else if (exploredSquares[vertical, horizontal] == 'H')
                    {
                        map.gameObjects.Add(new HealthPotion(horizontal, vertical));
                    }
                    else if (exploredSquares[vertical, horizontal] == 'E')
                    {
                        map.gameObjects.Add(new Entrance(horizontal, vertical));
                    }
                    else if (exploredSquares[vertical, horizontal] == 'G')
                    {
                        map.gameObjects.Add(new Goal(horizontal, vertical));
                    }
                    else if (exploredSquares[vertical, horizontal] == 'I')
                    {
                        map.gameObjects.Add(new InnerWall(horizontal, vertical));
                    }
                }                
            }

            return map;
        }
    }
}