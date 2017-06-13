using System;
using System.Collections.Generic;

public class AStar
{
    private char[,] map;
	private int mapRows;
	private int mapColumns;

	private PriorityQueue<Node> queue { get; set; }
    private Dictionary<Node, Node> parent { get; set; }
    private Dictionary<Node, int> cost { get; set; }
	
    public AStar(char[,] map)
    {
		this.cost = new Dictionary<Node, int>();
        this.parent = new Dictionary<Node, Node>();
        this.queue = new PriorityQueue<Node>();
        this.map = map;
		this.mapRows = this.map.GetLength(0);
        this.mapColumns = this.map.GetLength(1);
    }

    public static int GetH(Node current, Node goal)
    {
        var deltaY = Math.Abs(current.Row - goal.Row);
        var deltaX = Math.Abs(current.Col - goal.Col);

        return deltaY + deltaX;
    }

    public IEnumerable<Node> GetPath(Node start, Node goal)
    {		
        this.queue.Enqueue(start);
        this.parent[start] = null;
        this.cost[start] = 0;

		var steps = new int[4] { 1, -1, 0, 0};
		
        while (this.queue.Count > 0)
        {
            var current = this.queue.Dequeue();

            if (current.Equals(goal))
            {
                break;
            }

			var currentRow = current.Row;
			var currentCol = current.Col;

			for (int i = 0, j = 3; i < 4; i++, j--)
			{
				var row = currentRow + steps[i];
				var col = currentCol + steps[j];
				
				if (IsValid(row, col))
				{
					var neighbour = new Node(row, col);
					
					var newCost = cost[current] + 1;

					if (!this.cost.ContainsKey(neighbour) || newCost < this.cost[neighbour])
					{
						this.cost[neighbour] = newCost;
						neighbour.F = newCost + GetH(neighbour, goal);
						this.queue.Enqueue(neighbour);
						parent[neighbour] = current;
					}
				}
			}
        }

        return GetPath(parent, start, goal);
    }

    private bool IsValid(int row, int col)
    {
        return row >= 0 && row < this.mapRows
               && col >= 0 && col < this.mapColumns
			   && this.map[row, col] != 'W';
    }

    private IEnumerable<Node> GetPath(Dictionary<Node, Node> parent, Node start, Node goal)
    {
        var path = new Stack<Node>();

        if (!this.parent.ContainsKey(goal))
        {
            path.Push(start);
            return path;
        }
 
        var current = goal;

        while (current != null)
        {
            path.Push(current);
            current = this.parent[current];
        }

        return path;
    }
}

