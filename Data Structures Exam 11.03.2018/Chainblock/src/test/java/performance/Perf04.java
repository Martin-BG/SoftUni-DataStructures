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

public class Perf04 {
    //ChangeTransactionStatus
    @Test
    public void ChangeTransactionStatus_ShouldWorkFast()
    {
        IChainblock cb = new Chainblock();
        TransactionStatus[] statuses = new TransactionStatus[]
                {
                        TransactionStatus.Aborted,
                        TransactionStatus.Failed,
                        TransactionStatus.Successfull,
                        TransactionStatus.Unauthorized
                };
        Random rand = new Random();
        List<Transaction> txs = new ArrayList<Transaction>();
        for (int i = 0; i < 100000; i++)
        {
            int status = rand.nextInt(4);
            Transaction tx = new Transaction(i, statuses[status],
                    String.valueOf(i), String.valueOf(i), i);
            cb.add(tx);
            txs.add(tx);
        }

        int count = cb.getCount();
        Assert.assertEquals(100000, count);

        long start = System.currentTimeMillis();

        for (Transaction tx : txs)
        {
            Assert.assertEquals(true, cb.contains(tx.getId()));
            int status = rand.nextInt( 4);
            cb.changeTransactionStatus(tx.getId(), statuses[status]);
        }

        long end = System.currentTimeMillis();
        long l1 = end - start;
        Assert.assertTrue(l1 < 350);
    }
}
