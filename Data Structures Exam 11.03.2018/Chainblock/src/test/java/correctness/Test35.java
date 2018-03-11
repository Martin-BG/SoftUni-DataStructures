package correctness;

import chainblock.Chainblock;
import chainblock.IChainblock;
import chainblock.Transaction;
import chainblock.TransactionStatus;
import org.junit.Assert;
import org.junit.Test;

import java.util.NoSuchElementException;

public class Test35 {
    @Test(expected = IllegalArgumentException.class)
    public void GetAllSendersWithTransactionStatus_OnNonExistantTxs_ShouldThrow()
    {
        //Arrange
        IChainblock cb = new Chainblock();
        Transaction tx1 = new Transaction(5, TransactionStatus.Successfull, "joro", "pesho", 1);
        Transaction tx2 = new Transaction(6, TransactionStatus.Aborted, "joro", "pesho", 5.5);
        Transaction tx3 = new Transaction(7, TransactionStatus.Aborted, "joro", "pesho", 5.5);
        Transaction tx4 = new Transaction(12, TransactionStatus.Failed, "joro", "pesho", 15.6);
        Transaction tx5 = new Transaction(15, TransactionStatus.Successfull, "joro", "pesho", 7.8);
        //Act
        cb.add(tx1);
        cb.add(tx3);
        cb.add(tx2);
        cb.add(tx4);
        cb.add(tx5);
        //Assert
        cb.getAllSendersWithTransactionStatus(TransactionStatus.Unauthorized);

    }
}
