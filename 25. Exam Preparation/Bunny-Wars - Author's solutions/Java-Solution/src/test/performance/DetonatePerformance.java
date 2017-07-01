package test.performance;

import org.junit.Assert;
import org.junit.Test;
import org.junit.experimental.categories.Category;
import test.helpers.BasePerformanceTest;
import test.types.PerformanceTests;

public class DetonatePerformance extends BasePerformanceTest {

    @Category(PerformanceTests.class)
    @Test
    public void PerformanceDetonate_WithOneBunnyDetonatingMultipleTimes_With10000BunniesInOneRoomInDifferentTeams()
    {
        //Arrange
        int bunniesCount = 10000;
        this.BunnyWarCollection.AddRoom(4);
        for (int i = 0; i < bunniesCount; i++)
        {
            this.BunnyWarCollection.AddBunny(i + "", i % 4, 4);
        }

        String bunny = this.random.nextInt(bunniesCount) + "";

        //Act
        long start = System.currentTimeMillis();
        for (int i = 0; i < bunniesCount; i++)
        {
            this.BunnyWarCollection.Detonate(bunny);
        }
        Assert.assertEquals("Incorrect amount of bunnies after detonation!", 2500, this.BunnyWarCollection.getBunnyCount());
        long end = System.currentTimeMillis();
        Assert.assertTrue(end - start < 500);
    }

    @Category(PerformanceTests.class)
    @Test
    public void PerformanceDetonate_With10000RandomDetonates_With10000BunniesInOneRoomWithSameTeam()
    {
        //Arrange
        int bunniesCount = 10000;
        this.BunnyWarCollection.AddRoom(3);
        for (int i = 0; i < bunniesCount; i++)
        {
            this.BunnyWarCollection.AddBunny(i + "", 0, 3);
        }

        //Act
        long start = System.currentTimeMillis();
        for (int i = 0; i < bunniesCount; i++)
        {
            this.BunnyWarCollection.Detonate(this.random.nextInt(bunniesCount) + "");
        }
        Assert.assertEquals("Incorrect amount of bunnies after detonation!", 10000, this.BunnyWarCollection.getBunnyCount());
        long end = System.currentTimeMillis();
        Assert.assertTrue(end - start < 100);
    }

    @Category(PerformanceTests.class)
    @Test
    public void PerformanceDetonate_With4OutOf5BunniesDetonatingConsecutivelyInEveryRoom_With10000BunniesIn2000RoomsInDifferentTeams()
    {
        //Arrange
        int roomsCount = 2000;
        int bunniesCount = 10000;
        for (int i = 0; i < roomsCount; i++)
        {
            this.BunnyWarCollection.AddRoom(i);
        }

        for (int i = 0; i < bunniesCount; i++)
        {
            this.BunnyWarCollection.AddBunny(i + "", i % 5, i / 5);
        }

        //Act
        long start = System.currentTimeMillis();
        for (int i = 0; i < bunniesCount; i++)
        {
            if (i % 5 != 4)
            {
                this.BunnyWarCollection.Detonate(i + "");
            }
        }
        Assert.assertEquals("Incorrect amount of bunnies after detonation!", 8000, this.BunnyWarCollection.getBunnyCount());
        long end = System.currentTimeMillis();
        Assert.assertTrue(end - start < 100);
    }

    @Category(PerformanceTests.class)
    @Test
    public void PerformanceDetonate_With10000DetonationsInReverseOrder_With10000BunniesIn3334RoomsInDifferentTeams()
    {
        //Arrange
        int roomsCount = 3334;
        int bunniesCount = 10000;
        for (int i = 0; i < roomsCount; i++)
        {
            this.BunnyWarCollection.AddRoom(i);
        }

        for (int i = 0; i < bunniesCount; i++)
        {
            this.BunnyWarCollection.AddBunny(i + "", i % 5, i / 3);
        }

        //Act
        long start = System.currentTimeMillis();
        for (int i = bunniesCount - 1; i >= 0; i--)
        {
            this.BunnyWarCollection.Detonate(i + "");
        }
        Assert.assertEquals("Incorrect amount of bunnies after detonation!", 10000, this.BunnyWarCollection.getBunnyCount());
        long end = System.currentTimeMillis();
        Assert.assertTrue(end - start < 100);
    }
}
