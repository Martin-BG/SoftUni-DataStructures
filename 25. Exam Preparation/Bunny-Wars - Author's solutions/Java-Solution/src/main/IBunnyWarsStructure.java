package main;

public interface IBunnyWarsStructure {

    void AddRoom(int roomId);

    void AddBunny(String name, int team, int roomId);

    int getBunnyCount();

    int getRoomCount();

    void Remove(int roomId);

    void Next(String bunnyName);

    void Previous(String bunnyName);

    void Detonate(String bunnyName);

    Iterable<Bunny> ListBunniesByTeam(int team);

    Iterable<Bunny> ListBunniesBySuffix(String suffix);
}
