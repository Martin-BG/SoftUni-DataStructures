using System.Collections.Generic;

public class Node<T>
{
    public const int MaxItemCount = 4;

    public Node(int x, int y, int width, int height)
    {
        Bounds = new Rectangle(x, y, width, height);
        Items = new List<T>();
    }

    public Rectangle Bounds { get; set; }

    public List<T> Items { get; set; }

    public Node<T>[] Children { get; set; }

    public bool ShouldSplit => Items.Count >= MaxItemCount && Children == null;

    public override string ToString()
    {
        return Bounds.ToString();
    }
}
