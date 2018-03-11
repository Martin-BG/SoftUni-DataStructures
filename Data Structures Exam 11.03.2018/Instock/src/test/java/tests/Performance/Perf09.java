package tests.Performance;

import instock.Instock;
import instock.Product;
import instock.ProductStock;
import org.junit.Assert;
import org.junit.Test;

import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.Random;

public class Perf09 {
    @Test
    public void findAllByPrice_On100000ElementsWithRandomPrice_ShouldWorkFast()
    {
        // Arrange
        ProductStock stock = new Instock();
        int count = 100000;
        List<Product> expected = new ArrayList<Product>();

        Random random = new Random();
        for (int i = 0; i < count; i++)
        {
            int price = random.nextInt(30);
            Product p = new Product(String.valueOf(i), price, 25);
            if (price == 21)
            {
                expected.add(p);
            }
            stock.add(p);
        }

        long start = System.currentTimeMillis();
        // Act
        Iterable<Product> result = stock.findAllByPrice(21);

        // Assert
        Iterator<Product> iter = result.iterator();
        for(int i = 0 ; i < expected.size();i++){

            Assert.assertTrue(iter.hasNext());
            Assert.assertSame(expected.get(i),iter.next());
        }
        long end = System.currentTimeMillis();
        Assert.assertTrue(end - start < 25);
    }
}
