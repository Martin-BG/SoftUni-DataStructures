namespace PitFortress.Interfaces
{
    using System;

    using PitFortress.Classes;

    public interface IMinion : IComparable<Minion>
    {
        int Id { get; }

        int XCoordinate { get; }

        int Health { get; set; }
    }
}
