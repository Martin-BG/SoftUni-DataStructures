package correctness;

import chainblock.Chainblock;
import chainblock.IChainblock;
import org.junit.Assert;
import org.junit.Test;

public class Test46 {
    @Test(expected = IllegalArgumentException.class)
    public void GetByReceiver_ShouldThrow_On_EmptyCB()
    {
        //Arrange
        IChainblock cb = new Chainblock();
        //Act
        //Assert
        cb.getByReceiverOrderedByAmountThenById("pesho");
    }

    //GetBySenderAndMinimumAmountDescending
}
