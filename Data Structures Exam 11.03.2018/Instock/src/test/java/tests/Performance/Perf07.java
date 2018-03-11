package tests.Performance;

import instock.Instock;
import instock.Product;
import instock.ProductStock;
import org.junit.Assert;
import org.junit.Test;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class Perf07 {
    @Test
    public void changeQuantity_100000_OnSameProduct_ShouldWorkFast()
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
            int qty = rand.nextInt(10000);
            stock.changeQuantity(products.get(576).getLabel(), qty);
            Assert.assertEquals(products.get(576).getQuantity(), qty);
        }
        long end = System.currentTimeMillis();
        Assert.assertTrue(end - start <  200);
    }

}
