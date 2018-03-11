package tests.Performance;

import instock.Instock;
import instock.Product;
import instock.ProductStock;
import org.junit.Assert;
import org.junit.Test;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.Iterator;
import java.util.List;

public class Perf10 {

    @Test
    public void findFirstByAlphabeticOrder_On100000Elements_ShouldWorkFast()
    {
        // Arrange
        ProductStock stock = new Instock();
        int count = 100000;
        List<Product> products = new ArrayList<Product>();

        for (int i = 0; i < count; i++)
        {

            products.add(new Product(String.valueOf(i), i,i));
            stock.add(products.get(i));
        }
        products.sort(Comparator.comparing(Product::getLabel));
        long start = System.currentTimeMillis();
        // Act
        Iterable<Product> result = stock.findFirstByAlphabeticalOrder(50000);

        // Assert
        Iterator<Product> iter = result.iterator();
        for(int i = 0 ; i < 50000;i++){

            Assert.assertTrue(iter.hasNext());
            Assert.assertSame(products.get(i),iter.next());
        }
        long end = System.currentTimeMillis();

        Assert.assertTrue(end - start < 100);
    }

}
