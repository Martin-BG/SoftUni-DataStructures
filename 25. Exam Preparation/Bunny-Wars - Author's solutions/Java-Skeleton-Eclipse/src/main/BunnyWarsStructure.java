package main;

import java.util.*;

public class BunnyWarsStructure implements IBunnyWarsStructure {

    private static final int TeamCount = 5;

    @Override
    public int getBunnyCount() {
        throw new UnsupportedOperationException();
    }

    @Override
    public int getRoomCount() {
        throw new UnsupportedOperationException();
    }

    @Override
    public void addRoom(int roomId) {
        throw new UnsupportedOperationException();
    }

    @Override
    public void addBunny(String name, int team, int roomId) {
        throw new UnsupportedOperationException();
    }

    @Override
    public void remove(int roomId) {
        throw new UnsupportedOperationException();
    }

    @Override
    public void next(String bunnyName) {
        throw new UnsupportedOperationException();
    }

    @Override
    public void previous(String bunnyName) {
        throw new UnsupportedOperationException();
    }

    @Override
    public void detonate(String bunnyName) {
        throw new UnsupportedOperationException();
    }

    @Override
    public Iterable<Bunny> listBunniesByTeam(int team) {
        throw new UnsupportedOperationException();
    }

    @Override
    public Iterable<Bunny> listBunniesBySuffix(String suffix) {
        throw new UnsupportedOperationException();
    }
}
