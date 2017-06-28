namespace Classes
{
    using Interfaces;

    public class Mine : IMine
    {
        public int CompareTo(Mine other)
        {
            var cmp = Delay.CompareTo(other.Delay);

            if (cmp == 0)
            {
                cmp = Id.CompareTo(other.Id);
            }

            return cmp;
        }

        public Mine(int id, int delay, int damage, int xCoordinate, Player player)
        {
            Id = id;
            Delay = delay;
            Damage = damage;
            XCoordinate = xCoordinate;
            Player = player;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Player: {Player.Name}, Delay: {Delay}, X: {XCoordinate}, Damage: {Damage}";
        }

        public int Id { get; }

        public int Delay { get; set; }

        public int Damage { get; }

        public int XCoordinate { get; }

        public Player Player { get; }
    }
}
