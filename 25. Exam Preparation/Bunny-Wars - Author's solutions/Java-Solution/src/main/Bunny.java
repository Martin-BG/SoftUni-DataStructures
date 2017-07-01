package main;

public class Bunny implements Comparable<Bunny> {

    private String name;
    private int team;
    private int roomId;
    private int health;
    private int score;

    public Bunny(String name, int team, int roomId) {
        this.setName(name);
        this.setTeam(team);
        this.setRoomId(roomId);
        this.setHealth(100);
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getTeam() {
        return team;
    }

    public void setTeam(int team) {
        this.team = team;
    }

    public int getRoomId() {
        return roomId;
    }

    public void setRoomId(int roomId) {
        this.roomId = roomId;
    }

    public int getHealth() {
        return health;
    }

    public void setHealth(int health) {
        this.health = health;
    }

    public int getScore() {
        return score;
    }

    public void setScore(int score) {
        this.score = score;
    }

    @Override
    public int compareTo(Bunny other) {
        // Used by bunnies by team to return bunnies in descending order
        return -this.name.compareTo(other.name);
    }
}
