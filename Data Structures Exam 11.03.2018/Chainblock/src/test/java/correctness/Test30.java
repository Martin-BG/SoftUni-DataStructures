package correctness;

import chainblock.Chainblock;
import chainblock.IChainblock;
import org.junit.Assert;
import org.junit.Test;

public class Test30 {
    @Test
    public void GetBySenderAndMinimumAmountDescending_ShouldThrowOnEmpty_CB() {
        //Arrange
        IChainblock cb = new Chainblock();
        //Act
        //Assert
        boolean threw = false;
        try {
            cb.getBySenderAndMinimumAmountDescending("pesho", 5);
        } catch (Exception e) {
            threw = true;
        }

        Assert.assertTrue(threw);
    }
}
