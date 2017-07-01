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
        this.BunnyWarCollection.addRoom(88);
        this.BunnyWarCollection.addBunny("b", 0, 88);
        this.BunnyWarCollection.addBunny("e", 0, 88);
        this.BunnyWarCollection.addBunny("a", 0, 88);
        this.BunnyWarCollection.addBunny("c", 0, 88);
        this.BunnyWarCollection.addBunny("d", 0, 88);
        this.BunnyWarCollection.addBunny("Nasko", 0, 88);

        //Act
        Iterable<Bunny> bunnies = this.BunnyWarCollection.listBunniesBySuffix("");

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
        this.BunnyWarCollection.addRoom(20);
        this.BunnyWarCollection.addRoom(21);
        this.BunnyWarCollection.addRoom(22);
        this.BunnyWarCollection.addBunny("Nasko", 1, 22);
        this.BunnyWarCollection.addBunny("Dancho", 3, 20);
        this.BunnyWarCollection.addBunny("Royal", 1, 21);
        this.BunnyWarCollection.addBunny("Edo", 4, 22);
        this.BunnyWarCollection.addBunny("Vitkurz", 4, 22);
        this.BunnyWarCollection.addBunny("Trifon", 2, 21);
        this.BunnyWarCollection.addBunny("Ivo", 3, 21);

        //Act
        Iterable<Bunny> bunnies = this.BunnyWarCollection.listBunniesBySuffix("o");

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
        Iterable<Bunny> bunnies = this.BunnyWarCollection.listBunniesBySuffix("");

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
        this.BunnyWarCollection.addRoom(88);
        this.BunnyWarCollection.addRoom(89);
        this.BunnyWarCollection.addRoom(90);
        this.BunnyWarCollection.addBunny("Nasko", 0, 89);
        this.BunnyWarCollection.addBunny("Edo", 1, 89);
        this.BunnyWarCollection.addBunny("Dancho", 1, 88);
        this.BunnyWarCollection.addBunny("Zaik1", 0, 90);
        this.BunnyWarCollection.addBunny("Nasklo", 1, 89);
        this.BunnyWarCollection.addBunny("Edu", 0, 88);
        this.BunnyWarCollection.addBunny("RoYaL", 1, 90);

        //Act
        Iterable<Bunny> bunnies = this.BunnyWarCollection.listBunniesBySuffix("AmiSega");

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
        this.BunnyWarCollection.addRoom(88);
        this.BunnyWarCollection.addBunny("Zaik1", 0, 88);
        this.BunnyWarCollection.addBunny("", 0, 88);
        this.BunnyWarCollection.addBunny("a", 0, 88);
        this.BunnyWarCollection.addBunny("WTFNAMETOOBIGCANTFIT", 0, 88);
        this.BunnyWarCollection.addBunny("ZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZzZz", 0, 88);
        this.BunnyWarCollection.addBunny("Nasko", 0, 88);

        //Act
        Iterable<Bunny> bunnies = this.BunnyWarCollection.listBunniesBySuffix("");

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
        this.BunnyWarCollection.addRoom(111);
        this.BunnyWarCollection.addRoom(222);
        this.BunnyWarCollection.addRoom(333);
        this.BunnyWarCollection.addRoom(444);
        this.BunnyWarCollection.addRoom(-111);
        this.BunnyWarCollection.addBunny("aapen", 0, -111);
        this.BunnyWarCollection.addBunny("bapen", 2, 222);
        this.BunnyWarCollection.addBunny("Nasko", 4, 111);
        this.BunnyWarCollection.addBunny("bpen", 0, 444);
        this.BunnyWarCollection.addBunny("Tpen", 3, 222);
        this.BunnyWarCollection.addBunny("Edo", 2, 111);
        this.BunnyWarCollection.addBunny("Trifon", 1, 444);
        this.BunnyWarCollection.addBunny("Royal", 1, -111);
        this.BunnyWarCollection.addBunny("apen", 4, 333);
        this.BunnyWarCollection.addBunny("Dancho", 4, 222);

        //Act
        Iterable<Bunny> bunnies = this.BunnyWarCollection.listBunniesBySuffix("pen");

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
