package test.performance;

import org.junit.Assert;
import org.junit.Test;
import org.junit.experimental.categories.Category;
import test.helpers.BasePerformanceTest;
import test.types.PerformanceTests;

public class RemovePerformance extends BasePerformanceTest {

    @Category(PerformanceTests.class)
    @Test
    public void PerformanceRemoveRoom_With15000RemoveCommands_With15000EmptyRooms()
    {
        for (int i = 0; i < 15000; i++)
        {
            this.BunnyWarCollection.addRoom(i);
        }

        //Arrange
        int count = 15000;
        int roomsCount = 15000;

        //Act
        long start = System.currentTimeMillis();
        for (int i = 0; i < roomsCount; i++)
        {
            this.BunnyWarCollection.remove(i);
            Assert.assertEquals("Incorrect count of rooms after removal!", --count,this.BunnyWarCollection.getRoomCount());
        }
        long end = System.currentTimeMillis();
        Assert.assertTrue(start - end  < 300);
    }

    @Category(PerformanceTests.class)
    @Test
    public void PerformanceRemoveRoom_With5000RemoveCommands_With10000BunniesIn5000Rooms()
    {
        for (int i = 0; i < 5000; i++)
        {
            this.BunnyWarCollection.addRoom(i);
        }

        for (int i = 0; i < 10000; i++)
        {
            this.BunnyWarCollection.addBunny(i + "", i % 5, i / 2);
        }

        //Arrange
        int count = 5000;
        int roomsCount = 5000;

        //Act
        long start = System.currentTimeMillis();
        for (int i = 0; i < roomsCount; i++)
        {
            this.BunnyWarCollection.remove(i);
            Assert.assertEquals("Incorrect count of rooms after removal!", --count, this.BunnyWarCollection.getRoomCount());
        }
        long end = System.currentTimeMillis();
        Assert.assertTrue(start - end  < 400);
    }
}
