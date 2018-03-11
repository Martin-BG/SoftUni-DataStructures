package tests.Performance;

import instock.Instock;
import instock.Product;
import instock.ProductStock;
import org.junit.Assert;
import org.junit.Test;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class Perf03 {
    @Test
    public void findAtIndex_On_100_000_Elements_ShouldWorkFast()
    {
        // Arrange
        ProductStock stock = new Instock();
        int count = 100000;
        List<Product> people = new ArrayList<Product>();

        for (int i = 0; i < count; i++)
        {
            people.add(new Product(String.valueOf(i), i, i));
            stock.add(people.get(i));
        }

        // Act
        long start = System.currentTimeMillis();
        Random rand = new Random();
        for (int i = 0; i < 50000; i++)
        {
            int rnd = rand.nextInt(count - 1);
            Assert.assertSame(people.get(rnd), stock.find(rnd));
        }
        // Assert
        long end = System.currentTimeMillis();
        Assert.assertTrue(end - start < 200);
    }


}
