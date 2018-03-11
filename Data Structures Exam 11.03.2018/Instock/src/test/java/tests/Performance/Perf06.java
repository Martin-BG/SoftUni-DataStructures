package tests.Performance;

import instock.Instock;
import instock.Product;
import instock.ProductStock;
import org.junit.Assert;
import org.junit.Test;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class Perf06 {
    @Test
    public void changeQuantity_On_100000_ShouldWorkFast()
    {
        // Arrange
        ProductStock stock = new Instock();
        int count = 100000;
        List<Product> products = new ArrayList<Product>(100000);

        for (int i = 0; i < count; i++)
        {
            Product p = new Product(String.valueOf(i), i, i);
            stock.add(p);
            products.add(p);
        }

        // Act & Assert
        long start = System.currentTimeMillis();
        Random rand = new Random();
        for (int i = 0; i < 50000; i++)
        {
            int qty = rand.nextInt(50000);
            int index = rand.nextInt(99999);
            stock.changeQuantity(products.get(i).getLabel(), qty);
            Assert.assertEquals(products.get(i).getQuantity(), qty);
        }
        long end = System.currentTimeMillis();
        Assert.assertTrue(end - start < 250);
    }
}
