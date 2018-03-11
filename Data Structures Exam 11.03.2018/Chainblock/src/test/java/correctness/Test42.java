package correctness;

import chainblock.Chainblock;
import chainblock.IChainblock;
import chainblock.Transaction;
import chainblock.TransactionStatus;
import org.junit.Assert;
import org.junit.Test;

public class Test42 {
    @Test
    public void GetByReceiverAndAmountRange_ShouldThrow_AfterRemovingReceiver()
    {
        //Arrange
        IChainblock cb = new Chainblock();
        Transaction tx1 = new Transaction(5, TransactionStatus.Successfull, "joro", "pesho", 1);
        Transaction tx2 = new Transaction(6, TransactionStatus.Successfull, "joro", "mesho", 5.5);
        Transaction tx3 = new Transaction(7, TransactionStatus.Successfull, "joro", "vesho", 5.5);
        //Act
        cb.add(tx1);
        cb.add(tx3);
        cb.add(tx2);
        cb.removeTransactionById(5);
        //Assert
        boolean threw = false;
        try{
            cb.getByReceiverAndAmountRange("pesho", 0, 20).iterator().next();
        }catch(IllegalArgumentException ex){
            threw = true;
        }
        Assert.assertTrue(threw);
    }


}
