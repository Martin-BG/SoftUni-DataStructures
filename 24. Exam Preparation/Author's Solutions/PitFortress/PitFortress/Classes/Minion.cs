using System;

namespace PitFortress.Classes
{
    using PitFortress.Interfaces;

    public class Minion : IMinion
    {
        public const int MinionDefaultHealth = 100;

        public Minion(int id, int xCoordinate)
        {
            this.Id = id;
            this.XCoordinate = xCoordinate;
            this.Health = MinionDefaultHealth;
        }

        public int Id { get; set; }

        public int XCoordinate { get; set; }

        public int Health { get; set; }

        public int CompareTo(Minion other)
        {
            return this.Id.CompareTo(other.Id);
        }
    }
}
