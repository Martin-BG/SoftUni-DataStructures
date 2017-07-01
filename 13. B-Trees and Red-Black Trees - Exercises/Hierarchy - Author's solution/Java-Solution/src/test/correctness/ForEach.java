package test.correctness;

import org.junit.Assert;
import org.junit.Test;
import org.junit.experimental.categories.Category;
import test.helpers.BasePerformanceTest;
import test.helpers.BaseTest;
import test.types.CorrectnessTests;

public class ForEach extends BaseTest {

    @Category(CorrectnessTests.class)
    @Test
    public void ForEach_WithOnlyRoot_ShouldIterateOnlyThroughRoot()
    {
        int count = 0;
        int[] collection = new int[] { DefaultRootValue };
        for (int element : this.Hierarchy)
        {
            Assert.assertEquals(collection[count++], element);
        }
    }

    @Category(CorrectnessTests.class)
    @Test
    public void ForEach_WithMultipleElements_ShouldIterateOverCollectionOnlyOnce()
    {
        int count = 0;
        this.Hierarchy.Add(DefaultRootValue, 50);
        this.Hierarchy.Add(DefaultRootValue, 70);
        this.Hierarchy.Add(70, 100);
        this.Hierarchy.Add(50, 200);
        this.Hierarchy.Add(70, 120);
        this.Hierarchy.Add(70, 110);
        this.Hierarchy.Add(110, 0);
        this.Hierarchy.Add(200, 201);
        this.Hierarchy.Add(201, 202);
        this.Hierarchy.Add(50, 300);
        int[] collection = new int[] { DefaultRootValue, 50, 70, 200, 300, 100, 120, 110, 201, 0, 202 };

        for (int element : this.Hierarchy)
        {
            Assert.assertEquals(collection[count++], element);
        }

        Assert.assertEquals(count, this.Hierarchy.getCount());
    }

    @Category(CorrectnessTests.class)
    @Test
    public void ForEach_WithMultipleElements_ShouldIterateThroughThemInCorrectOrder()
    {
        this.Hierarchy.Add(DefaultRootValue, -10);
        this.Hierarchy.Add(DefaultRootValue, 10);
        this.Hierarchy.Add(-10, -11);
        this.Hierarchy.Add(-10, -12);
        this.Hierarchy.Add(10, 11);
        this.Hierarchy.Add(10, 12);
        this.Hierarchy.Add(-11, -13);
        this.Hierarchy.Add(-11, -14);
        this.Hierarchy.Add(-12, -15);
        this.Hierarchy.Add(-12, -16);
        this.Hierarchy.Add(11, 13);
        int count = 0;
        int[] collection = new int[] { DefaultRootValue, -10, 10, -11, -12, 11, 12, -13, -14, -15, -16, 13 };
        for (int element : this.Hierarchy)
        {
            Assert.assertEquals(collection[count++], element);
        }
    }
}
