class GameObject
{
    private const int Width = 10;

    private const int Height = 10;

    public string Name { get; }

    public int X1 { get; set; }

    public int Y1 { get; set; }

    public int X2 => X1 + Width;

    public int Y2 => Y1 + Height;

    public GameObject(string name, int x1, int y1)
    {
        Name = name;
        X1 = x1;
        Y1 = y1;
    }

    public bool Intersects(GameObject other)
    {
        return X1 <= other.X2 
            && X2 >= other.X1 
            && Y1 <= other.Y2 
            && Y2 >= other.Y1;
    }
}
