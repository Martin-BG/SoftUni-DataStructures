package tests.Performance;

import instock.Instock;
import instock.Product;
import instock.ProductStock;
import org.junit.Assert;
import org.junit.Test;

import java.util.ArrayList;
import java.util.List;

public class Perf05 {

    @Test
    public void findByLabel_Shoul_WorkFast_On_100000_Products()
    {
        // Arrange
        ProductStock stock = new Instock();
        int count = 100000;
        List<Product> names = new ArrayList<Product>(100000);

        for (int i = 0; i < count; i++)
        {
            Product p = new Product(String.valueOf(i), i, i);
            stock.add(p);
            names.add(p);
        }

        // Act
        long start = System.currentTimeMillis();
        // Assert
        for (int i = 0; i < count; i++)
        {
            Assert.assertTrue(stock.findByLabel(names.get(i).getLabel()) == names.get(i));
        }

        long end = System.currentTimeMillis();
        Assert.assertTrue(start - end <230);
    }

}
