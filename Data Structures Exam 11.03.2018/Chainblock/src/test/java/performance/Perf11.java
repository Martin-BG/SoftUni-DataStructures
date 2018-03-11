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
import java.util.stream.Collectors;

public class Perf11 {
    //GetByTransactionStatusAndMaximumAmount
    @Test
    public void GetByTransactionStatusAndMaximumAmount_ShouldWorkFast()
    {
        IChainblock cb = new Chainblock();
        List<Transaction> txs = new ArrayList<Transaction>();
        Random rand = new Random();
        for (int i = 0; i < 100000; i++)
        {
            int amount = rand.nextInt(1000);
            Transaction tx = new Transaction(i, TransactionStatus.Successfull,
                    String.valueOf(i), String.valueOf(i), amount);
            cb.add(tx);
            if (amount <= 500) txs.add(tx);
        }
        txs = txs.stream().sorted((x,y) -> Double.compare(y.getAmount(),x.getAmount())).collect(Collectors.toList());
        int count = cb.getCount();
        Assert.assertEquals(100000, count);
        long start = System.currentTimeMillis();

        Iterable<Transaction> all = cb.getByTransactionStatusAndMaximumAmount(
                TransactionStatus.Successfull, 500);
        int c = 0;
        for (Transaction tx : all)
        {
            Assert.assertSame(tx, txs.get(c));
            c++;
        }

        long end = System.currentTimeMillis();
        long l1 = end - start;

        Assert.assertTrue(l1 < 150);
        Assert.assertEquals(txs.size(), c);
    }
}
