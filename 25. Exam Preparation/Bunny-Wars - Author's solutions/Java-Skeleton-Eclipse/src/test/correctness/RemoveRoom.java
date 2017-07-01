package test.correctness;

import org.junit.Assert;
import org.junit.Test;
import org.junit.experimental.categories.Category;
import test.helpers.BaseTest;
import test.types.CorrectnessTests;

public class RemoveRoom extends BaseTest {

    @Category(CorrectnessTests.class)
    @Test(expected = IllegalArgumentException.class)
    public void RemoveRoom_WithNonExistantRoom_ShouldThrowException()
    {
        //Arrange
        int roomId = 1;

        //Act
        this.BunnyWarCollection.remove(roomId);
    }

    @Category(CorrectnessTests.class)
    @Test
    public void RemoveRoom_WithASingleRoom_ShouldReduceRoomsCountByOne()
    {
        //Arrange
        int roomId = 1;
        this.BunnyWarCollection.addRoom(roomId);
        Assert.assertEquals("Incorrect amount of rooms added!", 1, this.BunnyWarCollection.getRoomCount());

        //Act
        this.BunnyWarCollection.remove(roomId);

        //Assert
        Assert.assertEquals("Incorrect ammount of rooms removed!", 0, this.BunnyWarCollection.getRoomCount());
    }

    @Category(CorrectnessTests.class)
    @Test
    public void RemoveRoom_WithAMultipleRooms_ShouldReduceRoomsCountByOne()
    {
        //Arrange
        this.BunnyWarCollection.addRoom(-1);
        this.BunnyWarCollection.addRoom(0);
        this.BunnyWarCollection.addRoom(1);
        this.BunnyWarCollection.addRoom(2);
        Assert.assertEquals("Incorrect amount of rooms added!", 4, this.BunnyWarCollection.getRoomCount());

        //Act
        this.BunnyWarCollection.remove(1);

        //Assert
        Assert.assertEquals("Incorrect ammount of rooms removed!", 3, this.BunnyWarCollection.getRoomCount());
    }

    @Category(CorrectnessTests.class)
    @Test
    public void RemoveRoom_WithASingleRoomWithNoBunniesInside_ShouldNotChangeBunniesCount()
    {
        //Arrange
        this.BunnyWarCollection.addRoom(-10);
        Assert.assertEquals("Structure is constructed with incorrect amount of bunnies!", 0, this.BunnyWarCollection.getBunnyCount());

        //Act
        this.BunnyWarCollection.remove(-10);

        //Assert
        Assert.assertEquals("Incorrect ammount of bunnies after removal!", 0, this.BunnyWarCollection.getBunnyCount());
    }

    @Category(CorrectnessTests.class)
    @Test
    public void RemoveRoom_WithASingleRoomWithOneBunny_ShouldReduceBunniesCountByOne()
    {
        //Arrange
        this.BunnyWarCollection.addRoom(5);
        this.BunnyWarCollection.addBunny("Nasko", 1, 5);
        Assert.assertEquals("Incorrect ammount of bunnies added!", 1, this.BunnyWarCollection.getBunnyCount());

        //Act
        this.BunnyWarCollection.remove(5);

        //Assert
        Assert.assertEquals("Incorrect ammount of bunnies removed!", 0, this.BunnyWarCollection.getBunnyCount());
    }

    @Category(CorrectnessTests.class)
    @Test
    public void RemoveRoom_WithASingleRoomWithMultipleBunnies_ShouldReduceBunniesCountCorrectly()
    {
        //Arrange
        this.BunnyWarCollection.addRoom(5);
        this.BunnyWarCollection.addBunny("Nasko", 0, 5);
        this.BunnyWarCollection.addBunny("Dancho", 1, 5);
        this.BunnyWarCollection.addBunny("Trifon", 2, 5);
        this.BunnyWarCollection.addBunny("Royal", 3, 5);
        this.BunnyWarCollection.addBunny("Edo", 4, 5);
        Assert.assertEquals("Incorrect ammount of bunnies added!", 5, this.BunnyWarCollection.getBunnyCount());

        //Act
        this.BunnyWarCollection.remove(5);

        //Assert
        Assert.assertEquals("Incorrect ammount of bunnies removed!", 0, this.BunnyWarCollection.getBunnyCount());
    }

    @Category(CorrectnessTests.class)
    @Test
    public void RemoveRoom_WithMultipleRoomsWithMultipleBunnies_ShouldReduceBunniesCountCorrectly()
    {
        //Arrange
        this.BunnyWarCollection.addRoom(5);
        this.BunnyWarCollection.addRoom(100);
        this.BunnyWarCollection.addRoom(-1000);
        this.BunnyWarCollection.addRoom(257444);
        this.BunnyWarCollection.addBunny("Nasko", 0, 257444);
        this.BunnyWarCollection.addBunny("Dancho", 1, -1000);
        this.BunnyWarCollection.addBunny("Trifon", 2, 5);
        this.BunnyWarCollection.addBunny("Royal", 3, 100);
        this.BunnyWarCollection.addBunny("Ivo", 4, 257444);
        this.BunnyWarCollection.addBunny("Nakov", 0, 5);
        this.BunnyWarCollection.addBunny("Angel", 1, 100);
        this.BunnyWarCollection.addBunny("Joro", 2, -1000);
        this.BunnyWarCollection.addBunny("Alex", 3, 257444);
        this.BunnyWarCollection.addBunny("Ivan", 4, 5);
        Assert.assertEquals("Incorrect ammount of bunnies added!", 10, this.BunnyWarCollection.getBunnyCount());

        //Act
        this.BunnyWarCollection.remove(257444);

        //Assert
        Assert.assertEquals("Incorrect ammount of bunnies removed!", 7, this.BunnyWarCollection.getBunnyCount());
    }
}
