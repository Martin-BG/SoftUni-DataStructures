using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class Scoreboard : IScoreboard
{
    private readonly Dictionary<string, string> _usersPaswords;

    private readonly Dictionary<string, string> _gamesPaswords;

    private readonly OrderedDictionary<string, OrderedBag<ScoreboardEntry>> _games;

    private readonly int _maxEntriesToKeep;

    public Scoreboard(int maxEntriesToKeep = 10)
    {
        _maxEntriesToKeep = maxEntriesToKeep;
        _usersPaswords = new Dictionary<string, string>();
        _gamesPaswords = new Dictionary<string, string>();
        _games = new OrderedDictionary<string, 
            OrderedBag<ScoreboardEntry>>(string.CompareOrdinal);
    }

    public bool RegisterUser(string username, string password)
    {
        if (_usersPaswords.ContainsKey(username))
        {
            return false;
        }

        _usersPaswords.Add(username, password);

        return true;
    }

    public bool RegisterGame(string game, string password)
    {
        if (_gamesPaswords.ContainsKey(game))
        {
            return false;
        }

        _gamesPaswords.Add(game, password);

        _games.Add(game, new OrderedBag<ScoreboardEntry>());

        return true;
    }

    public bool AddScore(string username, string userPassword,
        string game, string gamePassword, int score)
    {
        if (!_usersPaswords.ContainsKey(username)
            || !_usersPaswords[username].Equals(userPassword)
            || !_gamesPaswords.ContainsKey(game)
            || !_gamesPaswords[game].Equals(gamePassword))
        {
            return false;
        }

        _games[game].Add(new ScoreboardEntry(username, score));

        while (_games[game].Count > _maxEntriesToKeep)
        {
            _games[game].RemoveLast();
        }

        return true;
    }

    public IEnumerable<ScoreboardEntry> ShowScoreboard(string game)
    {
        if (!_gamesPaswords.ContainsKey(game))
        {
            return null;
        }

        return _games[game].Take(_maxEntriesToKeep);
    }

    public bool DeleteGame(string game, string gamePassword)
    {
        if (!_gamesPaswords.ContainsKey(game)
            || !_gamesPaswords[game].Equals(gamePassword))
        {
            return false;
        }

        _gamesPaswords.Remove(game);
        _games.Remove(game);

        return true;
    }

    public IEnumerable<string> ListGamesByPrefix(string gameNamePrefix)
    {
        var upperBound = gameNamePrefix + char.MaxValue;
        var gamesWithPrefix = _games.Range(gameNamePrefix, true, upperBound, false);

        return gamesWithPrefix.Take(_maxEntriesToKeep).Select(e => e.Key);
    }
}