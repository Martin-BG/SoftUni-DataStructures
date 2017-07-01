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
        this.BunnyWarCollection.Remove(roomId);
    }

    @Category(CorrectnessTests.class)
    @Test
    public void RemoveRoom_WithASingleRoom_ShouldReduceRoomsCountByOne()
    {
        //Arrange
        int roomId = 1;
        this.BunnyWarCollection.AddRoom(roomId);
        Assert.assertEquals("Incorrect amount of rooms added!", 1, this.BunnyWarCollection.getRoomCount());

        //Act
        this.BunnyWarCollection.Remove(roomId);

        //Assert
        Assert.assertEquals("Incorrect ammount of rooms removed!", 0, this.BunnyWarCollection.getRoomCount());
    }

    @Category(CorrectnessTests.class)
    @Test
    public void RemoveRoom_WithAMultipleRooms_ShouldReduceRoomsCountByOne()
    {
        //Arrange
        this.BunnyWarCollection.AddRoom(-1);
        this.BunnyWarCollection.AddRoom(0);
        this.BunnyWarCollection.AddRoom(1);
        this.BunnyWarCollection.AddRoom(2);
        Assert.assertEquals("Incorrect amount of rooms added!", 4, this.BunnyWarCollection.getRoomCount());

        //Act
        this.BunnyWarCollection.Remove(1);

        //Assert
        Assert.assertEquals("Incorrect ammount of rooms removed!", 3, this.BunnyWarCollection.getRoomCount());
    }

    @Category(CorrectnessTests.class)
    @Test
    public void RemoveRoom_WithASingleRoomWithNoBunniesInside_ShouldNotChangeBunniesCount()
    {
        //Arrange
        this.BunnyWarCollection.AddRoom(-10);
        Assert.assertEquals("Structure is constructed with incorrect amount of bunnies!", 0, this.BunnyWarCollection.getBunnyCount());

        //Act
        this.BunnyWarCollection.Remove(-10);

        //Assert
        Assert.assertEquals("Incorrect ammount of bunnies after removal!", 0, this.BunnyWarCollection.getBunnyCount());
    }

    @Category(CorrectnessTests.class)
    @Test
    public void RemoveRoom_WithASingleRoomWithOneBunny_ShouldReduceBunniesCountByOne()
    {
        //Arrange
        this.BunnyWarCollection.AddRoom(5);
        this.BunnyWarCollection.AddBunny("Nasko",1,5);
        Assert.assertEquals("Incorrect ammount of bunnies added!", 1, this.BunnyWarCollection.getBunnyCount());

        //Act
        this.BunnyWarCollection.Remove(5);

        //Assert
        Assert.assertEquals("Incorrect ammount of bunnies removed!", 0, this.BunnyWarCollection.getBunnyCount());
    }

    @Category(CorrectnessTests.class)
    @Test
    public void RemoveRoom_WithASingleRoomWithMultipleBunnies_ShouldReduceBunniesCountCorrectly()
    {
        //Arrange
        this.BunnyWarCollection.AddRoom(5);
        this.BunnyWarCollection.AddBunny("Nasko", 0, 5);
        this.BunnyWarCollection.AddBunny("Dancho", 1, 5);
        this.BunnyWarCollection.AddBunny("Trifon", 2, 5);
        this.BunnyWarCollection.AddBunny("Royal", 3, 5);
        this.BunnyWarCollection.AddBunny("Edo", 4, 5);
        Assert.assertEquals("Incorrect ammount of bunnies added!", 5, this.BunnyWarCollection.getBunnyCount());

        //Act
        this.BunnyWarCollection.Remove(5);

        //Assert
        Assert.assertEquals("Incorrect ammount of bunnies removed!", 0, this.BunnyWarCollection.getBunnyCount());
    }

    @Category(CorrectnessTests.class)
    @Test
    public void RemoveRoom_WithMultipleRoomsWithMultipleBunnies_ShouldReduceBunniesCountCorrectly()
    {
        //Arrange
        this.BunnyWarCollection.AddRoom(5);
        this.BunnyWarCollection.AddRoom(100);
        this.BunnyWarCollection.AddRoom(-1000);
        this.BunnyWarCollection.AddRoom(257444);
        this.BunnyWarCollection.AddBunny("Nasko", 0, 257444);
        this.BunnyWarCollection.AddBunny("Dancho", 1, -1000);
        this.BunnyWarCollection.AddBunny("Trifon", 2, 5);
        this.BunnyWarCollection.AddBunny("Royal", 3, 100);
        this.BunnyWarCollection.AddBunny("Ivo", 4, 257444);
        this.BunnyWarCollection.AddBunny("Nakov", 0, 5);
        this.BunnyWarCollection.AddBunny("Angel", 1, 100);
        this.BunnyWarCollection.AddBunny("Joro", 2, -1000);
        this.BunnyWarCollection.AddBunny("Alex", 3, 257444);
        this.BunnyWarCollection.AddBunny("Ivan", 4, 5);
        Assert.assertEquals("Incorrect ammount of bunnies added!", 10, this.BunnyWarCollection.getBunnyCount());

        //Act
        this.BunnyWarCollection.Remove(257444);

        //Assert
        Assert.assertEquals("Incorrect ammount of bunnies removed!", 7, this.BunnyWarCollection.getBunnyCount());
    }
}
