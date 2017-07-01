package main;

import java.util.Iterator;

public class Hierarchy<T> implements IHierarchy<T> {

    public Hierarchy(T element){
        throw new UnsupportedOperationException();
    }

    public void add(T parent, T child){
        throw new UnsupportedOperationException();
    }

    public int getCount() {
        throw new UnsupportedOperationException();
    }

    public void remove(T element){
        throw new UnsupportedOperationException();
    }

    public boolean contains(T element){
        throw new UnsupportedOperationException();
    }

    public T getParent(T element){
        throw new UnsupportedOperationException();
    }

    public Iterable<T> getChildren(T element){
        throw new UnsupportedOperationException();
    }

    public Iterable<T> getCommonElements(IHierarchy<T> other){
        throw new UnsupportedOperationException();
    }

    @Override
    public Iterator<T> iterator() {
        throw new UnsupportedOperationException();
    }
}
