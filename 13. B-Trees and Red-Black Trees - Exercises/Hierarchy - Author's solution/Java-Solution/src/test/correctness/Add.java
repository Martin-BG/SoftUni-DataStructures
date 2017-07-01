package test.correctness;

import org.junit.Assert;
import org.junit.Test;
import org.junit.experimental.categories.Category;
import org.junit.internal.runners.TestMethod;
import test.helpers.BaseTest;
import test.types.CorrectnessTests;

import java.util.Iterator;

public class Add extends BaseTest {

    @Category(CorrectnessTests.class)
    @Test(expected = IllegalArgumentException.class)
    public void Add_WithDuplicateElement_ShouldThrowException()
    {
        this.Hierarchy.Add(DefaultRootValue, 2);
        this.Hierarchy.Add(DefaultRootValue, 3);
        this.Hierarchy.Add(3, 2);
    }

    @Category(CorrectnessTests.class)
    @Test(expected = IllegalArgumentException.class)
    public void Add_ToNonExistingElement_ShouldThrowException()
    {
        this.Hierarchy.Add(DefaultRootValue + 1, 2);
    }

    @Category(CorrectnessTests.class)
    @Test
    public void Add_WithSingleElement_ShouldIncrementCountByOne()
    {
        this.Hierarchy.Add(DefaultRootValue, 2);
        Assert.assertEquals(2, this.Hierarchy.getCount());
    }

    @Category(CorrectnessTests.class)
    @Test
    public void Add_WithMultipleElements_ShouldIncrementCountCorrectly()
    {
        int[] elementsToAdd = new int[] { 3, 2, 7 };

        this.Hierarchy.Add(DefaultRootValue, elementsToAdd[0]);
        this.Hierarchy.Add(DefaultRootValue, elementsToAdd[1]);
        this.Hierarchy.Add(elementsToAdd[1], elementsToAdd[2]);

        Assert.assertEquals(1 + elementsToAdd.length, this.Hierarchy.getCount());
    }

    @Category(CorrectnessTests.class)
    @Test
    public void Add_WithSingleElement_ShouldAddCorrectElement()
    {
        Assert.assertFalse(this.Hierarchy.Contains(2));

        this.Hierarchy.Add(DefaultRootValue, 2);

        Assert.assertTrue(this.Hierarchy.Contains(2));
    }

    @Category(CorrectnessTests.class)
    @Test
    public void Add_WithSingleElement_ShouldCorrectlySetElementsParent()
    {
        this.Hierarchy.Add(DefaultRootValue, 111);
        this.Hierarchy.Add(111, 222);

        Assert.assertEquals(111, (int)this.Hierarchy.GetParent(222));
    }

    @Category(CorrectnessTests.class)
    @Test
    public void Add_WithMultipleElements_ShouldAddElementAtCorrectPlace()
    {
        this.Hierarchy.Add(DefaultRootValue, 6);
        this.Hierarchy.Add(DefaultRootValue, 2);
        this.Hierarchy.Add(6, 13);
        this.Hierarchy.Add(2, 7);
        this.Hierarchy.Add(7, 22);

        this.Hierarchy.Add(7, 25);

        Iterator<Integer> iterator = this.Hierarchy.GetChildren(7).iterator();
        iterator.next();
        Assert.assertEquals("Element wasn't added at correct place!", 25, (int)iterator.next());
    }

    @Category(CorrectnessTests.class)
    @Test
    public void Add_WithAddAfterRemoving_ShouldAddCorrectly()
    {
        this.Hierarchy.Add(DefaultRootValue, 2);
        this.Hierarchy.Remove(2);
        Assert.assertEquals(1, this.Hierarchy.getCount());

        this.Hierarchy.Add(DefaultRootValue, 2);

        Assert.assertEquals(2, this.Hierarchy.getCount());
    }
}
