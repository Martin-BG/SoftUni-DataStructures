package test.performance;

import org.junit.Assert;
import org.junit.Test;
import org.junit.experimental.categories.Category;
import test.helpers.BasePerformanceTest;
import test.types.PerformanceTests;

public class AddRoomPerformance extends BasePerformanceTest {
    @Category(PerformanceTests.class)
    @Test(timeout = 250)
    public void PerformanceAddRoom_With50000Rooms()
    {
        //Arrange
        int count = 1;
        int roomsCount = 50000;

        //Act
        for (int i = 0; i < roomsCount; i++)
        {
            this.BunnyWarCollection.addRoom(i);
            Assert.assertEquals("Incorrect count of rooms after adding!", count++, this.BunnyWarCollection.getRoomCount());
        }
    }

}
