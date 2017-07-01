package test.performance;

import main.Bunny;
import org.junit.Assert;
import org.junit.Test;
import org.junit.experimental.categories.Category;
import test.helpers.BasePerformanceTest;
import test.helpers.IterableExtensions;
import test.types.PerformanceTests;

import java.util.ArrayList;
import java.util.List;

public class ListByTeamPerformance extends BasePerformanceTest {

    @Category(PerformanceTests.class)
    @Test
    public void PerformanceListByTeam_With10000BunniesInOneRoomInSameTeam()
    {
        //Arrange
        int bunniesCount = 10000;
        this.BunnyWarCollection.AddRoom(0);
        for (int i = 0; i < bunniesCount; i++)
        {
            this.BunnyWarCollection.AddBunny(i + "", 0, 0);
        }

        //Act
        long start = System.currentTimeMillis();
        for (int i = 0; i < 10000; i++)
        {
            long result = IterableExtensions.getCount(this.BunnyWarCollection.ListBunniesByTeam(0));
            Assert.assertEquals("Incorrect count of bunnies returned by List By Team Command!", 10000, result);
        }
        long end = System.currentTimeMillis();
        Assert.assertTrue(end - start < 100);
    }

    @Category(PerformanceTests.class)
    @Test
    public void PerformanceListByTeam_With10000BunniesRandomlyDistributedIn5000RoomsInSameTeam()
    {
        //Arrange
        int roomsCount = 5000;
        int bunniesCount = 10000;
        for (int i = 0; i < roomsCount; i++)
        {
            this.BunnyWarCollection.AddRoom(i);
        }
        for (int i = 0; i < bunniesCount; i++)
        {
            int randomroom = this.random.nextInt(roomsCount);
            this.BunnyWarCollection.AddBunny(i + "", 2, randomroom);
        }

        //Act
        long start = System.currentTimeMillis();
        for (int i = 0; i < 10000; i++)
        {
            long result = IterableExtensions.getCount(this.BunnyWarCollection.ListBunniesByTeam(2));
            Assert.assertEquals("Incorrect count of bunnies returned by List By Team Command!", 10000, result);
        }
        long end = System.currentTimeMillis();
        Assert.assertTrue(end - start < 100);
    }

    @Category(PerformanceTests.class)
    @Test
    public void PerformanceListByTeam_With10000BunniesRandomlyDistributedIn5000RoomsInDifferentTeams()
    {
        //Arrange
        int roomsCount = 5000;
        int bunniesCount = 10000;
        for (int i = 0; i < roomsCount; i++)
        {
            this.BunnyWarCollection.AddRoom(i);
        }

        List<Bunny> bunnies = new ArrayList<>();
        for (int i = 0; i < bunniesCount; i++)
        {
            int randomTeam = this.random.nextInt(5);
            int randomRoom = this.random.nextInt(roomsCount);
            bunnies.add(new Bunny(i + "", randomTeam, randomRoom));
            this.BunnyWarCollection.AddBunny(i + "", randomTeam, randomRoom);
        }

        //Act
        long start = System.currentTimeMillis();
        for (int i = 0; i < 10000; i++)
        {
            int randomTeam = this.random.nextInt(5);
            long result = IterableExtensions.getCount(this.BunnyWarCollection.ListBunniesByTeam(randomTeam));
        }

        long end = System.currentTimeMillis();
        Assert.assertTrue((end - start) + "", end - start < 100);
    }
}
