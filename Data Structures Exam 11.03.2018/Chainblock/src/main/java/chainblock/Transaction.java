package chainblock;

public class Transaction {

    private int id;
    private TransactionStatus status;
    private String sender;
    private String receiver;
    private double amount;

    public Transaction(int id, TransactionStatus status, String sender, String receiver, double amount) {
        this.id = id;
        this.status = status;
        this.receiver = receiver;
        this.sender = sender;
        this.amount = amount;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public TransactionStatus getStatus() {
        return status;
    }

    public void setStatus(TransactionStatus status) {
        this.status = status;
    }

    public String getSender() {
        return sender;
    }

    public void setSender(String sender) {
        this.sender = sender;
    }

    public String getReceiver() {
        return receiver;
    }

    public void setReceiver(String receiver) {
        this.receiver = receiver;
    }

    public double getAmount() {
        return amount;
    }

    public void setAmount(double amount) {
        this.amount = amount;
    }
}
