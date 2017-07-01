using System.Collections.Generic;

namespace BunnyWars.Core
{
    using System;

    public class Bunny : IComparable<Bunny>
    {
        public Bunny(string name, int team, int roomId)
        {
            Name = name;
            Team = team;
            RoomId = roomId;
            Health = 100;
            Score = 0;
        }

        public int RoomId { get; set; }

        public string Name { get; private set; }

        public int Health { get; set; }

        public int Score { get; set; }

        public int Team { get; private set; }

        public int CompareTo(Bunny other)
        {
            return -string.CompareOrdinal(Name, other.Name);
        }

        public override string ToString()
        {
            return $"Name: {Name}, Team: {Team}, Room: {RoomId}, Health: {Health}, Score: {Score}";
        }
    }
}
