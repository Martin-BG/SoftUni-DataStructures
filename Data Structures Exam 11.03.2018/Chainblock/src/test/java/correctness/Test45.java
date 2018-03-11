package correctness;

import chainblock.Chainblock;
import chainblock.IChainblock;
import chainblock.Transaction;
import chainblock.TransactionStatus;
import org.junit.Assert;
import org.junit.Test;

public class Test45 {
    @Test(expected = IllegalArgumentException.class)
    public void GetByReceiver_On_NonExisting_Receiver_ShouldThrow()
    {
        //Arrange
        IChainblock cb = new Chainblock();
        Transaction tx1 = new Transaction(2, TransactionStatus.Successfull, "joro", "pesho", 1);
        Transaction tx2 = new Transaction(1, TransactionStatus.Successfull, "joro", "mesho", 1);
        Transaction tx3 = new Transaction(4, TransactionStatus.Successfull, "joro", "kalin", 15.6);
        Transaction tx4 = new Transaction(3, TransactionStatus.Successfull, "joro", "pesho", 15.6);
        Transaction tx5 = new Transaction(8, TransactionStatus.Failed, "joro", "barko", 17.8);

        //Act
        cb.add(tx1);
        cb.add(tx3);
        cb.add(tx2);
        cb.add(tx4);
        cb.add(tx5);
        //Assert

        cb.getByReceiverOrderedByAmountThenById("mecho");

    }
}
