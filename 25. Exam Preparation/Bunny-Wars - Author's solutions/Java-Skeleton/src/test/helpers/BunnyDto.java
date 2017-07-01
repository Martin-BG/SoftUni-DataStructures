package test.helpers;

public class BunnyDto {
    private String name;
    private int team;
    private int roomId;
    private int health;
    private int score;

    public BunnyDto(String name, int health, int score, int team, int roomId) {
        this.name = name;
        this.team = team;
        this.roomId = roomId;
        this.health = health;
        this.score = score;
    }

    public String getName() {
        return name;
    }

    public int getTeam() {
        return team;
    }

    public int getRoomId() {
        return roomId;
    }

    public int getHealth() {
        return health;
    }

    public int getScore() {
        return score;
    }
}
