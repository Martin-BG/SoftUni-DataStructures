package test.correctness;

import main.Bunny;
import org.junit.Assert;
import org.junit.Test;
import org.junit.experimental.categories.Category;
import test.helpers.BaseTest;
import test.types.CorrectnessTests;

public class Next extends BaseTest {

    @Category(CorrectnessTests.class)
    @Test(expected = IllegalArgumentException.class)
    public void Next_WithANonExistantBunny_ShouldThrowException()
    {
        //Act
        this.BunnyWarCollection.Next("Nasko");
    }

    @Category(CorrectnessTests.class)
    @Test
    public void Next_WithASingleRoom_ShouldStayInTheSameRoom()
    {
        //Arrange
        this.BunnyWarCollection.AddRoom(1);
        this.BunnyWarCollection.AddBunny("Nasko", 3, 1);

        //Act
        this.BunnyWarCollection.Next("Nasko");
        Iterable<Bunny> bunnies = this.BunnyWarCollection.ListBunniesByTeam(3);
        Bunny bunny = bunnies.iterator().next();

        //Assert
        Assert.assertEquals("Room Id was incorrect!", 1, bunny.getRoomId());
    }

    @Category(CorrectnessTests.class)
    @Test
    public void Next_WithMultipleRooms_ShouldMoveBunnyToNextRoom()
    {
        //Arrange
        this.BunnyWarCollection.AddRoom(1);
        this.BunnyWarCollection.AddRoom(5);
        this.BunnyWarCollection.AddBunny("Nasko", 3, 1);

        //Act
        this.BunnyWarCollection.Next("Nasko");
        Iterable<Bunny> bunnies = this.BunnyWarCollection.ListBunniesByTeam(3);
        Bunny bunny = bunnies.iterator().next();

        //Assert
        Assert.assertEquals("Room Id was incorrect!", 5, bunny.getRoomId());
    }

    @Category(CorrectnessTests.class)
    @Test
    public void Next_WithBunnyInTheLastRoom_ShouldMoveBunnyToTheFirstRoom()
    {
        //Arrange
        this.BunnyWarCollection.AddRoom(-20);
        this.BunnyWarCollection.AddRoom(1);
        this.BunnyWarCollection.AddRoom(5);
        this.BunnyWarCollection.AddRoom(20);
        this.BunnyWarCollection.AddRoom(100);
        this.BunnyWarCollection.AddRoom(666);
        this.BunnyWarCollection.AddBunny("Nasko", 2, 666);

        //Act
        this.BunnyWarCollection.Next("Nasko");
        Iterable<Bunny> bunnies = this.BunnyWarCollection.ListBunniesByTeam(2);
        Bunny bunny = bunnies.iterator().next();

        //Assert
        Assert.assertEquals("Room Id was incorrect!", -20, bunny.getRoomId());
    }
}
