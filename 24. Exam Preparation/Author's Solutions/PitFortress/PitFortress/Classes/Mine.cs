namespace PitFortress.Classes
{
    using System;

    using PitFortress.Interfaces;

    public class Mine : IMine
    {
        public Mine(int id,int xCoordinate, int delay, int damage, Player player)
        {
            this.Id = id;
            this.XCoordinate = xCoordinate;
            this.Delay = delay;
            this.Damage = damage;
            this.Player = player;
        }

        public int Id { get; set; }

        public int Delay { get; set; }

        public int Damage { get; set; }

        public int XCoordinate { get; set; }

        public Player Player { get; set; }

        public int CompareTo(Mine other)
        {
            int result = this.Delay.CompareTo(other.Delay);
            if (result == 0)
            {
                result = this.Id.CompareTo(other.Id);
            }
            return result;
        }
    }
}
