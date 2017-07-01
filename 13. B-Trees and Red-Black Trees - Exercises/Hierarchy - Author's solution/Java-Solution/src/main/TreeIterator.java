package main;

import java.util.Iterator;
import java.util.LinkedList;

public class TreeIterator<T> implements Iterator<T> {

    private Node<T> nextNode;

    private LinkedList<Node<T>> queue;

    public TreeIterator(Node<T> root){
        this.queue = new LinkedList<>();
        queue.addLast(root);
    }

    @Override
    public boolean hasNext() {
        return this.queue.size() > 0;
    }

    @Override
    public T next() {
        Node<T> element = queue.pop();
        for (Node<T> child : element.getChildren()) {
            queue.addLast(child);
        }

        return element.getValue();
    }
}
