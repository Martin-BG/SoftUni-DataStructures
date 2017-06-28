namespace Classes
{
    using Interfaces;

    public class Minion : IMinion
    {
        public int CompareTo(Minion other)
        {
            var cmp = XCoordinate.CompareTo(other.XCoordinate);

            if (cmp == 0)
            {
                cmp = Id.CompareTo(other.Id);
            }

            return cmp;
        }

        public Minion(int id, int xCoordinate)
        {
            Id = id;
            XCoordinate = xCoordinate;
            Health = 100;
        }

        public override string ToString()
        {
            return $"X: {XCoordinate}, Health: {Health}";
        }

        public int Id { get; }

        public int XCoordinate { get; }

        public int Health { get; set; }
    }
}
