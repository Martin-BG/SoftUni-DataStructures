using System;

public class ScoreboardEntry : IComparable<ScoreboardEntry>
{
    public int Score { get; set; }

    public string Username { get; set; }

    public ScoreboardEntry(string username, int score)
    {
        Username = username;
        Score = score;
    }

    public int CompareTo(ScoreboardEntry other)
    {
        if (this == other)
        {
            return 0;
        }

        var result = -Score.CompareTo(other.Score);

        if (result == 0)
        {
            result = string.Compare(Username, other.Username,
                StringComparison.InvariantCulture);
        }

        return result;
    }

    public override string ToString()
    {
        return $"{Username} {Score}";
    }
}