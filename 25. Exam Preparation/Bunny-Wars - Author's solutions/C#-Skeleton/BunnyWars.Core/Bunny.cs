namespace BunnyWars.Core
{
    using System;

    public class Bunny
    {
        public Bunny(string name, int team, int roomId)
        {
            throw new NotImplementedException();
        }

        public int RoomId { get; set; }

        public string Name { get; private set; }

        public int Health { get; set; }

        public int Score { get; set; }

        public int Team { get; private set; }
    }
}
