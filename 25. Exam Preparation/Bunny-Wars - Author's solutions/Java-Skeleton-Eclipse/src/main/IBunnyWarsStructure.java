package main;

public interface IBunnyWarsStructure {

    void addRoom(int roomId);

    void addBunny(String name, int team, int roomId);

    int getBunnyCount();

    int getRoomCount();

    void remove(int roomId);

    void next(String bunnyName);

    void previous(String bunnyName);

    void detonate(String bunnyName);

    Iterable<Bunny> listBunniesByTeam(int team);

    Iterable<Bunny> listBunniesBySuffix(String suffix);
}
