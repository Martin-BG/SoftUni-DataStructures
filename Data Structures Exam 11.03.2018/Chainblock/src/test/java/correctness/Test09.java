package correctness;

import chainblock.Chainblock;
import chainblock.IChainblock;
import chainblock.Transaction;
import chainblock.TransactionStatus;
import org.junit.Assert;
import org.junit.Test;

public class Test09 {
    @Test
    public void Count_Should_RemainCorrect_AfterRemoving()
    {
        //Arrange
        IChainblock cb = new Chainblock();
        Transaction tx1 = new Transaction(5, TransactionStatus.Successfull, "joro", "pesho", 5);
        Transaction tx2 = new Transaction(6, TransactionStatus.Successfull, "joro", "pesho", 5);
        Transaction tx3 = new Transaction(7, TransactionStatus.Successfull, "joro", "pesho", 5);
        //Act
        cb.add(tx1);
        cb.add(tx2);
        cb.add(tx3);
        cb.removeTransactionById(tx1.getId());
        cb.removeTransactionById(tx3.getId());
        //Assert
        Assert.assertEquals(1, cb.getCount());
        Assert.assertNotSame(tx1, cb.getById(tx2.getId()));
    }
}
