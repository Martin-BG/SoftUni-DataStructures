using System;
using System.Collections.Generic;
using System.Linq;

public class Tree<T>
{
    public T Value { get; set; }
    public Tree<T> Parent { get; set; }
    public List<Tree<T>> Children { get; private set; }

    public Tree(T value, params Tree<T>[] children)
    {
        this.Value = value;
        this.Children = new List<Tree<T>>();

        foreach (var child in children)
        {
            this.Children.Add(child);
            child.Parent = this;
        }
    }

    public void Print(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent) + this.Value);

        foreach (var child in this.Children)
        {
            child.Print(indent + 2);
        }
    }
}

public class Program
{
    static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();

    static void Main(string[] args)
    {
        ReadTree();
        //PrintRootNodeValue();
        //GetRootNode().Print();
        //PrintLeafNodes();
        //PrintMiddleNodes();
        //PrintDeepestNode();
        //PrintLongestPath();
        //PrintPathsOfSum();
        PrintSubtreesOfSum();
    }

    private static void PrintSubtreesOfSum()
    {
        foreach (var root in GetSubtreeWithSum(GetRootNode()))
        {
            PrintPreOrder(root);
            Console.WriteLine();
        }
    }

    private static void PrintPreOrder(Tree<int> root)
    {
        Console.Write(root.Value + " ");
        foreach (var child in root.Children)
        {
            PrintPreOrder(child);
        }
    }

    private static List<Tree<int>> GetSubtreeWithSum(Tree<int> root)
    {
        int sum = int.Parse(Console.ReadLine());

        Console.WriteLine($"Subtrees of sum {sum}:");

        var roots = new List<Tree<int>>();

        DFS(root, sum, 0, roots);

        return roots;
    }

    private static int DFS(Tree<int> node, int target, int current, List<Tree<int>> roots)
    {
        if (node == null)
        {
            return 0;
        }

        current = node.Value;

        foreach (var child in node.Children)
        {
            current += DFS(child, target, current, roots);
        }

        if (current == target)
        {
            roots.Add(node);
        }
        return current;
    }

    private static void PrintPathsOfSum()
    {
        int sum = int.Parse(Console.ReadLine());

        Console.WriteLine($"Paths of sum {sum}:");

        List<List<Tree<int>>> paths = GetPathsToAllNodes();

        Stack<List<int>> pathsOfRightSum = new Stack<List<int>>();
        foreach (var path in paths)
        {
            List<int> route = new List<int>();
            int pathSum = 0;
            foreach (var node in path)
            {
                route.Add(node.Value);
                pathSum += node.Value;
            }

            if (pathSum == sum)
            {
                pathsOfRightSum.Push(route);
            }
        }

        while (pathsOfRightSum.Count > 0)
        {
            List<int> route = pathsOfRightSum.Pop();
            Console.WriteLine(string.Join(" ", route));
        }
    }

    private static List<List<Tree<int>>> GetPathsToAllNodes()
    {
        List<List<Tree<int>>> paths = new List<List<Tree<int>>>();
        Stack<List<Tree<int>>> pathsStack = new Stack<List<Tree<int>>>();

        pathsStack.Push(new List<Tree<int>> { GetRootNode() });

        while (pathsStack.Count > 0)
        {
            List<Tree<int>> currentList = pathsStack.Pop();

            if (currentList.Last().Children.Count == 0)
            {
                paths.Add(currentList);
            }
            else
            {
                foreach (var child in currentList.Last().Children)
                {
                    pathsStack.Push(new List<Tree<int>>(currentList) { child });
                }
            }
        }

        return paths;
    }


    private static void PrintLongestPath()
    {
        Stack<int> path = new Stack<int>();
        Tree<int> currentNode = GetDeepestNode();

        while (currentNode != null)
        {
            path.Push(currentNode.Value);
            currentNode = currentNode.Parent;
        }

        Console.WriteLine("Longest path: " + string.Join(" ", path.ToArray()));
    }

    private static Tree<int> GetDeepestNode()
    {
        Stack<Tree<int>> stack = new Stack<Tree<int>>();
        stack.Push(GetRootNode());

        Tree<int> deepestNode = null;

        while (stack.Count > 0)
        {
            bool leftChildTaken = false;
            Tree<int> current = stack.Pop();

            if (current != null && current.Children.Count > 0)
            {
                deepestNode = current.Children.ElementAt(0);

                foreach (var child in current.Children)
                {
                    stack.Push(child);
                }
            }
        }

        return deepestNode;
    }

    private static void PrintDeepestNode()
    {
        Tree<int> deepestNode = GetDeepestNode();

        if (deepestNode != null)
        {
            Console.WriteLine("Deepest node: " + deepestNode.Value);
        }
    }

    private static void PrintMiddleNodes()
    {
        var nodes = GetMiddleNodes()
            .Select(x => x.Value)
            .OrderBy(x => x)
            .ToArray();

        Console.WriteLine("Middle nodes: " + string.Join(" ", nodes));
    }

    private static Tree<int>[] GetMiddleNodes()
    {
        return nodeByValue.Values
            .Where(x => x.Parent != null && x.Children.Count != 0)
            .ToArray();
    }

    private static void PrintLeafNodes()
    {
        var leaves = GetLeafNodes().Select(x => x.Value).ToArray();
        Array.Sort(leaves);
        Console.WriteLine("Leaf nodes: " + string.Join(" ", leaves));
    }

    private static Tree<int>[] GetLeafNodes()
    {
        return nodeByValue.Values
            .Where(x => x.Children.Count == 0)
            .ToArray();
    }

    private static void PrintRootNodeValue()
    {
        Console.WriteLine("Root node: " + GetRootNode().Value);
    }

    static Tree<int> GetRootNode()
    {
        return nodeByValue.Values.FirstOrDefault(x => x.Parent == null);
    }

    static void ReadTree()
    {
        int nodes = int.Parse(Console.ReadLine());

        for (int i = 0; i < nodes - 1; i++)
        {
            var edge = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            AddEdge(edge[0], edge[1]);
        }
    }

    public static void AddEdge(int parent, int child)
    {
        Tree<int> parentNode = GetTreeNodeByValue(parent);
        Tree<int> childNode = GetTreeNodeByValue(child);

        parentNode.Children.Add(childNode);
        childNode.Parent = parentNode;
    }

    static Tree<int> GetTreeNodeByValue(int value)
    {
        if (!nodeByValue.ContainsKey(value))
        {
            nodeByValue[value] = new Tree<int>(value);
        }

        return nodeByValue[value];
    }
}

