package performance;


import chainblock.Chainblock;
import chainblock.IChainblock;
import chainblock.Transaction;
import chainblock.TransactionStatus;
import org.junit.Assert;
import org.junit.Test;

import java.util.*;
import java.util.concurrent.TimeUnit;
import java.util.stream.Collectors;

public class Perf01
{

    //Add (Show Visa that you are not to be reckoned with
    @Test
    public void Add_100000_Transactions_Should_WorkFast()
    {

        IChainblock cb = new Chainblock();
        int count = 100000;
        TransactionStatus[] statuses = new TransactionStatus[]
                {
                        TransactionStatus.Aborted,
                        TransactionStatus.Failed,
                        TransactionStatus.Successfull,
                        TransactionStatus.Unauthorized
                };
        Random rand = new Random();
        long start = System.currentTimeMillis();
        for(int i = 0; i < count; i++)
        {
            //int status = rand.nextInt(0, 4);
            cb.add(new Transaction(i, TransactionStatus.Successfull,
                    String.valueOf(i), String.valueOf(i), i));
        }

        long end = System.currentTimeMillis();
        Assert.assertEquals(count, cb.getCount());
        Assert.assertTrue(end - start < 400);
    }


}

