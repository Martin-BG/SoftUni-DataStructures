using System;

namespace BunnyWars.Core
{
    class BunnyWarsTestingGround
    {
        static void Main(string[] args)
        {
            var bb = new BunnyWarsStructure();

            bb.AddRoom(1);
            bb.AddRoom(2);
            bb.AddRoom(3);

            Console.WriteLine(bb.RoomCount);
            
        }
    }
}
