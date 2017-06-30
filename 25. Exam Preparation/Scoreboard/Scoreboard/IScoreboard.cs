using System.Collections.Generic;

public interface IScoreboard
{
    bool RegisterUser(string username, string password);

    bool RegisterGame(string game, string password);

    bool AddScore(string username, string userPassword, string game, string gamePassword, int score);

    IEnumerable<ScoreboardEntry> ShowScoreboard(string game);

    bool DeleteGame(string game, string gamePassword);

    IEnumerable<string> ListGamesByPrefix(string gameNamePrefix);
}