package correctness;

import chainblock.Chainblock;
import chainblock.IChainblock;
import chainblock.Transaction;
import chainblock.TransactionStatus;
import org.junit.Assert;
import org.junit.Test;


public class Test01
{

    //addition
    @Test
    public void add_SingleElement_ShouldWorkCorrectly()
    {
        //Arrange
        IChainblock cb = new Chainblock();
        Transaction tx = new Transaction(5, TransactionStatus.Successfull, "joro", "pesho", 5);
        //Act
        cb.add(tx);

        //Assert
        for (Transaction transaction : cb)
        {
            Assert.assertSame(transaction, tx);
        }
    }

}