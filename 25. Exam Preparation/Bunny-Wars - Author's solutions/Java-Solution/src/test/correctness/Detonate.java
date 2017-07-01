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
        this.BunnyWarCollection.Detonate("Nasko");
    }

    @Category(CorrectnessTests.class)
    @Test
    public void Detonate_WithAValidBunny_ShouldNotHarmHimself()
    {
        //Arrange
        this.BunnyWarCollection.AddRoom(10);
        this.BunnyWarCollection.AddBunny("Nasko", 2, 10);

        //Act
        this.BunnyWarCollection.Detonate("Nasko");
        Iterable<Bunny> bunnies = this.BunnyWarCollection.ListBunniesByTeam(2);

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
        this.BunnyWarCollection.AddRoom(10);
        this.BunnyWarCollection.AddBunny("Nasko",2,10);
        this.BunnyWarCollection.AddBunny("Dancho", 2, 10);
        this.BunnyWarCollection.AddBunny("Royal", 2, 10);
        this.BunnyWarCollection.AddBunny("Edo", 2, 10);
        this.BunnyWarCollection.AddBunny("Trifon", 2, 10);

        //Act
        this.BunnyWarCollection.Detonate("Nasko");
        Iterable<Bunny> bunnies = this.BunnyWarCollection.ListBunniesByTeam(2);

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
        this.BunnyWarCollection.AddRoom(10);
        this.BunnyWarCollection.AddRoom(11);
        this.BunnyWarCollection.AddRoom(12);
        this.BunnyWarCollection.AddRoom(13);
        this.BunnyWarCollection.AddBunny("Nasko", 2, 10);
        this.BunnyWarCollection.AddBunny("Dancho", 0, 10);
        this.BunnyWarCollection.AddBunny("Royal", 2, 11);
        this.BunnyWarCollection.AddBunny("Edo", 3, 12);
        this.BunnyWarCollection.AddBunny("Trifon", 4, 13);

        //Act
        this.BunnyWarCollection.Detonate("Dancho");
        Iterable<Bunny> bunnies = this.BunnyWarCollection.ListBunniesByTeam(2);
        Iterable<Bunny> bunnies2 = this.BunnyWarCollection.ListBunniesByTeam(3);
        Iterable<Bunny> bunnies3 = this.BunnyWarCollection.ListBunniesByTeam(4);

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
        this.BunnyWarCollection.AddRoom(10);
        this.BunnyWarCollection.AddBunny("Nasko", 0, 10);
        this.BunnyWarCollection.AddBunny("Dancho", 1, 10);
        this.BunnyWarCollection.AddBunny("Royal", 2, 10);
        this.BunnyWarCollection.AddBunny("Edo", 3, 10);
        this.BunnyWarCollection.AddBunny("Trifon", 4, 10);

        //Act
        this.BunnyWarCollection.Detonate("Nasko");
        Iterable<Bunny> bunnies = this.BunnyWarCollection.ListBunniesByTeam(1);
        Iterable<Bunny> bunnies2 = this.BunnyWarCollection.ListBunniesByTeam(2);
        Iterable<Bunny> bunnies3 = this.BunnyWarCollection.ListBunniesByTeam(3);
        Iterable<Bunny> bunnies4 = this.BunnyWarCollection.ListBunniesByTeam(4);

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
        this.BunnyWarCollection.AddRoom(10);
        this.BunnyWarCollection.AddRoom(11);
        this.BunnyWarCollection.AddRoom(7);
        this.BunnyWarCollection.AddBunny("Nasko", 0, 10);
        this.BunnyWarCollection.AddBunny("Dancho", 1, 10);
        this.BunnyWarCollection.AddBunny("Royal", 2, 10);
        this.BunnyWarCollection.AddBunny("Edo", 3, 11);
        this.BunnyWarCollection.AddBunny("Trifon", 2, 7);
        Assert.assertEquals("Incorrect ammount of bunnies added!", 5, this.BunnyWarCollection.getBunnyCount());

        //Act
        this.BunnyWarCollection.Detonate("Nasko");
        this.BunnyWarCollection.Detonate("Nasko");
        this.BunnyWarCollection.Detonate("Nasko");
        this.BunnyWarCollection.Detonate("Nasko");

        //Assert
        Assert.assertEquals("Incorrect ammount of bunnies removed!", 3, this.BunnyWarCollection.getBunnyCount());
    }

    @Category(CorrectnessTests.class)
    @Test
    public void Detonate_WithMultipleBunnies_WhenABunnyFallsToZeroOrLessHealth_ShouldRemoveCorrectBunny()
    {
        //Arrange
        this.BunnyWarCollection.AddRoom(10);
        this.BunnyWarCollection.AddRoom(11);
        this.BunnyWarCollection.AddRoom(7);
        this.BunnyWarCollection.AddBunny("Nasko", 0, 10);
        this.BunnyWarCollection.AddBunny("Dancho", 1, 10);
        this.BunnyWarCollection.AddBunny("Royal", 2, 10);
        this.BunnyWarCollection.AddBunny("Edo", 3, 11);
        this.BunnyWarCollection.AddBunny("Trifon", 2, 7);

        //Act
        this.BunnyWarCollection.Detonate("Nasko");
        this.BunnyWarCollection.Detonate("Nasko");
        this.BunnyWarCollection.Detonate("Nasko");
        this.BunnyWarCollection.Detonate("Nasko");
        Bunny trifon = this.BunnyWarCollection.ListBunniesByTeam(2).iterator().next();
        Bunny edo = this.BunnyWarCollection.ListBunniesByTeam(3).iterator().next();

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
        this.BunnyWarCollection.AddRoom(10);
        this.BunnyWarCollection.AddBunny("Nasko", 0, 10);
        this.BunnyWarCollection.AddBunny("Dancho", 1, 10);
        this.BunnyWarCollection.AddBunny("Royal", 2, 10);

        //Act
        this.BunnyWarCollection.Detonate("Nasko");
        this.BunnyWarCollection.Detonate("Nasko");
        this.BunnyWarCollection.Detonate("Nasko");
        this.BunnyWarCollection.Detonate("Nasko");
        Bunny nasko = this.BunnyWarCollection.ListBunniesByTeam(0).iterator().next();

        //Assert
        Assert.assertEquals("Score did not match!", 2, nasko.getScore());
    }
}
