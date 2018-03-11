package tests.Performance;

import instock.Instock;
import instock.Product;
import instock.ProductStock;
import org.junit.Assert;
import org.junit.Test;

import java.util.Iterator;
import java.util.LinkedList;

public class Perf11 {
    @Test
    public void FindFirstMostExpensiveItems_On100000Elements_ShouldWorkFast()
    {
        // Arrange
        ProductStock stock = new Instock();
        int count = 100000;
        LinkedList<Product> products = new LinkedList<Product>();

        for (int i = 0; i < count; i++)
        {

            products.addFirst(new Product(String.valueOf(i), i, i));
            stock.add(products.getFirst());
        }
        long start = System.currentTimeMillis();
        // Act
        Iterable<Product> result = stock.findFirstMostExpensiveProducts(50000);

        // Assert
        Iterator<Product> iter = result.iterator();
        for(int i = 0 ; i < 50000;i++){

            Assert.assertTrue(iter.hasNext());
            Assert.assertSame(products.get(i),iter.next());
        }
        long end = System.currentTimeMillis();

        Assert.assertTrue(end - start <  120);
    }

}
