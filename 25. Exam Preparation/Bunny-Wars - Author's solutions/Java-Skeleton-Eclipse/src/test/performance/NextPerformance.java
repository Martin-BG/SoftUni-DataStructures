package test.performance;

import org.junit.Assert;
import org.junit.Test;
import org.junit.experimental.categories.Category;
import test.helpers.BasePerformanceTest;
import test.types.PerformanceTests;

public class NextPerformance extends BasePerformanceTest {

    @Category(PerformanceTests.class)
    @Test
    public void PerformanceNext_With10000ConsecutiveNextCommands_With10000BunniesInOneRoom()
    {
        //Arrange
        int bunniesCount = 10000;
        this.BunnyWarCollection.addRoom(0);
        for (int i = 0; i < bunniesCount; i++)
        {
            this.BunnyWarCollection.addBunny(i + "", i % 5, 0);
        }

        //Act
        long start = System.currentTimeMillis();
        for (int i = 0; i < bunniesCount; i++)
        {
            this.BunnyWarCollection.next(i + "");
        }
        long end = System.currentTimeMillis();
        Assert.assertTrue(start - end < 600);
    }

    @Category(PerformanceTests.class)
    @Test
    public void PerformanceNext_With10000ConsecutiveNextCommands_With10000BunniesIn5000Rooms()
    {
        //Arrange
        int roomsCount = 5000;
        int bunniesCount = 10000;
        for (int i = 0; i < roomsCount; i++)
        {
            this.BunnyWarCollection.addRoom(i);
        }

        for (int i = 0; i < bunniesCount; i++)
        {
            this.BunnyWarCollection.addBunny(i + "", i % 5, i / 2);
        }

        //Act
        long start = System.currentTimeMillis();
        for (int i = 0; i < bunniesCount; i++)
        {
            this.BunnyWarCollection.next(i + "");
        }
        long end = System.currentTimeMillis();
        Assert.assertTrue(start - end < 500);
    }

    @Category(PerformanceTests.class)
    @Test
    public void PerformanceNext_With10000RandomNextCommands_With10000BunniesIn5000Rooms()
    {
        //Arrange
        int roomsCount = 5000;
        int bunniesCount = 10000;
        for (int i = 0; i < roomsCount; i++)
        {
            this.BunnyWarCollection.addRoom(i);
        }

        for (int i = 0; i < bunniesCount; i++)
        {
            this.BunnyWarCollection.addBunny(i + "", i % 5, i / 2);
        }

        //Act
        long start = System.currentTimeMillis();
        for (int i = 0; i < bunniesCount; i++)
        {
            this.BunnyWarCollection.next(this.random.nextInt(bunniesCount) + "");
        }
        long end = System.currentTimeMillis();
        Assert.assertTrue(start - end < 500);
    }
}
