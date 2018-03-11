package performance;

import chainblock.Chainblock;
import chainblock.IChainblock;
import chainblock.Transaction;
import chainblock.TransactionStatus;
import org.junit.Assert;
import org.junit.Test;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class Perf02 {
    //Contains
    @Test
    public void Contains_100000_ShouldWorkFast()
    {
        IChainblock cb = new Chainblock();
        int count = 100000;
        List<Transaction> txs = new ArrayList<Transaction>();
        TransactionStatus[] statuses = new TransactionStatus[]
                {
                        TransactionStatus.Aborted,
                        TransactionStatus.Failed,
                        TransactionStatus.Successfull,
                        TransactionStatus.Unauthorized
                };
        Random rand = new Random();

        for (int i = 0; i < count; i++)
        {
            int status = rand.nextInt(4);
            Transaction tx = new Transaction(i, statuses[status],
                    String.valueOf(i), String.valueOf(i), i);
            cb.add(tx);
            txs.add(tx);
        }
        Assert.assertEquals(count, cb.getCount());

        long start = System.currentTimeMillis();

        for (Transaction tx : txs)
        {
            Assert.assertEquals(true, cb.contains(tx));
        }

        long end = System.currentTimeMillis();

        Assert.assertTrue(end - start < 200);
    }
}
