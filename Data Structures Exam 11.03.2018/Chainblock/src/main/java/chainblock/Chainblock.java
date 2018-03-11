package chainblock;

import java.util.*;
import java.util.stream.Collectors;

public class Chainblock implements IChainblock {

    Map<Integer, Transaction> transactions;

    public Chainblock() {
        this.transactions = new LinkedHashMap<>();
    }

    @Override
    public int getCount() {
        return this.transactions.size();
    }

    @Override
    public void add(Transaction tx) {
        // TODO - Check if present???
        this.transactions.put(tx.getId(), tx);
    }

    @Override
    public boolean contains(Transaction tx) {
        return this.transactions.containsKey(tx.getId());
    }

    @Override
    public boolean contains(int id) {
        return this.transactions.containsKey(id);
    }

    @Override
    public void changeTransactionStatus(int id, TransactionStatus newStatus) {
        this.getById(id).setStatus(newStatus);
    }

    @Override
    public void removeTransactionById(int id) {
        Transaction tr = this.transactions.remove(id);

        if (tr == null) {
            throw new IllegalArgumentException();
        }
    }

    @Override
    public Transaction getById(int id) {
        Transaction tr = this.transactions.get(id);

        if (tr == null) {
            throw new IllegalArgumentException();
        }

        return tr;
    }

    @Override
    public Iterable<Transaction> getByTransactionStatus(TransactionStatus status) {
        List<Transaction> trans = this.transactions.values().stream()
                .filter(tr -> tr.getStatus() == status)
                .sorted(Comparator.comparingDouble(Transaction::getAmount).reversed())
                .collect(Collectors.toList());

        if (trans.isEmpty()) {
            throw new IllegalArgumentException();
        }

        return trans;
    }

    @Override
    public Iterable<String> getAllSendersWithTransactionStatus(TransactionStatus status) {
        List<String> senders = this.transactions.values().stream()
                .filter(tr -> tr.getStatus() == status)
                .sorted(Comparator.comparingDouble(Transaction::getAmount).reversed())
                .map(Transaction::getSender)
                .collect(Collectors.toList());

        if (senders.isEmpty()) {
            throw new IllegalArgumentException();
        }

        return senders;
    }

    @Override
    public Iterable<String> getAllReceiversWithTransactionStatus(TransactionStatus status) {
        List<String> receivers = this.transactions.values().stream()
                .filter(tr -> tr.getStatus() == status)
                .sorted(Comparator.comparingDouble(Transaction::getAmount).reversed()) // TODO - reversed???
                .map(Transaction::getReceiver)
                .collect(Collectors.toList());

        if (receivers.isEmpty()) {
            throw new IllegalArgumentException();
        }

        return receivers;
    }

    @Override
    public Iterable<Transaction> getAllOrderedByAmountDescendingThenById() {
        return this.transactions.values().stream()
                .sorted((tr1, tr2) -> {
                    int cmp = Double.compare(tr2.getAmount(), tr1.getAmount());
                    if (cmp == 0) {
                        cmp = Integer.compare(tr1.getId(), tr2.getId());
                    }
                    return cmp;
                })
                .collect(Collectors.toList());
    }

    @Override
    public Iterable<Transaction> getBySenderOrderedByAmountDescending(String sender) {
        List<Transaction> trans = this.transactions.values().stream()
                .filter(tr -> tr.getSender().equals(sender))
                .sorted((tr1, tr2) -> {
                    int cmp = Double.compare(tr2.getAmount(), tr1.getAmount());
//                    if (cmp == 0) {
//                        cmp = Integer.compare(tr1.getId(), tr2.getId());
//                    }
                    return cmp;
                })
                .collect(Collectors.toList());

        if (trans.isEmpty()) {
            throw new IllegalArgumentException();
        }

        return trans;
    }

    @Override
    public Iterable<Transaction> getByReceiverOrderedByAmountThenById(String receiver) {
        List<Transaction> receivers = this.transactions.values().stream()
                .filter(tr -> tr.getReceiver().equals(receiver))
                .sorted((tr1, tr2) -> {
                    int cmp = Double.compare(tr2.getAmount(), tr1.getAmount());
                    if (cmp == 0) {
                        cmp = Integer.compare(tr1.getId(), tr2.getId());
                    }
                    return cmp;
                })
                .collect(Collectors.toList());

        if (receivers.isEmpty()) {
            throw new IllegalArgumentException();
        }

        return receivers;
    }

    @Override
    public Iterable<Transaction> getByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount) {
        List<Transaction> trans = this.transactions.values().stream()
                .filter(tr -> tr.getStatus() == status && tr.getAmount() <= amount)
                .sorted((tr1, tr2) -> {
                    int cmp = Double.compare(tr2.getAmount(), tr1.getAmount());
//                    if (cmp == 0) {
//                        cmp = Integer.compare(tr1.getId(), tr2.getId());
//                    }
                    return cmp;
                })
                .collect(Collectors.toList());

        return trans;
    }

    @Override
    public Iterable<Transaction> getBySenderAndMinimumAmountDescending(String sender, double amount) {
        List<Transaction> trans = this.transactions.values().stream()
                .filter(tr -> tr.getSender().equals(sender) && tr.getAmount() > amount)
                .sorted((tr1, tr2) -> {
                    int cmp = Double.compare(tr2.getAmount(), tr1.getAmount());
//                    if (cmp == 0) {
//                        cmp = Integer.compare(tr1.getId(), tr2.getId());
//                    }
                    return cmp;
                })
                .collect(Collectors.toList());

        if (trans.isEmpty()) {
            throw new IllegalArgumentException();
        }

        return trans;
    }

    @Override
    public Iterable<Transaction> getByReceiverAndAmountRange(String receiver, double lo, double hi) {
        List<Transaction> receivers = this.transactions.values().stream()
                .filter(tr -> tr.getReceiver().equals(receiver) && tr.getAmount() >= lo && tr.getAmount() < hi)
                .sorted((tr1, tr2) -> {
                    int cmp = Double.compare(tr2.getAmount(), tr1.getAmount());
                    if (cmp == 0) {
                        cmp = Integer.compare(tr1.getId(), tr2.getId());
                    }
                    return cmp;
                })
                .collect(Collectors.toList());

        if (receivers.isEmpty()) {
            throw new IllegalArgumentException();
        }

        return receivers;
    }

    @Override
    public Iterable<Transaction> getAllInAmountRange(double lo, double hi) {
        return this.transactions.values().stream()
                .filter(tr -> tr.getAmount() >= lo && tr.getAmount() <= hi)
                .sorted((tr1, tr2) -> {
                    int cmp = Double.compare(tr2.getAmount(), tr1.getAmount());
                    if (cmp == 0) {
                        cmp = Integer.compare(tr1.getId(), tr2.getId());
                    }
                    return cmp;
                })
                .collect(Collectors.toList());
    }

    @Override
    public Iterator<Transaction> iterator() {
        return this.transactions.values().iterator();
    }
}
