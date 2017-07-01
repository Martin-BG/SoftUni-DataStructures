using System;

namespace PitFortress.Classes
{
    using PitFortress.Interfaces;

    public class Player : IPlayer
    {
        public Player(string name, int radius)
        {
            this.Name = name;
            this.Radius = radius;
            this.Score = 0;
        }

        public string Name { get; set; }

        public int Radius { get; set; }

        public int Score { get; set; }

        public int CompareTo(Player other)
        {
            int result = this.Score.CompareTo(other.Score);
            if (result == 0)
            {
                result = string.CompareOrdinal(this.Name, other.Name);
            }
            return result;
        }
    }
}
