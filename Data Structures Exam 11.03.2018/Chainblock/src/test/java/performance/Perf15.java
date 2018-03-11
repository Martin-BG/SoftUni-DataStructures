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

public class Perf15 {
    //GetByReceiverAndAmountRange
    @Test
    public void GetByReceiverAndAmountRange()
    {
        IChainblock cb = new Chainblock();
        List<Transaction> txs = new ArrayList<Transaction>();
        Random rand = new Random();
        for (int i = 0; i < 100000; i++)
        {
            int amount = rand.nextInt(1000);
            Transaction tx = new Transaction(i, TransactionStatus.Successfull,
                    "sender", "from", amount);
            cb.add(tx);
            if (amount >= 200 && amount < 600) txs.add(tx);
        }
        txs = txs.stream().sorted((x,y) -> {
            int compare = Double.compare(y.getAmount(),x.getAmount());
            if(compare == 0){
                return Integer.compare(x.getId(), y.getId());
            }
            return compare;
        }).collect(Collectors.toList());
        int count = cb.getCount();
        Assert.assertEquals(100000, count);
        long start = System.currentTimeMillis();

        Iterable<Transaction> all = cb.getByReceiverAndAmountRange(
                "from", 200, 600);
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
