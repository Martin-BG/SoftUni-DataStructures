namespace BunnyWars.Core
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class BunnyWarsStructure : IBunnyWarsStructure
    {
        private const int TeamCount = 5;

        private static IComparer<Bunny> SuffixComparator = new OrdinalSuffixComparator();

        private Dictionary<string, Bunny> bunniesByName =
            new Dictionary<string, Bunny>();

        private OrderedDictionary<int, LinkedList<Bunny>[]> bunniesInTeamsByRoom = 
            new OrderedDictionary<int, LinkedList<Bunny>[]>();

        private OrderedSet<Bunny> bunniesOrderedBySuffix = 
            new OrderedSet<Bunny>(SuffixComparator);

        private OrderedSet<int> roomsById = 
            new OrderedSet<int>();

        private OrderedSet<Bunny>[] bunniesByTeam = 
            new OrderedSet<Bunny>[TeamCount];

        public int BunnyCount
        {
            get { return this.bunniesByName.Count; }
        }

        public int RoomCount
        {
            get { return this.roomsById.Count; }
        }

        public void AddRoom(int roomId)
        {
            if (this.bunniesInTeamsByRoom.ContainsKey(roomId))
            {
                throw new ArgumentException("Room already exists");
            }

            this.roomsById.Add(roomId);
            this.bunniesInTeamsByRoom[roomId] = new LinkedList<Bunny>[TeamCount];
        }

        public void AddBunny(string bunnyName, int teamId, int roomId)
        {
            if (this.bunniesByName.ContainsKey(bunnyName))
            {
                throw new ArgumentException("Bunny already exists");
            }

            if (!this.roomsById.Contains(roomId))
            {
                throw new ArgumentException("Room does not exist");
            }

            var bunny = new Bunny(bunnyName, teamId, roomId);
            this.bunniesByName[bunnyName] = bunny;

            // Add to team
            if (this.bunniesByTeam[teamId] == null)
            {
                this.bunniesByTeam[teamId] = new OrderedSet<Bunny>(
                    (b1, b2) => string.Compare(b1.Name, b2.Name));
            }
            this.bunniesByTeam[teamId].Add(bunny);

            // Add to room
            if (this.bunniesInTeamsByRoom[roomId][teamId] == null)
            {
                this.bunniesInTeamsByRoom[roomId][teamId] = new LinkedList<Bunny>();
            }
            this.bunniesInTeamsByRoom[roomId][teamId].AddLast(bunny);

            // Add to suffix set
            this.bunniesOrderedBySuffix.Add(bunny);
        }

        public void Remove(int roomId)
        {
            LinkedList<Bunny>[] teamsInRoom;
            if (! this.bunniesInTeamsByRoom.TryGetValue(roomId, out teamsInRoom))
            {
                throw new ArgumentException("Room does not exist");
            }

            foreach (var team in teamsInRoom)
            {
                if (team == null) continue;
                foreach (var bunny in team)
                {
                    this.RemoveBunny(bunny);
                }
            }

            this.roomsById.Remove(roomId);
            this.bunniesInTeamsByRoom.Remove(roomId);
        }

        public void Next(string bunnyName)
        {
            if (!this.bunniesByName.ContainsKey(bunnyName))
            {
                throw new ArgumentException("Bunny does not exist");
            }

            var bunny = this.bunniesByName[bunnyName];
            var roomIndex = roomsById.IndexOf(bunny.RoomId);
            this.MoveBunnyToRoom(bunny, roomIndex, roomIndex + 1);
        }

        public void Previous(string bunnyName)
        {
            if (!this.bunniesByName.ContainsKey(bunnyName))
            {
                throw new ArgumentException("Bunny does not exist");
            }

            var bunny = this.bunniesByName[bunnyName];
            var roomIndex = roomsById.IndexOf(bunny.RoomId);
            this.MoveBunnyToRoom(bunny, roomIndex, roomIndex - 1);
        }

        private void MoveBunnyToRoom(Bunny bunny, int currentRoomIndex, int newRoomIndex)
        {
            if (newRoomIndex == this.bunniesInTeamsByRoom.Count)
                newRoomIndex = 0;
            else if (newRoomIndex == -1)
                newRoomIndex = this.bunniesInTeamsByRoom.Count - 1;

            // Remove from current room
            var oldRoom = this.roomsById[currentRoomIndex];
            this.bunniesInTeamsByRoom[oldRoom][bunny.Team].Remove(bunny);

            // Add to new room
            var newRoom = this.roomsById[newRoomIndex];
            if (this.bunniesInTeamsByRoom[newRoom][bunny.Team] == null)
            {
                this.bunniesInTeamsByRoom[newRoom][bunny.Team] = new LinkedList<Bunny>();
            }

            this.bunniesInTeamsByRoom[newRoom][bunny.Team].AddLast(bunny);
            bunny.RoomId = newRoom;
        }

        public void Detonate(string bunnyName)
        {
            Bunny bunny;
            if (! this.bunniesByName.TryGetValue(bunnyName, out bunny))
            {
                throw new ArgumentException("Bunny does not exist");
            }

            var teamsInRoom = this.bunniesInTeamsByRoom[bunny.RoomId];
            var kills = 0;
            for (int i = 0; i < teamsInRoom.Length; i++)
            {
                var team = teamsInRoom[i];
                if (i == bunny.Team || team == null)
                    continue;

                var current = team.First;
                while (current != null)
                {
                    var currentBunny = current.Value;
                    currentBunny.Health -= 30;
                    if (currentBunny.Health <= 0)
                    {
                        kills++;
                        RemoveBunny(currentBunny); 
                        team.Remove(current); // O(1) removal
                    }

                    current = current.Next;
                }
            }

            bunny.Score += kills;
        }

        private void RemoveBunny(Bunny bunny)
        {
            this.bunniesByName.Remove(bunny.Name);
            this.bunniesOrderedBySuffix.Remove(bunny);
            this.bunniesByTeam[bunny.Team].Remove(bunny);
        }

        public IEnumerable<Bunny> ListBunniesByTeam(int team)
        {
            return this.bunniesByTeam[team].Reversed();
        }

        public IEnumerable<Bunny> ListBunniesBySuffix(string suffix)
        {
            var low = new Bunny(suffix, 0, 0);
            var high = new Bunny(char.MaxValue + suffix, 0, 0);

            return this.bunniesOrderedBySuffix.Range(low, true, high, false);
        }
    }
}