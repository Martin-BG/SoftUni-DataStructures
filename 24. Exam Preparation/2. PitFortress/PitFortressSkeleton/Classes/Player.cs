namespace Classes
{
    using Interfaces;

    public class Player : IPlayer
    {
        public int CompareTo(Player other)
        {
            var cmp = Score.CompareTo(other.Score);

            if (cmp == 0)
            {
                cmp = Name.CompareTo(other.Name);
            }

            return cmp;
        }

        public Player(string name, int radius)
        {
            Name = name;
            Radius = radius;
            Score = 0;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Score: {Score}, Radius: {Radius}";
        }

        public string Name { get; }

        public int Radius { get; }

        public int Score { get; set; }
    }
}
