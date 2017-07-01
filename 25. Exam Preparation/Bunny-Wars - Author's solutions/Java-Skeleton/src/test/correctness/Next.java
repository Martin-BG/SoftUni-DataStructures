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
        this.BunnyWarCollection.next("Nasko");
    }

    @Category(CorrectnessTests.class)
    @Test
    public void Next_WithASingleRoom_ShouldStayInTheSameRoom()
    {
        //Arrange
        this.BunnyWarCollection.addRoom(1);
        this.BunnyWarCollection.addBunny("Nasko", 3, 1);

        //Act
        this.BunnyWarCollection.next("Nasko");
        Iterable<Bunny> bunnies = this.BunnyWarCollection.listBunniesByTeam(3);
        Bunny bunny = bunnies.iterator().next();

        //Assert
        Assert.assertEquals("Room Id was incorrect!", 1, bunny.getRoomId());
    }

    @Category(CorrectnessTests.class)
    @Test
    public void Next_WithMultipleRooms_ShouldMoveBunnyToNextRoom()
    {
        //Arrange
        this.BunnyWarCollection.addRoom(1);
        this.BunnyWarCollection.addRoom(5);
        this.BunnyWarCollection.addBunny("Nasko", 3, 1);

        //Act
        this.BunnyWarCollection.next("Nasko");
        Iterable<Bunny> bunnies = this.BunnyWarCollection.listBunniesByTeam(3);
        Bunny bunny = bunnies.iterator().next();

        //Assert
        Assert.assertEquals("Room Id was incorrect!", 5, bunny.getRoomId());
    }

    @Category(CorrectnessTests.class)
    @Test
    public void Next_WithBunnyInTheLastRoom_ShouldMoveBunnyToTheFirstRoom()
    {
        //Arrange
        this.BunnyWarCollection.addRoom(-20);
        this.BunnyWarCollection.addRoom(1);
        this.BunnyWarCollection.addRoom(5);
        this.BunnyWarCollection.addRoom(20);
        this.BunnyWarCollection.addRoom(100);
        this.BunnyWarCollection.addRoom(666);
        this.BunnyWarCollection.addBunny("Nasko", 2, 666);

        //Act
        this.BunnyWarCollection.next("Nasko");
        Iterable<Bunny> bunnies = this.BunnyWarCollection.listBunniesByTeam(2);
        Bunny bunny = bunnies.iterator().next();

        //Assert
        Assert.assertEquals("Room Id was incorrect!", -20, bunny.getRoomId());
    }
}
