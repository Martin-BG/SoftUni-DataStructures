package test.correctness;

import org.junit.Assert;
import org.junit.Test;
import org.junit.experimental.categories.Category;
import test.helpers.BaseTest;
import test.types.CorrectnessTests;

public class GetParent extends BaseTest {

    @Category(CorrectnessTests.class)
    @Test(expected = IllegalArgumentException.class)
    public void GetParent_WithNonExistantElement_ShouldThrowException()
    {
        this.Hierarchy.GetParent(-17);
    }

    @Category(CorrectnessTests.class)
    @Test
    public void GetParent_WithRoot_ShouldReturnDefault()
    {
        Integer result = this.Hierarchy.GetParent(DefaultRootValue);

        Assert.assertEquals(null, result);
    }

    @Category(CorrectnessTests.class)
    @Test
    public void GetParent_WithANodeWithAParent_ShouldReturnParentValue()
    {
        this.Hierarchy.Add(DefaultRootValue,17);
        this.Hierarchy.Add(DefaultRootValue, 20);
        this.Hierarchy.Add(17, 22);
        this.Hierarchy.Add(20,15);
        this.Hierarchy.Add(20, -33);

        int result = this.Hierarchy.GetParent(-33);

        Assert.assertEquals(20, result);
    }
}
