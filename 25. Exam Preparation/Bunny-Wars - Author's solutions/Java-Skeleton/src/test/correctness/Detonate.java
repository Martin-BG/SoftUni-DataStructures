package test.correctness;

import main.Bunny;
import org.junit.Assert;
import org.junit.Test;
import org.junit.experimental.categories.Category;
import test.helpers.BaseTest;
import test.types.CorrectnessTests;

public class Detonate extends BaseTest {

    @Category(CorrectnessTests.class)
    @Test(expected = IllegalArgumentException.class)
    public void Detonate_WithANonExistantBunny_ShouldThrowException()
    {
        //Act
        this.BunnyWarCollection.detonate("Nasko");
    }

    @Category(CorrectnessTests.class)
    @Test
    public void Detonate_WithAValidBunny_ShouldNotHarmHimself()
    {
        //Arrange
        this.BunnyWarCollection.addRoom(10);
        this.BunnyWarCollection.addBunny("Nasko", 2, 10);

        //Act
        this.BunnyWarCollection.detonate("Nasko");
        Iterable<Bunny> bunnies = this.BunnyWarCollection.listBunniesByTeam(2);

        //Assert
        for (Bunny bunny : bunnies)
        {
            Assert.assertEquals(100, bunny.getHealth());
        }
    }

    @Category(CorrectnessTests.class)
    @Test
    public void Detonate_WithBunniesFromTheSameTeam_ShouldNotHarmThem()
    {
        //Arrange
        this.BunnyWarCollection.addRoom(10);
        this.BunnyWarCollection.addBunny("Nasko", 2, 10);
        this.BunnyWarCollection.addBunny("Dancho", 2, 10);
        this.BunnyWarCollection.addBunny("Royal", 2, 10);
        this.BunnyWarCollection.addBunny("Edo", 2, 10);
        this.BunnyWarCollection.addBunny("Trifon", 2, 10);

        //Act
        this.BunnyWarCollection.detonate("Nasko");
        Iterable<Bunny> bunnies = this.BunnyWarCollection.listBunniesByTeam(2);

        //Assert
        for (Bunny bunny : bunnies)
        {
            Assert.assertEquals(100, bunny.getHealth());
        }
    }

    @Category(CorrectnessTests.class)
    @Test
    public void Detonate_WithBunniesInMultipleRooms_ShouldNotHarmBunniesInOtherRooms()
    {
        //Arrange
        this.BunnyWarCollection.addRoom(10);
        this.BunnyWarCollection.addRoom(11);
        this.BunnyWarCollection.addRoom(12);
        this.BunnyWarCollection.addRoom(13);
        this.BunnyWarCollection.addBunny("Nasko", 2, 10);
        this.BunnyWarCollection.addBunny("Dancho", 0, 10);
        this.BunnyWarCollection.addBunny("Royal", 2, 11);
        this.BunnyWarCollection.addBunny("Edo", 3, 12);
        this.BunnyWarCollection.addBunny("Trifon", 4, 13);

        //Act
        this.BunnyWarCollection.detonate("Dancho");
        Iterable<Bunny> bunnies = this.BunnyWarCollection.listBunniesByTeam(2);
        Iterable<Bunny> bunnies2 = this.BunnyWarCollection.listBunniesByTeam(3);
        Iterable<Bunny> bunnies3 = this.BunnyWarCollection.listBunniesByTeam(4);

        //Assert
        for (Bunny bunny : bunnies)
        {
            if (! bunny.getName().equals("Nasko"))
            {
                Assert.assertEquals(100, bunny.getHealth());
            }
            else
            {
                Assert.assertEquals(70, bunny.getHealth());
            }
        }

        for (Bunny bunny : bunnies2)
        {
            Assert.assertEquals(100, bunny.getHealth());
        }

        for (Bunny bunny : bunnies3)
        {
            Assert.assertEquals(100, bunny.getHealth());
        }
    }

    @Category(CorrectnessTests.class)
    @Test
    public void Detonate_WithBunniesFromOtherTeamsInTheSameRoom_ShouldReduceHealthOfBunniesFromOtherTeams()
    {
        //Arrange
        this.BunnyWarCollection.addRoom(10);
        this.BunnyWarCollection.addBunny("Nasko", 0, 10);
        this.BunnyWarCollection.addBunny("Dancho", 1, 10);
        this.BunnyWarCollection.addBunny("Royal", 2, 10);
        this.BunnyWarCollection.addBunny("Edo", 3, 10);
        this.BunnyWarCollection.addBunny("Trifon", 4, 10);

        //Act
        this.BunnyWarCollection.detonate("Nasko");
        Iterable<Bunny> bunnies = this.BunnyWarCollection.listBunniesByTeam(1);
        Iterable<Bunny> bunnies2 = this.BunnyWarCollection.listBunniesByTeam(2);
        Iterable<Bunny> bunnies3 = this.BunnyWarCollection.listBunniesByTeam(3);
        Iterable<Bunny> bunnies4 = this.BunnyWarCollection.listBunniesByTeam(4);

        //Assert
        for (Bunny bunny : bunnies)
        {
            Assert.assertEquals(70, bunny.getHealth());
        }

        for (Bunny bunny : bunnies2)
        {
            Assert.assertEquals(70, bunny.getHealth());
        }

        for (Bunny bunny : bunnies3)
        {
            Assert.assertEquals(70, bunny.getHealth());
        }

        for (Bunny bunny : bunnies4)
        {
            Assert.assertEquals(70, bunny.getHealth());
        }
    }

