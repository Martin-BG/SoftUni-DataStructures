package test.correctness;

import org.junit.Assert;
import org.junit.Test;
import org.junit.experimental.categories.Category;
import test.helpers.BaseTest;
import test.helpers.IterableExtensions;
import test.types.CorrectnessTests;

import java.util.Arrays;
import java.util.List;

public class Remove extends BaseTest {

    @Category(CorrectnessTests.class)
    @Test(expected = IllegalArgumentException.class)
    public void Remove_WithNonExistantElement_ShouldThrowException()
    {
        int nonExistingElement = 7;
        this.Hierarchy.Remove(nonExistingElement);
    }

    @Category(CorrectnessTests.class)
    @Test(expected = IllegalStateException.class)
    public void Remove_WithRootElement_ShouldThrowException()
    {
        this.Hierarchy.Remove(DefaultRootValue);
    }

    @Category(CorrectnessTests.class)
    @Test
    public void Remove_WithOneElement_ShouldDecreaseCountByOne()
    {
        this.Hierarchy.Add(DefaultRootValue,2);

        this.Hierarchy.Remove(2);

        Assert.assertEquals(1, this.Hierarchy.getCount());
    }

    @Category(CorrectnessTests.class)
    @Test
    public void Remove_WithElementWithChildren_ShouldDecreaseCountCorrectly()
    {
        this.Hierarchy.Add(DefaultRootValue, 10);
        this.Hierarchy.Add(DefaultRootValue, 11);
        this.Hierarchy.Add(10, 12);
        this.Hierarchy.Add(10, 13);
        this.Hierarchy.Add(11, 14);
        Assert.assertEquals(6, this.Hierarchy.getCount());

        this.Hierarchy.Remove(10);

        Assert.assertEquals(5, this.Hierarchy.getCount());
    }

    @Category(CorrectnessTests.class)
    @Test
    public void Remove_WithElementWithNoChildren_ShouldRemoveElementCorrectly()
    {
        this.Hierarchy.Add(DefaultRootValue, 2);
        this.Hierarchy.Add(2, 3);

        this.Hierarchy.Remove(3);

        Assert.assertFalse(this.Hierarchy.Contains(3));
        Assert.assertFalse(IterableExtensions.contains(this.Hierarchy.GetChildren(2), 3));
    }

    @Category(CorrectnessTests.class)
    @Test
    public void Remove_WithElementWithChildren_ShouldAttachChildrenToRemovedElementsParent()
    {
        this.Hierarchy.Add(DefaultRootValue, 10);
        this.Hierarchy.Add(DefaultRootValue, 11);
        this.Hierarchy.Add(10, 12);
        this.Hierarchy.Add(10, 13);
        this.Hierarchy.Add(11, 14);

        this.Hierarchy.Remove(10);

        Assert.assertEquals(DefaultRootValue, (int)this.Hierarchy.GetParent(12));
        Assert.assertEquals(DefaultRootValue, (int)this.Hierarchy.GetParent(13));

        Iterable<Integer> rootChildren = this.Hierarchy.GetChildren(DefaultRootValue);
        List<Integer> result = IterableExtensions.toList(rootChildren);
        Assert.assertTrue(result.equals(Arrays.asList(11, 12, 13)));
    }
}
