namespace PitFortress.Interfaces
{
    using System;

    using PitFortress.Classes;

    public interface IPlayer : IComparable<Player>
    {
        string Name { get; }

        int Radius { get; }

        int Score { get; set; }
    }
}
