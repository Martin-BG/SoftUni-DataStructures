namespace BunnyWars.Core
{
    using System.Collections.Generic;

    public interface IBunnyWarsStructure
    {
        void AddRoom(int roomId);

        void AddBunny(string name, int team, int roomId);

        int BunnyCount { get; }

        int RoomCount { get; }

        void Remove(int roomId);

        void Next(string bunnyName);

        void Previous(string bunnyName);

        void Detonate(string bunnyName);

        IEnumerable<Bunny> ListBunniesByTeam(int team);

        IEnumerable<Bunny> ListBunniesBySuffix(string suffix);
    }
}