    @Category(CorrectnessTests.class)
    @Test
    public void Detonate_WithMultipleBunnies_WhenABunnyFallsToZeroOrLessHealth_ShouldRemoveBunny()
    {
        //Arrange
        this.BunnyWarCollection.addRoom(10);
        this.BunnyWarCollection.addRoom(11);
        this.BunnyWarCollection.addRoom(7);
        this.BunnyWarCollection.addBunny("Nasko", 0, 10);
        this.BunnyWarCollection.addBunny("Dancho", 1, 10);
        this.BunnyWarCollection.addBunny("Royal", 2, 10);
        this.BunnyWarCollection.addBunny("Edo", 3, 11);
        this.BunnyWarCollection.addBunny("Trifon", 2, 7);
        Assert.assertEquals("Incorrect ammount of bunnies added!", 5, this.BunnyWarCollection.getBunnyCount());

        //Act
        this.BunnyWarCollection.detonate("Nasko");
        this.BunnyWarCollection.detonate("Nasko");
        this.BunnyWarCollection.detonate("Nasko");
        this.BunnyWarCollection.detonate("Nasko");

        //Assert
        Assert.assertEquals("Incorrect ammount of bunnies removed!", 3, this.BunnyWarCollection.getBunnyCount());
    }

    @Category(CorrectnessTests.class)
    @Test
    public void Detonate_WithMultipleBunnies_WhenABunnyFallsToZeroOrLessHealth_ShouldRemoveCorrectBunny()
    {
        //Arrange
        this.BunnyWarCollection.addRoom(10);
        this.BunnyWarCollection.addRoom(11);
        this.BunnyWarCollection.addRoom(7);
        this.BunnyWarCollection.addBunny("Nasko", 0, 10);
        this.BunnyWarCollection.addBunny("Dancho", 1, 10);
        this.BunnyWarCollection.addBunny("Royal", 2, 10);
        this.BunnyWarCollection.addBunny("Edo", 3, 11);
        this.BunnyWarCollection.addBunny("Trifon", 2, 7);

        //Act
        this.BunnyWarCollection.detonate("Nasko");
        this.BunnyWarCollection.detonate("Nasko");
        this.BunnyWarCollection.detonate("Nasko");
        this.BunnyWarCollection.detonate("Nasko");
        Bunny trifon = this.BunnyWarCollection.listBunniesByTeam(2).iterator().next();
        Bunny edo = this.BunnyWarCollection.listBunniesByTeam(3).iterator().next();

        //Assert
        Assert.assertEquals("Name did not match!", "Trifon", trifon.getName());
        Assert.assertEquals("Health did not match!", 100, trifon.getHealth());
        Assert.assertEquals("Score did not match!", 0, trifon.getScore());
        Assert.assertEquals("Room Id did not match!", 7, trifon.getRoomId());
        Assert.assertEquals("Team did not match!", 2, trifon.getTeam());

        Assert.assertEquals("Name did not match!", "Edo", edo.getName());
        Assert.assertEquals("Health did not match!", 100, edo.getHealth());
        Assert.assertEquals("Score did not match!", 0, edo.getScore());
        Assert.assertEquals("Room Id did not match!", 11, edo.getRoomId());
        Assert.assertEquals("Team did not match!", 3, edo.getTeam());
    }

    @Category(CorrectnessTests.class)
    @Test
    public void Detonate_WhenKillingABunny_ShouldShouldIncreaseDetonatedBunnysScore()
    {
        //Arrange
        this.BunnyWarCollection.addRoom(10);
        this.BunnyWarCollection.addBunny("Nasko", 0, 10);
        this.BunnyWarCollection.addBunny("Dancho", 1, 10);
        this.BunnyWarCollection.addBunny("Royal", 2, 10);

        //Act
        this.BunnyWarCollection.detonate("Nasko");
        this.BunnyWarCollection.detonate("Nasko");
        this.BunnyWarCollection.detonate("Nasko");
        this.BunnyWarCollection.detonate("Nasko");
        Bunny nasko = this.BunnyWarCollection.listBunniesByTeam(0).iterator().next();

        //Assert
        Assert.assertEquals("Score did not match!", 2, nasko.getScore());
    }
}
