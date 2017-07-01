package test.correctness;

import org.junit.Assert;
import org.junit.Test;
import org.junit.experimental.categories.Category;
import test.helpers.BaseTest;
import test.helpers.IterableExtensions;
import test.types.CorrectnessTests;

import java.util.Arrays;
import java.util.List;


public class GetChildren extends BaseTest {

    @Category(CorrectnessTests.class)
    @Test(expected = IllegalArgumentException.class)
    public void GetChildren_WithNonExistantElement_ShouldThrowException()
    {
        this.Hierarchy.GetParent(-17);
    }

    @Category(CorrectnessTests.class)
    @Test
    public void GetChildren_WithAnElementWithNoChildren_ShouldReturnEmptyCollection()
    {
        this.Hierarchy.Add(DefaultRootValue,13);
        this.Hierarchy.Add(DefaultRootValue, 14);
        this.Hierarchy.Add(13, 17);
        this.Hierarchy.Add(13, -666);

        Iterable<Integer> children = this.Hierarchy.GetChildren(-666);

        Assert.assertEquals(0, IterableExtensions.getCount(children));
    }

    @Category(CorrectnessTests.class)
    @Test
    public void GetChildren_WithAnElementWithOneChild_ShouldReturnACollectionWithOneElement()
    {
        this.Hierarchy.Add(DefaultRootValue, 55);
        this.Hierarchy.Add(DefaultRootValue, 10);
        this.Hierarchy.Add(55, 17);
        this.Hierarchy.Add(55, 18);
        this.Hierarchy.Add(10, -666);

        Iterable<Integer> children = this.Hierarchy.GetChildren(10);
        List<Integer> result = IterableExtensions.toList(children);

        Assert.assertTrue(result.equals(Arrays.asList(-666)));
    }

    @Category(CorrectnessTests.class)
    @Test
    public void GetChildren_WithAnElementWithMultipleChildren_ShouldReturnACorrectCollection()
    {
        this.Hierarchy.Add(DefaultRootValue, 25);
        this.Hierarchy.Add(DefaultRootValue, 110);
        this.Hierarchy.Add(25, -10);
        this.Hierarchy.Add(110, 22);
        this.Hierarchy.Add(110, 333);
        this.Hierarchy.Add(110, 15);
        this.Hierarchy.Add(110, 99);
        this.Hierarchy.Add(99, 1);

        Iterable<Integer> children = this.Hierarchy.GetChildren(110);
        List<Integer> result = IterableExtensions.toList(children);

        Assert.assertTrue(result.equals(Arrays.asList(22, 333, 15, 99)));
    }
}
