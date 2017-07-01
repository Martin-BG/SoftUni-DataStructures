package test.correctness;

import main.Bunny;
import test.helpers.BaseTest;
import test.helpers.BunnyDto;
import test.helpers.IterableExtensions;
import test.helpers.TestUtils;
import org.junit.Assert;
import org.junit.Test;
import org.junit.experimental.categories.Category;
import test.types.CorrectnessTests;

import java.util.Arrays;
import java.util.Iterator;
import java.util.List;

public class ListBunniesBySuffix extends BaseTest {

    @Category(CorrectnessTests.class)
    @Test
    public void ListBunniesBySuffix_WithEmptyString_ShouldReturnAllBunnies()
    {
        //Arange
        this.BunnyWarCollection.AddRoom(88);
        this.BunnyWarCollection.AddBunny("b",0,88);
        this.BunnyWarCollection.AddBunny("e", 0, 88);
        this.BunnyWarCollection.AddBunny("a", 0, 88);
        this.BunnyWarCollection.AddBunny("c", 0, 88);
        this.BunnyWarCollection.AddBunny("d", 0, 88);
        this.BunnyWarCollection.AddBunny("Nasko", 0, 88);

        //Act
        Iterable<Bunny> bunnies = this.BunnyWarCollection.ListBunniesBySuffix("");

        //Assert
        Assert.assertEquals("Incorrect amount of bunnies returned!",
                6,
                IterableExtensions.getCount(bunnies));
    }

    @Category(CorrectnessTests.class)
    @Test
    public void ListBunniesBySuffix_WithMultipleBunniesInMultipleRoomsAndTeamsWithAValidSuffix_ShouldReturnCorrectAmountOfBunnies()
    {
        //Arange
        this.BunnyWarCollection.AddRoom(20);
        this.BunnyWarCollection.AddRoom(21);
        this.BunnyWarCollection.AddRoom(22);
        this.BunnyWarCollection.AddBunny("Nasko", 1, 22);
        this.BunnyWarCollection.AddBunny("Dancho", 3, 20);
        this.BunnyWarCollection.AddBunny("Royal", 1, 21);
        this.BunnyWarCollection.AddBunny("Edo", 4, 22);
        this.BunnyWarCollection.AddBunny("Vitkurz", 4, 22);
        this.BunnyWarCollection.AddBunny("Trifon", 2, 21);
        this.BunnyWarCollection.AddBunny("Ivo", 3, 21);

        //Act
        Iterable<Bunny> bunnies = this.BunnyWarCollection.ListBunniesBySuffix("o");

        //Assert
        Assert.assertEquals("Incorrect amount of bunnies returned!",
                4,
                IterableExtensions.getCount(bunnies));
    }

    @Category(CorrectnessTests.class)
    @Test
    public void ListBunniesBySuffix_WithNoBunnies_ShouldReturnAnEmptyCollection()
    {
        //Act
        Iterable<Bunny> bunnies = this.BunnyWarCollection.ListBunniesBySuffix("");

        //Assert
        Assert.assertEquals("Incorrect amount of bunnies returned!",
                0,
                IterableExtensions.getCount(bunnies));
    }

    @Category(CorrectnessTests.class)
    @Test
    public void ListBunniesBySuffix_WithMultipleBunniesWithoutGivenSuffix_ShouldReturnAnEmptyCollection()
    {
        //Arange
        this.BunnyWarCollection.AddRoom(88);
        this.BunnyWarCollection.AddRoom(89);
        this.BunnyWarCollection.AddRoom(90);
        this.BunnyWarCollection.AddBunny("Nasko", 0, 89);
        this.BunnyWarCollection.AddBunny("Edo", 1, 89);
        this.BunnyWarCollection.AddBunny("Dancho", 1, 88);
        this.BunnyWarCollection.AddBunny("Zaik1", 0, 90);
        this.BunnyWarCollection.AddBunny("Nasklo", 1, 89);
        this.BunnyWarCollection.AddBunny("Edu", 0, 88);
        this.BunnyWarCollection.AddBunny("RoYaL", 1, 90);

        //Act
        Iterable<Bunny> bunnies = this.BunnyWarCollection.ListBunniesBySuffix("AmiSega");

        //Assert
        Assert.assertEquals("Incorrect amount of bunnies returned!",
                0,
                IterableExtensions.getCount(bunnies));
    }

    @Category(CorrectnessTests.class)
    @Test
    public void ListBunniesBySuffix_WithEmptyString_ShouldReturnBunniesCorrectlySorted()
    {
        //Arange
        this.BunnyWarCollection.AddRoom(88);
        this.BunnyWarCollection.AddBunny("Zaik1", 0, 88);
        this.BunnyWarCollection.AddBunny("", 0, 88);
        this.BunnyWarCollection.AddBunny("a", 0, 88);
        this.BunnyWarCollection.AddBunny("WTFNAMETOOBIGCANTFIT", 0, 88);
        this.BunnyWarCollection.AddBunny("ZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZz", 0, 88);
        this.BunnyWarCollection.AddBunny("Nasko", 0, 88);

        //Act
        Iterable<Bunny> bunnies = this.BunnyWarCollection.ListBunniesBySuffix("");

        //Assert
        Assert.assertEquals(6, IterableExtensions.getCount(bunnies));

        List<String> expectedNames = Arrays.asList
                ("", "Zaik1", "WTFNAMETOOBIGCANTFIT", "a", "Nasko", "ZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZz");
        Iterator<Bunny> enumerator = bunnies.iterator();
        for (String name : expectedNames) {
            Bunny current = enumerator.next();
            Assert.assertEquals("Expected name did not match!", name, current.getName());
        }
    }

    @Category(CorrectnessTests.class)
    @Test
    public void ListBunniesBySuffix_WithMultipleBunniesInMultipleRoomsAndTeams_ShouldReturnAllBunniesWithGivenSuffix()
    {
        //Arange
        this.BunnyWarCollection.AddRoom(111);
        this.BunnyWarCollection.AddRoom(222);
        this.BunnyWarCollection.AddRoom(333);
        this.BunnyWarCollection.AddRoom(444);
        this.BunnyWarCollection.AddRoom(-111);
        this.BunnyWarCollection.AddBunny("aapen", 0, -111);
        this.BunnyWarCollection.AddBunny("bapen", 2, 222);
        this.BunnyWarCollection.AddBunny("Nasko", 4, 111);
        this.BunnyWarCollection.AddBunny("bpen", 0, 444);
        this.BunnyWarCollection.AddBunny("Tpen", 3, 222);
        this.BunnyWarCollection.AddBunny("Edo", 2, 111);
        this.BunnyWarCollection.AddBunny("Trifon", 1, 444);
        this.BunnyWarCollection.AddBunny("Royal", 1, -111);
        this.BunnyWarCollection.AddBunny("apen", 4, 333);
        this.BunnyWarCollection.AddBunny("Dancho", 4, 222);

        //Act
        Iterable<Bunny> bunnies = this.BunnyWarCollection.ListBunniesBySuffix("pen");

        //Assert
        Assert.assertEquals(5, IterableExtensions.getCount(bunnies));

        List<BunnyDto> expectedBunnies = Arrays.asList(
                new BunnyDto("Tpen", 100, 0, 3, 222),
                new BunnyDto("apen", 100, 0, 4, 333),
                new BunnyDto("aapen", 100, 0, 0, -111),
                new BunnyDto("bapen", 100, 0, 2, 222),
                new BunnyDto("bpen", 100, 0, 0, 444));

        TestUtils.assertBunniesAreSame(expectedBunnies, bunnies);
    }
}
