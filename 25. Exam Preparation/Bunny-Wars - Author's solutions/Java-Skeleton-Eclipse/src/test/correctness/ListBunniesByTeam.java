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

public class ListBunniesByTeam extends BaseTest {

    @Category(CorrectnessTests.class)
    @Test(expected = IndexOutOfBoundsException.class)
    public void ListBunniesByTeam_WithANegativeTeam_ShouldThrowException()
    {
        //Act
        this.BunnyWarCollection.listBunniesByTeam(-555);
    }

    @Category(CorrectnessTests.class)
    @Test(expected = IndexOutOfBoundsException.class)
    public void ListBunniesByTeam_WithAnIncorrectTeam_ShouldThrowException()
    {
        //Act
        this.BunnyWarCollection.listBunniesByTeam(5);
    }

    @Category(CorrectnessTests.class)
    @Test
    public void ListBunniesByTeam_WithASingleTeam_ShouldReturnCorrectAmmounOfBunnies()
    {
        //Arrange
        this.BunnyWarCollection.addRoom(2);
        this.BunnyWarCollection.addBunny("Nasko", 4, 2);
        this.BunnyWarCollection.addBunny("Edo", 4, 2);
        this.BunnyWarCollection.addBunny("Royal", 4, 2);
        this.BunnyWarCollection.addBunny("Dancho", 4, 2);
        this.BunnyWarCollection.addBunny("Trifon", 4, 2);

        //Act
        Iterable<Bunny> bunnies = this.BunnyWarCollection.listBunniesByTeam(4);

        //Assert
        Assert.assertEquals("Incorrect amount of bunnies returned!",
                5,
                IterableExtensions.getCount(bunnies));
    }

    @Category(CorrectnessTests.class)
    @Test
    public void ListBunniesByTeam_WithMultipleTeams_ShouldReturnCorrectAmmounOfBunnies()
    {
        //Arrange
        this.BunnyWarCollection.addRoom(2);
        this.BunnyWarCollection.addBunny("Nasko", 1, 2);
        this.BunnyWarCollection.addBunny("Edo", 2, 2);
        this.BunnyWarCollection.addBunny("Royal", 1, 2);
        this.BunnyWarCollection.addBunny("Dancho", 4, 2);
        this.BunnyWarCollection.addBunny("Trifon", 4, 2);

        //Act
        Iterable<Bunny> bunnies = this.BunnyWarCollection.listBunniesByTeam(1);

        //Assert
        Assert.assertEquals("Incorrect amount of bunnies returned!",
                2,
                IterableExtensions.getCount(bunnies));
    }

    @Category(CorrectnessTests.class)
    @Test
    public void ListBunniesByTeam_ShouldReturnCorrectlySortedBunnies()
    {
        //Arrange
        this.BunnyWarCollection.addRoom(2);
        this.BunnyWarCollection.addRoom(-1);
        this.BunnyWarCollection.addRoom(-7);
        this.BunnyWarCollection.addBunny("Nasko", 4, -1);
        this.BunnyWarCollection.addBunny("Edo", 4, 2);
        this.BunnyWarCollection.addBunny("Royal", 4, -7);
        this.BunnyWarCollection.addBunny("Dancho", 4, 2);
        this.BunnyWarCollection.addBunny("Trifon", 3, -1);

        //Act
        Iterable<Bunny> bunnies = this.BunnyWarCollection.listBunniesByTeam(4);

        //Assert
        List<String> expectedNames = Arrays.asList("Royal", "Nasko", "Edo", "Dancho");
        Iterator<Bunny> enumerator = bunnies.iterator();
        for (String name : expectedNames) {
            Bunny current = enumerator.next();
            Assert.assertEquals(current.getName(), name);
        }
    }

    @Category(CorrectnessTests.class)
    @Test
    public void ListBunniesByTeam_WithASingleRoomWithASingleTeam_ShouldReturnCorrectBunnies()
    {
        //Arrange
        this.BunnyWarCollection.addRoom(2);
        this.BunnyWarCollection.addBunny("Nasko", 4, 2);
        this.BunnyWarCollection.addBunny("Edo", 4, 2);
        this.BunnyWarCollection.addBunny("Royal", 4, 2);
        this.BunnyWarCollection.addBunny("Dancho", 4, 2);
        this.BunnyWarCollection.addBunny("Trifon", 4, 2);

        //Act
        Iterable<Bunny> bunnies = this.BunnyWarCollection.listBunniesByTeam(4);

        //Assert
        List<BunnyDto> expectedBunnies = Arrays.asList(
                new BunnyDto("Trifon", 100, 0, 4, 2),
                new BunnyDto("Royal", 100, 0, 4, 2),
                new BunnyDto("Nasko", 100, 0, 4, 2),
                new BunnyDto("Edo", 100, 0, 4, 2),
                new BunnyDto("Dancho", 100, 0, 4, 2));

        TestUtils.assertBunniesAreSame(expectedBunnies, bunnies);
    }

    @Category(CorrectnessTests.class)
    @Test
    public void ListBunniesByTeam_WithASingleRoomWithMultipleTeams_ShouldReturnCorrectBunnies()
    {
        //Arrange
        this.BunnyWarCollection.addRoom(-50);
        this.BunnyWarCollection.addBunny("Nasko", 1, -50);
        this.BunnyWarCollection.addBunny("Edo", 2, -50);
        this.BunnyWarCollection.addBunny("Royal", 1, -50);
        this.BunnyWarCollection.addBunny("Dancho", 4, -50);
        this.BunnyWarCollection.addBunny("Trifon", 4, -50);

        //Act
        Iterable<Bunny> bunnies = this.BunnyWarCollection.listBunniesByTeam(1);
        List<BunnyDto> expectedBunnies = Arrays.asList(
                new BunnyDto("Royal", 100, 0, 1, -50),
                new BunnyDto("Nasko", 100, 0, 1, -50));

        TestUtils.assertBunniesAreSame(expectedBunnies, bunnies);
    }

    @Category(CorrectnessTests.class)
    @Test
    public void ListBunniesByTeam_WithMultipleTeamsInMultipleRooms_ShouldReturnCorrectBunnies()
    {
        //Arrange
        this.BunnyWarCollection.addRoom(-99);
        this.BunnyWarCollection.addRoom(200);
        this.BunnyWarCollection.addRoom(1337);
        this.BunnyWarCollection.addBunny("Nasko", 3, 200);
        this.BunnyWarCollection.addBunny("Edo", 2, 1337);
        this.BunnyWarCollection.addBunny("Royal", 4, -99);
        this.BunnyWarCollection.addBunny("Dancho", 1, -99);
        this.BunnyWarCollection.addBunny("Trifon", 3, 1337);
        this.BunnyWarCollection.addBunny("Ivo", 3, 200);
        this.BunnyWarCollection.addBunny("Joro", 3, -99);
        //Act
        Iterable<Bunny> bunnies = this.BunnyWarCollection.listBunniesByTeam(3);

        //Assert
        List<BunnyDto> expectedBunnies = Arrays.asList(
                new BunnyDto("Trifon", 100, 0, 3, 1337),
                new BunnyDto("Nasko", 100, 0, 3, 200),
                new BunnyDto("Joro", 100, 0, 3, -99),
                new BunnyDto("Ivo", 100, 0, 3, 200));

        TestUtils.assertBunniesAreSame(expectedBunnies, bunnies);
    }
}
