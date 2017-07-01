namespace BunnyWars.Core
{
    using System;
    using System.Collections.Generic;

    public class BunnyWarsStructure : IBunnyWarsStructure
    {
        public int BunnyCount { get { throw new NotImplementedException(); } }

        public int RoomCount { get { throw new NotImplementedException(); } }

        public void AddRoom(int roomId)
        {
            throw new NotImplementedException();
        }

        public void AddBunny(string name, int team, int roomId)
        {
            throw new NotImplementedException();
        }

        public void Remove(int roomId)
        {
            throw new NotImplementedException();
        }

        public void Next(string bunnyName)
        {
            throw new NotImplementedException();
        }

        public void Previous(string bunnyName)
        {
            throw new NotImplementedException();
        }

        public void Detonate(string bunnyName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bunny> ListBunniesByTeam(int team)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bunny> ListBunniesBySuffix(string suffix)
        {
            throw new NotImplementedException();
        }
    }
}
