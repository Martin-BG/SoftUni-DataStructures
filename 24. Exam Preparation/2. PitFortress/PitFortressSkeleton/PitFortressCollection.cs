using System;
using System.Collections.Generic;
using System.Linq;
using Classes;
using Interfaces;
using Wintellect.PowerCollections;

public class PitFortressCollection : IPitFortress
{
    private int _minionId = 1;
    private int _mineId = 1;

    private Dictionary<string, Player> players;
    private SortedSet<Player> playerScores;
    private OrderedDictionary<int, SortedSet<Minion>> minions;
    private SortedSet<Mine> mines;

    public PitFortressCollection()
    {
        players = new Dictionary<string, Player>();
        playerScores = new SortedSet<Player>();
        minions = new OrderedDictionary<int, SortedSet<Minion>>();
        mines = new SortedSet<Mine>();
    }

    public int PlayersCount => players.Count;

    public int MinionsCount => minions.Sum(x => x.Value.Count);

    public int MinesCount => mines.Count;

    public void AddPlayer(string name, int mineRadius)
    {
        if (players.ContainsKey(name) || mineRadius < 0)
        {
            throw new ArgumentException();
        }

        var player = new Player(name, mineRadius);
        players.Add(name, player);
        playerScores.Add(player);
    }

    public void AddMinion(int xCoordinate)
    {
        if (xCoordinate < 0 || xCoordinate > 1_000_000)
        {
            throw new ArgumentException();
        }

        var minion = new Minion(_minionId++, xCoordinate);

        if (!minions.ContainsKey(xCoordinate))
        {
            minions.Add(xCoordinate, new SortedSet<Minion>());
        }

        minions[xCoordinate].Add(minion);
    }

    public void SetMine(string playerName, int xCoordinate, int delay, int damage)
    {

        if (!players.ContainsKey(playerName)
            || xCoordinate < 0 || xCoordinate > 1_000_000
            || damage < 0 || damage > 100)
        {
            throw new ArgumentException();
        }

        var player = players[playerName];
        var mine = new Mine(_mineId++, delay, damage, xCoordinate, player);
        mines.Add(mine);
    }

    public IEnumerable<Minion> ReportMinions()
    {
        foreach (var set in minions.Values)
        {
            foreach (var minion in set)
            {
                yield return minion;
            }
        }
    }

    public IEnumerable<Player> Top3PlayersByScore()
    {
        if (players.Count < 3)
        {
            throw new ArgumentException();
        }

        return playerScores.Reverse().Take(3);
    }

    public IEnumerable<Player> Min3PlayersByScore()
    {
        if (players.Count < 3)
        {
            throw new ArgumentException();
        }

        return playerScores.Take(3);
    }

    public IEnumerable<Mine> GetMines()
    {
        return mines;
    }

    public void PlayTurn()
    {
        var minesToDetonate = GetMinesToDetonate();

        foreach (var mine in minesToDetonate)
        {
            var player = mine.Player;
            var damage = mine.Damage;

            var minionsToDamage = GetMinionsToDamage(mine);

            foreach (var minion in minionsToDamage)
            {
                minion.Health -= damage;

                if (minion.Health <= 0)
                {
                    UpdatePlayer(player);

                    minions[minion.XCoordinate].Remove(minion);
                }
            }

            mines.Remove(mine);
        }
    }

    private List<Minion> GetMinionsToDamage(Mine mine)
    {
        var start = mine.XCoordinate - mine.Player.Radius;
        var end = mine.XCoordinate + mine.Player.Radius;
        return minions.Range(start, true, end, true).SelectMany(x => x.Value).ToList();
    }

    private List<Mine> GetMinesToDetonate()
    {
        var minesToDetonate = new List<Mine>();

        foreach (var mine in mines)
        {
            mine.Delay--;

            if (mine.Delay <= 0)
            {
                minesToDetonate.Add(mine);
            }
        }

        return minesToDetonate;
    }

    private void UpdatePlayer(Player player)
    {
        playerScores.Remove(player);
        player.Score++;
        playerScores.Add(player);
    }
}
