package performance;

import chainblock.Chainblock;
import chainblock.IChainblock;
import chainblock.Transaction;
import chainblock.TransactionStatus;
import org.junit.Assert;
import org.junit.Test;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Random;

public class Perf18 {
    // GetAllSendersWithTransactionStatus
    @Test
    public void GetAllSendersWithTransactionStatus_ShouldWorkFast()
    {
        IChainblock cb = new Chainblock();
        List<Transaction> txs = new ArrayList<Transaction>();
        TransactionStatus[] statuses = new TransactionStatus[]
                {
                        TransactionStatus.Aborted,
                        TransactionStatus.Failed,
                        TransactionStatus.Successfull,
                        TransactionStatus.Unauthorized
                };
        Random rand = new Random();
        for (int i = 0; i < 100000; i++)
        {
            int status = rand.nextInt(4);
            TransactionStatus TS = statuses[status];
            Transaction tx = new Transaction(i, TS,
                    String.valueOf(i), String.valueOf(i), i);
            cb.add(tx);
            if(TS == TransactionStatus.Successfull) txs.add(tx);
        }
        Collections.reverse(txs);
        int count = cb.getCount();
        Assert.assertEquals(100000, count);
        long start = System.currentTimeMillis();

        Iterable<String> all = cb.getAllSendersWithTransactionStatus(TransactionStatus.Successfull);
        int c = 0;
        for (String tx : all) {
            Assert.assertEquals(tx, txs.get(c).getSender());
            c++;
        }

        long end = System.currentTimeMillis();
        long l1 = end - start;

        Assert.assertTrue(l1 < 150);
        Assert.assertEquals(txs.size(), c);
    }

}
