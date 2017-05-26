using System;
using System.Collections.Generic;
using System.IO;

namespace _07.Distance_in_Labyrinth
{
    class Program
    {
        static void Main(string[] args)
        {
            int mazeSize = int.Parse(Console.ReadLine());

            int[,] maze = ReadMaze(mazeSize);

            ExploreLabyrinth(ref maze);

            PrintMaze(ref maze);
        }

        private static void ExploreLabyrinth(ref int[,] maze)
        {
            Queue<Tuple<int, int, int>> queue = new Queue<Tuple<int, int, int>>();

            queue.Enqueue(FindStartPosition(ref maze));

            while (queue.Count > 0)
            {
                Tuple<int, int, int> current = queue.Dequeue();

                int x = current.Item1;
                int y = current.Item2;
                int step = current.Item3;

                if (maze[x, y] == 0)
                {
                    maze[x, y] = step;
                }

                step++;

                if (x - 1 >= 0 && maze[x - 1, y] == 0) // Left
                {
                    queue.Enqueue(new Tuple<int, int, int>(x - 1, y, step));
                }

                if (x + 1 < maze.GetLength(0) && maze[x + 1, y] == 0) // Right
                {
                    queue.Enqueue(new Tuple<int, int, int>(x + 1, y, step));
                }

                if (y - 1 >= 0 && maze[x, y - 1] == 0) // Up
                {
                    queue.Enqueue(new Tuple<int, int, int>(x, y - 1, step));
                }

                if (y + 1 < maze.GetLength(1) && maze[x, y + 1] == 0) // Down
                {
                    queue.Enqueue(new Tuple<int, int, int>(x, y + 1, step));
                }
            }
        }

        private static Tuple<int, int, int> FindStartPosition(ref int[,] maze)
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if (maze[i, j] == -1)
                    {
                        return new Tuple<int, int, int>(i, j , 0);
                    }
                }
            }

            throw new InvalidDataException("Missing start position!");
        }

        private static int[,] ReadMaze(int mazeSize)
        {
            int[,] maze = new int[mazeSize, mazeSize];

            for (int i = 0; i < mazeSize; i++)
            {
                string row = Console.ReadLine();
                int index = 0;
                foreach (char c in row.ToCharArray())
                {
                    int value = 0;

                    switch (c)
                    {
                        case '*':
                            value = -1;
                            break;
                        case 'x':
                            value = -2;
                            break;
                        case '0':
                            value = 0;
                            break;
                        default:
                            throw new InvalidDataException("Invalid symbol on map!");
                    }

                    maze[i, index++] = value;
                }
            }

            return maze;
        }

        private static void PrintMaze(ref int[,] maze)
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    string toPrint = "u";
                    switch (maze[i, j])
                    {
                        case -1:
                            toPrint = "*";
                            break;
                        case -2:
                            toPrint = "x";
                            break;
                        case 0:
                            toPrint = "u";
                            break;
                        default:
                            toPrint = maze[i, j].ToString();
                            break;
                    }
                    Console.Write(toPrint);
                }
                Console.WriteLine();
            }
        }
    }
}
