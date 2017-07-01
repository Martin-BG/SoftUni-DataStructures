namespace PitFortress
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PitFortress.Classes;
    using PitFortress.Interfaces;

    using Wintellect.PowerCollections;

    public class PitFortressCollection
    {
        private int minionCounter;
        private int mineCounter;
        private Dictionary<string, Player> playersByName;
        private SortedSet<Player> playersByScore;
        private OrderedMultiDictionary<int,Minion> minionsByCoordinates;
        private SortedSet<Mine> minesByDelay;

        public PitFortressCollection()
        {
            this.minionCounter = 1;
            this.mineCounter = 1;
            this.playersByName = new Dictionary<string, Player>();
            this.playersByScore = new SortedSet<Player>();
            this.minionsByCoordinates = new OrderedMultiDictionary<int,Minion>(false);
            this.minesByDelay = new SortedSet<Mine>();
        }

        public int PlayersCount
        {
            get { return this.playersByName.Count; }
        }

        public int MinionsCount
        {
            get { return this.minionsByCoordinates.Values.Count; }
        }

        public int MinesCount
        {
            get { return this.minesByDelay.Count; }
        }

        public void AddPlayer(string name, int mineRadius)
        {
            if (this.playersByName.ContainsKey(name))
            {
                throw new ArgumentException("Player already exists!");
            }

            if (mineRadius < 0)
            {
                throw new ArgumentException("Radius cannot be negative!");
            }

            var player = new Player(name, mineRadius);
            this.playersByScore.Add(player);
            this.playersByName.Add(name, player);
        }

        public void AddMinion(int xCoordinate)
        {
            if (xCoordinate < 0 || xCoordinate > 1000000)
            {
                throw new ArgumentException("Invalid coordinate");
            }

            var minion = new Minion(this.minionCounter++,xCoordinate);
            this.minionsByCoordinates.Add(xCoordinate,minion);
        }

        public void SetMine(string playerName, int xCoordinate, int delay, int damage)
        {
            if (!this.playersByName.ContainsKey(playerName))
            {
                throw new ArgumentException("No such player.");
            }

            if (xCoordinate < 0 || xCoordinate > 1000000)
            {
                throw new ArgumentException("Invalid coordinate");
            }

            if (delay < 1 || delay > 10000)
            {
                throw new ArgumentException("Incorrect delay!");
            }

            if (damage < 0 || damage > 100)
            {
                throw new ArgumentException("Incorrect damage!");
            }

            var player = this.playersByName[playerName];
            var mine = new Mine(this.mineCounter++,xCoordinate, delay, damage,player);
            this.minesByDelay.Add(mine);
        }

        public IEnumerable<Minion> ReportMinions()
        {
            return this.minionsByCoordinates.Values;
        }

        public IEnumerable<Player> Top3PlayersByScore()
        {
            if (this.playersByName.Count < 3)
            {
                throw new ArgumentException("Not enough players!");
            }
            return this.playersByScore.Reverse().Take(3);
        }

        public IEnumerable<Player> Min3PlayersByScore()
        {
            if (this.playersByName.Count < 3)
            {
                throw new ArgumentException("Not enough players!");
            }
            return this.playersByScore.Take(3);
        }

        public IEnumerable<Mine> GetMines()
        {
            return this.minesByDelay;
        }

        public void PlayTurn()
        {
            foreach (var mine in this.minesByDelay)
            {
                mine.Delay--;
            }

            var shortestFuseMine = this.minesByDelay.Min;
            while (shortestFuseMine != null && shortestFuseMine.Delay == 0)
            {
                this.Explode(shortestFuseMine);
                this.minesByDelay.Remove(shortestFuseMine);
                shortestFuseMine = this.minesByDelay.Min;
            }
        }

        private void Explode(Mine mine)
        {
            var damagedMinions = this.minionsByCoordinates.Range(mine.XCoordinate - mine.Player.Radius, true, mine.XCoordinate + mine.Player.Radius, true).Values.ToList();

            foreach (var damagedMinion in damagedMinions)
            {
                damagedMinion.Health -= mine.Damage;
                if (damagedMinion.Health <= 0)
                {
                    this.minionsByCoordinates.Remove(damagedMinion.XCoordinate, damagedMinion);
                    var player = mine.Player;
                    this.playersByScore.Remove(player);
                    player.Score++;
                    this.playersByScore.Add(player);
                }
            }
        }
    }
}
