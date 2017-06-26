using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var starSystemsList = new List<StarSystem>();

        var starClustersCount = int.Parse(Console.ReadLine());
        var reportsCount = int.Parse(Console.ReadLine());
        var galaxySize = int.Parse(Console.ReadLine());

        while (starClustersCount-- > 0)
        {
            var tokens = Console.ReadLine().Split();

            var name = tokens[0];
            var x = int.Parse(tokens[1]);
            var y = int.Parse(tokens[2]);

            starSystemsList.Add(new StarSystem(x, y, name));
        }

        starSystemsList.Sort();

        //var galaxyKdTree = new KdTree();
        //foreach (var starSystem in starSystemsList)
        //{
        //    galaxyKdTree.Insert(starSystem);
        //}

        while (reportsCount-- > 0)
        {
            var reportParameters = Console.ReadLine().Split();

            var x1 = int.Parse(reportParameters[1]);
            var y1 = int.Parse(reportParameters[2]);
            var x2 = x1 + int.Parse(reportParameters[3]);
            var y2 = y1 + int.Parse(reportParameters[4]);

            PrintGalaxiesInRange(x1, y1, x2, y2, starSystemsList);
        }
    }

    private static void PrintGalaxiesInRange(
        int x1, int y1, int x2, int y2,
        List<StarSystem> starSystemsList)
    {
        var galaxiesInRange = 0;

        foreach (var starSystem in starSystemsList)
        {
            if (x1 > starSystem.X
                || y1 > starSystem.Y || y2 < starSystem.Y)
            {
                continue;
            }

            if (x2 < starSystem.X)
            {
                break;
            }

            if (starSystem.IsInto(x1, y1, x2, y2))
            {
                galaxiesInRange++;
            }
        }

        Console.WriteLine(galaxiesInRange);
    }
}