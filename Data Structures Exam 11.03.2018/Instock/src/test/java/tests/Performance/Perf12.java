package tests.Performance;

import instock.Instock;
import instock.Product;
import instock.ProductStock;
import org.junit.Assert;
import org.junit.Test;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;

public class Perf12 {
    @Test
    public void FindAllByQuantity_On_100000_Elements_ShouldWorkFast()
    {
        // Arrange
        ProductStock stock = new Instock();
        int count = 100000;
        HashMap<Integer, ArrayList<Product>> products
                = new HashMap<Integer, ArrayList<Product>>();

        for (int i = 0; i < count; i+=400)
        {
            for(int j = 0; j < 400; j++)
            {
                Product p = new Product(String.valueOf((i + j)), j, j);
                products.putIfAbsent(j, new ArrayList<Product>());
                stock.add(p);
                products.get(j).add(p);
            }
        }
        long start = System.currentTimeMillis();
        // Act

        // Assert
        for(int i = 0; i < 100; i++)
        {
            Iterable<Product> iterable = stock.findAllByQuantity(i);
            int c = 0;
            for(Product p : iterable) {
                Assert.assertSame(p, products.get(i).get(c));
                c++;
            }

            Assert.assertEquals(c, products.get(i).size());
        }
        long end = System.currentTimeMillis();

        Assert.assertTrue(end - start < 100);
    }
}
