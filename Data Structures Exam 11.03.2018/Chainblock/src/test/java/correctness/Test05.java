package correctness;

import chainblock.Chainblock;
import chainblock.IChainblock;
import chainblock.Transaction;
import chainblock.TransactionStatus;
import org.junit.Assert;
import org.junit.Test;

public class Test05 {
    //Contains
    @Test
    public void Contains_OnEmptyChainblock_ShouldReturnFalse()
    {
        //Arrange
        IChainblock cb = new Chainblock();
        //Act
        //Assert
        Assert.assertFalse(cb.contains(5));
        Assert.assertFalse(cb.contains(new Transaction(3, TransactionStatus.Failed, "a", "b", 0.5)));
    }
}
