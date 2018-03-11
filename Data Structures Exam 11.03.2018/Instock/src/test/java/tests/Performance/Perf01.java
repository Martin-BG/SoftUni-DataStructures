package tests.Performance;


import instock.Instock;
import instock.Product;
import instock.ProductStock;
import org.junit.Assert;
import org.junit.Test;


public class Perf01
{

    @Test
    public void add_100000_Elements_ShouldWorkFast()
    {
        //Arrange
        ProductStock stock = new Instock();
        long start = System.currentTimeMillis();
        //Act
        for (int i = 0; i < 50000; i++)
        {
            stock.add(new Product(String.valueOf(i), i, i));
        }
        long stop = System.currentTimeMillis();
        //Assert
        Assert.assertTrue(stop - start < 450);
    }
}

