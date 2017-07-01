package test.performance;

import main.Hierarchy;
import org.junit.Assert;
import org.junit.Test;
import org.junit.experimental.categories.Category;
import test.helpers.BasePerformanceTest;
import test.helpers.IterableExtensions;
import test.types.PerformanceTests;

import java.util.List;
import java.util.stream.Collectors;
import java.util.stream.IntStream;

public class AddPerformance extends BasePerformanceTest {

    @Category(PerformanceTests.class)
    @Test
    public void PerformanceAdd_WithOnly2ParentWith50000SplitElements() {
        int count = 3;
        int counter1 = 1;
        int counter2 = 25001;
        Hierarchy<Integer> hierarchy = new Hierarchy<>(-1);

        long start = System.currentTimeMillis();
        hierarchy.Add(-1, 1);
        hierarchy.Add(-1, 25001);
        for (int i = 1; i < 25000; i++) {
            hierarchy.Add(1, ++counter1);
            hierarchy.Add(25001, ++counter2);
            count += 2;
            Assert.assertEquals("Count did not increase correctly!", count, hierarchy.getCount());
        }

        long end = System.currentTimeMillis();
        Assert.assertTrue(end - start < 200);

        counter1 = 1;
        counter2 = 25001;
        for (int i = 1; i < 25000; i++) {
            Assert.assertEquals("Parent did not match!", 1, (int) hierarchy.GetParent(++counter1));
            Assert.assertEquals("Parent did not match!", 25001, (int) hierarchy.GetParent(++counter2));
        }

        List<Integer> expectedChildren = IntStream.range(2, 25000 + 1).boxed().collect(Collectors.toList());
        List<Integer> actualChildren = IterableExtensions.toList(hierarchy.GetChildren(1));
        Assert.assertTrue(expectedChildren.equals(actualChildren));

        List<Integer> expectedChildren2 = IntStream.range(25002, 25000 + 25001).boxed().collect(Collectors.toList());
        List<Integer> actualChildren2 = IterableExtensions.toList(hierarchy.GetChildren(25001));
        Assert.assertTrue(expectedChildren2.equals(actualChildren2));
    }

    @Category(PerformanceTests.class)
    @Test
    public void PerformanceAdd_With40000ElementsInReverseOrderIn4Groups() {
        int counter1 = 10000;
        int counter2 = 30000;
        int counter3 = 50000;
        int counter4 = 70000;
        int count = 5;
        Hierarchy<Integer> hierarchy = new Hierarchy<>(100000);
        long start = System.currentTimeMillis();
        hierarchy.Add(100000, 10000);
        hierarchy.Add(100000, 30000);
        hierarchy.Add(100000, 50000);
        hierarchy.Add(100000, 70000);
        for (int i = 1; i < 10000; i++) {
            hierarchy.Add(counter1, --counter1);
            hierarchy.Add(counter2, --counter2);
            hierarchy.Add(counter3, --counter3);
            hierarchy.Add(counter4, --counter4);
            count += 4;
            Assert.assertEquals("Count did not increase correctly!", count, hierarchy.getCount());
        }

        long end = System.currentTimeMillis();
        Assert.assertTrue(end - start < 200);

        counter1 = 1;
        counter2 = 20001;
        counter3 = 40001;
        counter4 = 60001;
        for (int i = 1; i < 10000; i++) {
            Assert.assertEquals(counter1 + 1, (int) hierarchy.GetParent(counter1));
            Assert.assertEquals(counter2 + 1, (int) hierarchy.GetParent(counter2));
            Assert.assertEquals(counter3 + 1, (int) hierarchy.GetParent(counter3));
            Assert.assertEquals(counter4 + 1, (int) hierarchy.GetParent(counter4));

            Assert.assertEquals(counter1, (int) hierarchy.GetChildren(counter1 + 1).iterator().next());
            Assert.assertEquals(counter2, (int) hierarchy.GetChildren(counter2 + 1).iterator().next());
            Assert.assertEquals(counter3, (int) hierarchy.GetChildren(counter3 + 1).iterator().next());
            Assert.assertEquals(counter4, (int) hierarchy.GetChildren(counter4 + 1).iterator().next());
            counter1++;
            counter2++;
            counter3++;
            counter4++;
        }
    }
}
