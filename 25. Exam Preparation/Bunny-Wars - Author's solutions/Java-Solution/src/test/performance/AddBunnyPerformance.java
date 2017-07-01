package test.performance;

import org.junit.Assert;
import org.junit.Test;
import org.junit.experimental.categories.Category;
import test.helpers.BasePerformanceTest;
import test.types.CorrectnessTests;
import test.types.PerformanceTests;

import java.util.Arrays;
import java.util.List;

public class AddBunnyPerformance extends BasePerformanceTest {

    private List<String> Prefixes = Arrays.asList("Pesho", "Nasko", "Joro", "Dijkstra", "Stamat");

    @Category(PerformanceTests.class)
    @Test
    public void PerformanceAddBunny_With10000Bunnies_WithASingleRoomAndTeam()
    {
        //Arrange
        int count = 1;
        int bunnyCount = 10000;
        this.BunnyWarCollection.AddRoom(0);

        //Act
        long start = System.currentTimeMillis();
        for (int i = 0; i < bunnyCount; i++)
        {
            this.BunnyWarCollection.AddBunny(i + "", 0, 0);
            Assert.assertEquals("Incorrect count after adding!", count++, this.BunnyWarCollection.getBunnyCount());
        }
        long end = System.currentTimeMillis();
        Assert.assertTrue(end - start < 600);
    }

    @Category(PerformanceTests.class)
    @Test
    public void PerformanceAddBunny_With10000Bunnies_With1000Rooms()
    {
        for (int i = 0; i < 1000; i++)
        {
            this.BunnyWarCollection.AddRoom(i);
        }
        //Arrange
        int count = 1;
        int bunnyCount = 10000;

        //Act
        long start = System.currentTimeMillis();
        for (int i = 0; i < bunnyCount; i++)
        {
            this.BunnyWarCollection.AddBunny(i + "", 0, i / 10);
            Assert.assertEquals("Incorrect count after adding!", count++, this.BunnyWarCollection.getBunnyCount());
        }

        long end = System.currentTimeMillis();
        Assert.assertTrue(end - start < 400);
    }

    @Category(PerformanceTests.class)
    @Test
    public void PerformanceAddBunny_With10000Bunnies_With1000RoomsAnd5Teams()
    {
        for (int i = 0; i < 1000; i++)
        {
            this.BunnyWarCollection.AddRoom(i);
        }
        //Arrange
        int count = 1;
        int bunnyCount = 10000;

        //Act
        long start = System.currentTimeMillis();
        for (int i = 0; i < bunnyCount; i++)
        {
            this.BunnyWarCollection.AddBunny(i + "", i % 5, i / 10);
            Assert.assertEquals("Incorrect count after adding!", count++, this.BunnyWarCollection.getBunnyCount());
        }
        long end = System.currentTimeMillis();
        Assert.assertTrue(end - start < 400);
    }

    @Category(PerformanceTests.class)
    @Test
    public void PerformanceAddBunny_With10000RandomBunnies_WithASingleRoomAndTeam()
    {
        //Arrange
        int count = 1;
        int bunnyCount = 10000;
        this.BunnyWarCollection.AddRoom(0);

        //Act
        long start = System.currentTimeMillis();
        for (int i = 0; i < bunnyCount; i++)
        {
            int index = this.random.nextInt(this.Prefixes.size());
            this.BunnyWarCollection.AddBunny(
                    this.Prefixes.get(index) + i, 0, 0);
            Assert.assertEquals("Incorrect count after adding!", count++, this.BunnyWarCollection.getBunnyCount());
        }
        long end = System.currentTimeMillis();
        Assert.assertTrue(end - start < 500);
    }

    @Category(PerformanceTests.class)
    @Test
    public void PerformanceAddBunny_With10000RandomBunnies_With1000RoomsAnd5Teams()
    {
        for (int i = 0; i < 1000; i++)
        {
            this.BunnyWarCollection.AddRoom(i);
        }
        //Arrange
        int count = 1;
        int bunnyCount = 10000;

        //Act
        long start = System.currentTimeMillis();
        for (int i = 0; i < bunnyCount; i++)
        {
            int index = this.random.nextInt(this.Prefixes.size());
            int team = this.random.nextInt(5);
            int room = this.random.nextInt(1000);
            this.BunnyWarCollection.AddBunny(
                    this.Prefixes.get(index) + i, team, room);

            Assert.assertEquals("Incorrect count after adding!", count++, this.BunnyWarCollection.getBunnyCount());
        }

        long end = System.currentTimeMillis();
        Assert.assertTrue(end - start < 400);
    }
}
