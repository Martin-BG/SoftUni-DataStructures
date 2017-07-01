using Wintellect.PowerCollections;

namespace BunnyWars.Core
{
    using System;
    using System.Collections.Generic;

    public class BunnyWarsStructure : IBunnyWarsStructure
    {
        private const int MaxTeams = 5;
        private readonly OrderedDictionary<int, LinkedList<Bunny>[]> _rooms;
        private readonly List<SortedSet<Bunny>> _byTeams;
        private readonly Dictionary<string, Bunny> _byName;
        private readonly OrderedSet<Bunny> _bySuffix;
        private readonly OrderedSet<int> _roomsById;

        public BunnyWarsStructure()
        {
            _rooms = new OrderedDictionary<int, LinkedList<Bunny>[]>();
            _byName = new Dictionary<string, Bunny>();
            _bySuffix = new OrderedSet<Bunny>(Compare);
            _roomsById = new OrderedSet<int>();
            _byTeams = new List<SortedSet<Bunny>>();

            for (var teamIndex = 0; teamIndex < MaxTeams; teamIndex++)
            {
                _byTeams.Add(new SortedSet<Bunny>());
            }
        }

        public int Compare(Bunny bunnyX, Bunny bunnyY)
        {
            var x = bunnyX.Name;
            var y = bunnyY.Name;
            for (int iX = x.Length - 1, iY = y.Length - 1;
                iX >= 0 && iY >= 0; iX--, iY--)
            {
                if (x[iX] > y[iY]) return 1;
                if (x[iX] < y[iY]) return -1;
            }

            if (x.Length == y.Length) return 0;
            if (x.Length > y.Length) return 1;

            return -1;
        }

        public int BunnyCount => _byName.Count;

        public int RoomCount => _rooms.Count;

        public void AddRoom(int roomId)
        {
            if (_rooms.ContainsKey(roomId))
            {
                throw new ArgumentException();
            }
            _roomsById.Add(roomId);
            _rooms.Add(roomId, new LinkedList<Bunny>[MaxTeams]);
        }

        public void AddBunny(string name, int team, int roomId)
        {
            ValidateBunnyByName(name);

            ValidateTeamId(team);

            ValidateRoomId(roomId);

            var bunny = new Bunny(name, team, roomId);

            _byName.Add(name, bunny);
            if (_rooms[roomId][team] == null)
            {
                _rooms[roomId][team] = new LinkedList<Bunny>();
            }
            _rooms[roomId][team].AddLast(bunny);
            _bySuffix.Add(bunny);
            _byTeams[team].Add(bunny);
        }

        public void Remove(int roomId)
        {
            ValidateRoomId(roomId);

            foreach (var bunnies in _rooms[roomId])
            {
                if (bunnies == null)
                {
                    continue;
                }

                foreach (var bunny in bunnies)
                {
                    _byName.Remove(bunny.Name);
                    _bySuffix.Remove(bunny);
                    _byTeams[bunny.Team].Remove(bunny);
                }
            }

            _rooms.Remove(roomId);
            _roomsById.Remove(roomId);
        }

        public void Next(string bunnyName)
        {
            if (!_byName.ContainsKey(bunnyName))
            {
                throw new ArgumentException();
            }

            var bunny = _byName[bunnyName];

            MoveToRoom(bunny, 1);
        }

        private void MoveToRoom(Bunny bunny, int step)
        {
            if (_rooms.Count == 1)
            {
                return;
            }

            var bunnyRoomId = bunny.RoomId;
            var nextRoomIndex = _roomsById.IndexOf(bunnyRoomId) + step;

            if (nextRoomIndex >= _rooms.Count)
            {
                nextRoomIndex = 0;
            }
            else if (nextRoomIndex < 0)
            {
                nextRoomIndex = _rooms.Count - 1;
            }

            var teamId = bunny.Team;

            _rooms[bunnyRoomId][teamId].Remove(bunny);

            var newRoomId = _roomsById[nextRoomIndex];

            if (_rooms[newRoomId][teamId] == null)
            {
                _rooms[newRoomId][teamId] = new LinkedList<Bunny>();
            }

            _rooms[newRoomId][teamId].AddLast(bunny);

            bunny.RoomId = newRoomId;
        }

        public void Previous(string bunnyName)
        {
            if (!_byName.ContainsKey(bunnyName))
            {
                throw new ArgumentException();
            }

            var bunny = _byName[bunnyName];

            MoveToRoom(bunny, -1);
        }

        public void Detonate(string bunnyName)
        {
            if (!_byName.ContainsKey(bunnyName))
            {
                throw new ArgumentException();
            }
            var bunny = _byName[bunnyName];

            var teamsInRoom = _rooms[bunny.RoomId];
            var kills = 0;
            for (var i = 0; i < teamsInRoom.Length; i++)
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

                        _byName.Remove(currentBunny.Name);
                        _bySuffix.Remove(currentBunny);
                        _byTeams[currentBunny.Team].Remove(currentBunny);

                        team.Remove(current); // O(1) removal
                    }

                    current = current.Next;
                }
            }

            bunny.Score += kills;
        }

        public IEnumerable<Bunny> ListBunniesByTeam(int team)
        {
            ValidateTeamId(team);

            return _byTeams[team];
        }

        public IEnumerable<Bunny> ListBunniesBySuffix(string suffix)
        {
            var low = new Bunny(suffix, 0, 0);
            var high = new Bunny(char.MaxValue + suffix, 0, 0);

            return _bySuffix.Range(low, true, high, false);
        }

        private static void ValidateTeamId(int team)
        {
            if (team >= MaxTeams || team < 0)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void ValidateBunnyByName(string name)
        {
            if (_byName.ContainsKey(name))
            {
                throw new ArgumentException();
            }
        }

        private void ValidateRoomId(int roomId)
        {
            if (!_rooms.ContainsKey(roomId))
            {
                throw new ArgumentException();
            }
        }
    }
}
