using System;
using System.Collections.Generic;

class SweepAndPrune
{
    static void Main(string[] args)
    {
        var gameObjects = new List<GameObject>();
        var gameObjectsById = new Dictionary<string, GameObject>();

        var input = Console.ReadLine();

        while (!"start".Equals(input))
        {
            var tokens = input.Split();

            var name = tokens[1];
            var x1 = int.Parse(tokens[2]);
            var y1 = int.Parse(tokens[3]);

            var gameObject = new GameObject(name, x1, y1);

            gameObjects.Add(gameObject);

            gameObjectsById[name] = gameObject;

            input = Console.ReadLine();
        }

        var ticks = 0;
        var recalculateCollisions = true;
        var collisionsList = new List<string>();

        input = Console.ReadLine();
        while (!"end".Equals(input))
        {
            ticks++;

            if (!"tick".Equals(input))
            {
                var tokens = input.Split();

                var name = tokens[1];
                var x1 = int.Parse(tokens[2]);
                var y1 = int.Parse(tokens[3]);

                gameObjectsById[name].X1 = x1;
                gameObjectsById[name].Y1 = y1;

                recalculateCollisions = true;
            }

            if (recalculateCollisions)
            {
                collisionsList = RecalculateCollisions(gameObjects);
                recalculateCollisions = false;
            }

            PrintCollisions(ticks, collisionsList);

            input = Console.ReadLine();
        }
    }

    private static void PrintCollisions(int ticks, IEnumerable<string> collisionsList)
    {
        foreach (var collision in collisionsList)
        {
            Console.WriteLine($"({ticks}) {collision}");
        }
    }

    private static List<string> RecalculateCollisions(IList<GameObject> gameObjects)
    {
        var collisionsList = new List<string>();

        InsertionSort(gameObjects);

        for (var i = 0; i < gameObjects.Count; i++)
        {
            var current = gameObjects[i];

            for (var j = i + 1; j < gameObjects.Count; j++)
            {
                var other = gameObjects[j];

                if (current.X2 < other.X1)
                {
                    break;
                }

                if (current.Intersects(other))
                {
                    collisionsList.Add($"{current.Name} collides with {other.Name}");
                }
            }
        }

        return collisionsList;
    }

    private static void InsertionSort(IList<GameObject> gameObjects)
    {
        for (var i = 0; i < gameObjects.Count; i++)
        {
            var j = i;

            while (j > 0 && gameObjects[j - 1].X1 > gameObjects[j].X1)
            {
                var temp = gameObjects[j - 1];
                gameObjects[j - 1] = gameObjects[j];
                gameObjects[j] = temp;

                j--;
            }
        }
    }
}
