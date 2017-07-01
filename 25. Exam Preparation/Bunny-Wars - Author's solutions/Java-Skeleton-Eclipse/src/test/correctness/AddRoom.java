package test.correctness;

import org.junit.Assert;
import org.junit.Test;
import org.junit.experimental.categories.Category;
import test.helpers.BaseTest;
import test.types.CorrectnessTests;

public class AddRoom extends BaseTest {

    @Category(CorrectnessTests.class)
    @Test(expected = IllegalArgumentException.class)
    public void AddRoom_WithAnExistingNumber_ShouldThrowException()
    {
        //Arrange
        int roomId = 15;

        //Act
        this.BunnyWarCollection.addRoom(roomId);
        this.BunnyWarCollection.addRoom(roomId);
    }

    @Category(CorrectnessTests.class)
    @Test
    public void AddRoom_WithNoRooms_ShouldAddRoomOnce()
    {
        //Arrange
        int roomId = 15;

        //Act
        this.BunnyWarCollection.addRoom(roomId);

        //Assert
        Assert.assertEquals("Incorrect amount of rooms added!", 1, this.BunnyWarCollection.getRoomCount());
    }

    @Category(CorrectnessTests.class)
    @Test
    public void AddRoom_WithNegativeId_ShouldAddRoom()
    {
        //Arrange
        int roomId = -10;

        //Act
        this.BunnyWarCollection.addRoom(roomId);

        //Assert
        Assert.assertEquals("Incorrect amount of rooms added!", 1, this.BunnyWarCollection.getRoomCount());
    }
}
