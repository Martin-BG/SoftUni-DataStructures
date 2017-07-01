package test.performance;

import main.Bunny;
import org.junit.Assert;
import org.junit.Test;
import org.junit.experimental.categories.Category;
import test.helpers.BasePerformanceTest;
import test.helpers.IterableExtensions;
import test.types.PerformanceTests;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class ListBunniesBySuffixPerformance extends BasePerformanceTest {

    private List<String> Suffixes = Arrays.asList("Pesho", "Nasko", "RoYaL", "Dijkstra", "Stamat", "RevaL", "Gosho");

    @Category(PerformanceTests.class)
    @Test
    public void PerformanceListBySuffix_With10000BunniesWithoutGivenSuffixInOneRoom()
    {
        //Arrange
        int bunniesCount = 10000;
        this.BunnyWarCollection.AddRoom(0);
        for (int i = 0; i < bunniesCount; i++)
        {
            this.BunnyWarCollection.AddBunny(i + this.Suffixes.get(3), this.random.nextInt(5), 0);
        }

        //Act
        long start = System.currentTimeMillis();
        for (int i = 0; i < 1000; i++)
        {
            Iterable<Bunny> result = this.BunnyWarCollection.ListBunniesBySuffix("DoesNotExist");
            Assert.assertEquals("Incorrect count of List By Suffix Command!", 0, IterableExtensions.getCount(result));
        }

        long end = System.currentTimeMillis();
        Assert.assertTrue(end - start < 100);
    }

    @Category(PerformanceTests.class)
    @Test
    public void PerformanceListBySuffix_With10000BunniesWithSameSuffixInOneRoom()
    {
        //Arrange
        int bunniesCount = 10000;
        this.BunnyWarCollection.AddRoom(0);
        for (int i = 0; i < bunniesCount; i++)
        {
            String randomSuffix = this.Suffixes.get(this.random.nextInt(this.Suffixes.size()));
            int randomTeam = this.random.nextInt(5);
            this.BunnyWarCollection.AddBunny(i + randomSuffix, randomTeam, 0);
        }

        //Act
        long start = System.currentTimeMillis();
        for (int i = 0; i < 1000; i++)
        {
            long result = IterableExtensions.getCount(this.BunnyWarCollection.ListBunniesBySuffix("o"));
        }
        long end = System.currentTimeMillis();
        long actual = end - start;
        Assert.assertTrue(actual + "", actual < 300);
    }

    @Category(PerformanceTests.class)
    @Test
    public void PerformanceListBySuffix_With10000BunniesWithSharedSuffixInMultipleRooms()
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
            String randomSuffix = this.Suffixes.get(this.random.nextInt(this.Suffixes.size()));
            int randomTeam = this.random.nextInt(5);
            int randomRoom = this.random.nextInt(roomsCount);
            this.BunnyWarCollection.AddBunny(i + randomSuffix, randomTeam, randomRoom);
        }

        //Act
        long start = System.currentTimeMillis();
        for (int i = 0; i < 1000; i++)
        {
            long result = IterableExtensions.getCount(this.BunnyWarCollection.ListBunniesBySuffix("aL"));
        }

        long end = System.currentTimeMillis();
        Assert.assertTrue(end - start < 300);
    }

    @Category(PerformanceTests.class)
    @Test
    public void PerformanceListBySuffix_WithEmptySuffix_With10000BunniesWithRandomSuffixesInMultipleRooms()
    {
        //Arrange
        int roomsCount = 5000;
        int bunniesCount = 10000;
        for (int i = 0; i < roomsCount; i++)
        {
            this.BunnyWarCollection.AddRoom(i);
        }
        List<Bunny> list = new ArrayList<>();
        for (int i = 0; i < bunniesCount; i++)
        {
            String randomSuffix = this.Suffixes.get(this.random.nextInt(this.Suffixes.size()));
            int randomTeam = this.random.nextInt(5);
            int randomRoom = this.random.nextInt(roomsCount);
            list.add(new Bunny(i + randomSuffix, randomTeam, randomRoom));
            this.BunnyWarCollection.AddBunny(i + randomSuffix, randomTeam, randomRoom);
        }

        //Act
        long start = System.currentTimeMillis();
        for (int i = 0; i < 1000; i++)
        {
            long result = IterableExtensions.getCount(this.BunnyWarCollection.ListBunniesBySuffix(""));
            Assert.assertEquals("Incorrect count of List By Suffix Command!", 10000, result);
        }
        long end = System.currentTimeMillis();
        Assert.assertTrue(end - start < 1000);
    }
}
