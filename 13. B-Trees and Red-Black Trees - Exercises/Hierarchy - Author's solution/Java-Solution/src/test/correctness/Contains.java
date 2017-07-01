package test.correctness;

import org.junit.Assert;
import org.junit.Test;
import org.junit.experimental.categories.Category;
import test.helpers.BaseTest;
import test.types.CorrectnessTests;

public class Contains extends BaseTest {

    @Category(CorrectnessTests.class)
    @Test
    public void Contains_WithANonExistantElement_ShouldReturnFalse()
    {
        boolean result = this.Hierarchy.Contains(1);

        Assert.assertFalse(result);
    }

    @Category(CorrectnessTests.class)
    @Test
    public void Contains_WithASingleElement_ShouldReturnTrue()
    {
        boolean result = this.Hierarchy.Contains(DefaultRootValue);

        Assert.assertTrue(result);
    }

    @Category(CorrectnessTests.class)
    @Test
    public void Contains_WithMultipleSearchesForASingleElement_ShouldReturnConsistentResult()
    {
        this.Hierarchy.Add(DefaultRootValue, 666);

        for (int i = 0; i < 4; i++) {
            Assert.assertTrue(this.Hierarchy.Contains(666));
        }
    }

    @Category(CorrectnessTests.class)
    @Test
    public void Contains_WithBothExistingAndNonexsitantElements_ShouldReturnCorrectResults()
    {
        this.Hierarchy.Add(DefaultRootValue, 666);
        this.Hierarchy.Add(666, 6666);
        this.Hierarchy.Add(6666, 66666);

        Assert.assertTrue(this.Hierarchy.Contains(666));
        Assert.assertFalse(this.Hierarchy.Contains(667));
        Assert.assertTrue(this.Hierarchy.Contains(6666));
        Assert.assertFalse(this.Hierarchy.Contains(6665));
        Assert.assertFalse(this.Hierarchy.Contains(-17000));
        Assert.assertTrue(this.Hierarchy.Contains(66666));
    }

    @Category(CorrectnessTests.class)
    @Test
    public void Contains_WithAnExistingElementWithMultipleElements_ShouldReturnTrue()
    {
        this.Hierarchy.Add(DefaultRootValue, 2);
        this.Hierarchy.Add(DefaultRootValue, 3);
        this.Hierarchy.Add(2, 4);
        this.Hierarchy.Add(3, 6);
        this.Hierarchy.Add(4, 7);

        boolean result = this.Hierarchy.Contains(6);

        Assert.assertTrue(result);
    }
}
