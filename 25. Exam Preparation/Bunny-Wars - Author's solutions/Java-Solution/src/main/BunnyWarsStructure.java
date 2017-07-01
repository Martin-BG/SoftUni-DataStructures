package main;

import java.util.*;

public class BunnyWarsStructure implements IBunnyWarsStructure {

    private static final int TeamCount = 5;

    private TreeSet<Bunny> bunniesOrderedBySuffix = new TreeSet<>(new OrdinalSuffixComparator());
    private HashMap<String, Bunny> bunniesByName = new HashMap<>();
    private TreeMap<Integer, List<Bunny>[]> rooms = new TreeMap<>();
    private TreeSet<Integer> roomsById = new TreeSet<>();
    private TreeSet<Bunny>[] bunniesByTeam = new TreeSet[TeamCount];

    @Override
    public int getBunnyCount() {
        return this.bunniesByName.size();
    }

    @Override
    public int getRoomCount() {
        return this.roomsById.size();
    }

    @Override
    public void AddRoom(int roomId) {
        if (rooms.containsKey(roomId)) {
            throw new IllegalArgumentException("Room already exists");
        }

        roomsById.add(roomId);
        rooms.put(roomId, new ArrayList[TeamCount]);
    }

    @Override
    public void AddBunny(String name, int team, int roomId) {
        if (bunniesByName.containsKey(name)) {
            throw new IllegalArgumentException("main.Bunny already exists");
        }

        if (! roomsById.contains(roomId)) {
            throw new IllegalArgumentException("Room does not exist");
        }

        Bunny bunny = new Bunny(name, team, roomId);
        bunniesByName.put(name, bunny);

        // Add to team
        if (bunniesByTeam[team] == null) {
            bunniesByTeam[team] = new TreeSet<>();
        }

        bunniesByTeam[team].add(bunny);

        // Add to room
        List<Bunny>[] room = rooms.get(roomId);
        if (room[team] == null) {
            room[team] = new ArrayList<Bunny>();
        }

        room[team].add(bunny);

        // Add to suffix set
        bunniesOrderedBySuffix.add(bunny);
    }

    @Override
    public void Remove(int roomId) {
        if (! roomsById.contains(roomId)) {
            throw new IllegalArgumentException("Room does not exist");
        }

        List<Bunny>[] teamsInRoom = rooms.get(roomId);
        for (List<Bunny> team : teamsInRoom) {
            if (team == null) continue;;
            for (Bunny bunny : team) {
                this.removeBunny(bunny);
            }
        }

        roomsById.remove(roomId);
        rooms.remove(roomId);
    }

    private void removeBunny(Bunny bunny) {
        bunniesByName.remove(bunny.getName());
        bunniesOrderedBySuffix.remove(bunny);
        bunniesByTeam[bunny.getTeam()].remove(bunny);
    }

    @Override
    public void Next(String bunnyName) {
        if (! bunniesByName.containsKey(bunnyName)) {
            throw new IllegalArgumentException("main.Bunny does not exist");
        }

        Bunny bunny = bunniesByName.get(bunnyName);
        this.moveBunnyToRoom(bunny, true);
    }

    @Override
    public void Previous(String bunnyName) {
        if (! bunniesByName.containsKey(bunnyName)) {
            throw new IllegalArgumentException("main.Bunny does not exist");
        }

        Bunny bunny = bunniesByName.get(bunnyName);
        this.moveBunnyToRoom(bunny, false);
    }

    private void moveBunnyToRoom(Bunny bunny, boolean next) {

        // Remove from current room
        rooms.get(bunny.getRoomId())[bunny.getTeam()].remove(bunny);

        // Add to new room
        Integer nextRoomId;
        int bunnyRoom = bunny.getRoomId(), bunnyTeam = bunny.getTeam();
        if (next) {
             nextRoomId = roomsById.higher(bunnyRoom);
            if (nextRoomId == null)
                nextRoomId = roomsById.first();
        } else {
            nextRoomId = roomsById.lower(bunnyRoom);
            if (nextRoomId == null) {
                nextRoomId = roomsById.last();
            }
        }

        List<Bunny>[] nextRoom = rooms.get(nextRoomId);
        if (nextRoom[bunnyTeam] == null) {
            nextRoom[bunnyTeam] = new ArrayList<>();
        }

        nextRoom[bunnyTeam].add(bunny);
        bunny.setRoomId(nextRoomId);
    }

    @Override
    public void Detonate(String bunnyName) {
        if (! bunniesByName.containsKey(bunnyName)) {
            throw new IllegalArgumentException("main.Bunny does not exist");
        }

        Bunny bunny = bunniesByName.get(bunnyName);
        List<Bunny>[] teamsInRoom = rooms.get(bunny.getRoomId());
        int kills = 0;
        for (int i = 0; i < teamsInRoom.length; i++) {
            List<Bunny> team = teamsInRoom[i];
            if (i == bunny.getTeam() || team == null)
                continue;

            for (int j = 0; j < team.size(); j++) {
                Bunny targetBunny = team.get(j);
                targetBunny.setHealth(targetBunny.getHealth() - 30);
                if (targetBunny.getHealth() <= 0) {
                    team.remove(j);
                    this.removeBunny(targetBunny);
                    j--;
                    kills++;
                }
            }
        }

        bunny.setScore(bunny.getScore() + kills);
    }

    @Override
    public Iterable<Bunny> ListBunniesByTeam(int team) {
        return bunniesByTeam[team];
    }

    @Override
    public Iterable<Bunny> ListBunniesBySuffix(String suffix) {
        Bunny low = new Bunny(suffix, 0, 0);
        Bunny high = new Bunny(Character.MAX_VALUE + suffix, 0, 0);

        return bunniesOrderedBySuffix.subSet(low, true, high, true);
    }
}
