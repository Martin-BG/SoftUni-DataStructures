package test.correctness;

import main.Bunny;
import org.junit.Assert;
import org.junit.Test;
import org.junit.experimental.categories.Category;
import test.helpers.BaseTest;
import test.types.CorrectnessTests;

public class AddBunny extends BaseTest {

    @Category(CorrectnessTests.class)
    @Test(expected = IllegalArgumentException.class)
    public void AddBunny_ToANonExistingRoom_ShouldThrowException() {
         this.BunnyWarCollection.AddBunny("Ivo", 0, 15);
    }

    @Category(CorrectnessTests.class)
    @Test(expected = IllegalArgumentException.class)
    public void AddBunny_WithAnExistingName_ShouldThrowException()
    {
        //Arrange
        int roomId = 15;
        this.BunnyWarCollection.AddRoom(roomId);
        this.BunnyWarCollection.AddBunny("Nasko", 0, 15);

        //Act
        this.BunnyWarCollection.AddBunny("Nasko", 0, 15);
    }

    @Category(CorrectnessTests.class)
    @Test(expected = IndexOutOfBoundsException.class)
    public void AddBunny_WithANegativeTeamId_ShouldThrowException()
    {
        //Arrange
        int roomId = 15;
        this.BunnyWarCollection.AddRoom(roomId);

        //Act
        this.BunnyWarCollection.AddBunny("Zuek1", -1, 15);
    }

    @Category(CorrectnessTests.class)
    @Test(expected = IndexOutOfBoundsException.class)
    public void AddBunny_WithAnIncorrectTeamId_ShouldThrowException()
    {
        //Arrange
        int roomId = 15;
        this.BunnyWarCollection.AddRoom(roomId);

        //Act
        this.BunnyWarCollection.AddBunny("Zuek1", 5, 15);
    }

    @Category(CorrectnessTests.class)
    @Test
    public void AddBunny_WithNoBunnies_ShouldIncreaseBunnyCountByOnce()
    {
        //Arrange
        int roomId = 15;
        this.BunnyWarCollection.AddRoom(roomId);
        Assert.assertEquals("Collection created with an incorrect amount of bunnies!",
                0,
                this.BunnyWarCollection.getBunnyCount());

        //Act
        this.BunnyWarCollection.AddBunny("Nasko", 0, 15);

        //Assert
        Assert.assertEquals("Incorrect amount of bunnies added!",
                1,
                this.BunnyWarCollection.getBunnyCount());
    }

    @Category(CorrectnessTests.class)
    @Test
    public void AddBunny_WithExistingBunnies_ShouldIncreaseBunnyCountByOne()
    {
        //Arrange
        int roomId = 15;
        this.BunnyWarCollection.AddRoom(roomId);
        this.BunnyWarCollection.AddBunny("Nasko", 0, 15);
        this.BunnyWarCollection.AddBunny("Dancho", 1, 15);
        this.BunnyWarCollection.AddBunny("Ivo", 2, 15);
        this.BunnyWarCollection.AddBunny("Edo", 3, 15);
        this.BunnyWarCollection.AddBunny("Royal", 4, 15);
        this.BunnyWarCollection.AddBunny("Trifon", 0, 15);
        Assert.assertEquals("Incorrect amount of bunnies!",
                6,
                this.BunnyWarCollection.getBunnyCount());

        //Act
        this.BunnyWarCollection.AddBunny("Nakov", 1, 15);

        //Assert
        Assert.assertEquals("Incorrect amount of bunnies added!",
                7,
                this.BunnyWarCollection.getBunnyCount());
    }

    @Category(CorrectnessTests.class)
    @Test
    public void AddBunny_WithNoBunnies_ShouldAddBunnyWithCorrectParameters()
    {
        //Arrange
        int roomId = 15;
        this.BunnyWarCollection.AddRoom(roomId);

        //Act
        this.BunnyWarCollection.AddBunny("Nasko", 3, 15);
        Iterable<Bunny> bunnies = this.BunnyWarCollection.ListBunniesByTeam(3);
        Bunny bunny = bunnies.iterator().next();

        //Assert
        Assert.assertEquals("Name did not match!", "Nasko", bunny.getName());
        Assert.assertEquals("Team did not match!", 3, bunny.getTeam());
        Assert.assertEquals("Room Id did not match!", 15, bunny.getRoomId());
        Assert.assertEquals("Health did not match!", 100, bunny.getHealth());
        Assert.assertEquals("Score did not match!", 0, bunny.getScore());
    }
}
