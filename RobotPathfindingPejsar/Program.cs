using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotPathfindingPejsar
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = -1;
            int end = -2;

            int stepCounter = 0;

            int[,] steps = new int[30, 2];

            int[,] map = new int[,]
            {
                {0, start, 0, 0, 0 },
                {-3, -3, 0, -3, -3 },
                {-3, -3, 0, 0, 0 },
                {end, 0, 0, -3, 0 },
                {-3, -3, -3, -3, 0 },
                {-0, -3, -3, -3, 0 }
            };

            int positionX = 0;
            int positionY = 0;

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == start)
                    {
                        positionY = i;
                        positionX = j;
                    }
                }
            }

            while (map[positionY, positionX] != end)
            {
                map[positionY, positionX] = stepCounter;

                if (positionY - 1 >= 0)
                {
                    if (map[positionY - 1, positionX] == 0 || map[positionY - 1, positionX] == end)
                    {
                        steps[stepCounter, 0] = positionY;
                        steps[stepCounter, 1] = positionX;

                        stepCounter++;
                        positionY -= 1;
                        continue;
                    }
                }
                if (positionX + 1 < map.GetLength(1))
                {
                    if (map[positionY, positionX + 1] == 0 || map[positionY, positionX + 1] == end)
                    {
                        steps[stepCounter, 0] = positionY;
                        steps[stepCounter, 1] = positionX;

                        stepCounter++;
                        positionX++;
                        continue;
                    }
                }
                if (positionX - 1 >= 0)
                {
                    if (map[positionY, positionX - 1] == 0 || map[positionY, positionX - 1] == end)
                    {
                        steps[stepCounter, 0] = positionY;
                        steps[stepCounter, 1] = positionX;

                        stepCounter++;
                        positionX -= 1;
                        continue;
                    }
                }
                if (positionY + 1 < map.GetLength(0))
                {
                    if (map[positionY + 1, positionX] == 0 || map[positionY + 1, positionX] == end)
                    {
                        steps[stepCounter, 0] = positionY;
                        steps[stepCounter, 1] = positionX;

                        stepCounter++;
                        positionY++;
                        continue;
                    }
                }


                map[positionY, positionX] = -3;
                positionY = steps[stepCounter - 1, 0];
                positionX = steps[stepCounter - 1, 1];
                stepCounter -= 1;
            }

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] >= 0)
                    {
                        Console.Write(" " + map[i, j]);
                    }
                    else if (map[i, j] >= -2)
                    {
                        Console.Write(" K");
                    }
                    else
                    {
                        Console.Write(map[i, j]);
                    }
                }
                Console.WriteLine();
            }

            for (int i = 0; i < steps.GetLength(0); i++)
            {
                Console.Write(i + 1 + ". krok ");
                for (int j = 0; j < steps.GetLength(1); j++)
                {
                    Console.Write(steps[i, j]);
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        //private bool IsNextStep(int[,] map, int positionX, int positionY)
        //{

        //}
    }
}
