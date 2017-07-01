package main;

public interface IHierarchy<T> extends Iterable<T> {

    int getCount();

    void Add(T element, T child);

    void Remove(T element);

    Iterable<T> GetChildren(T element);
    
    T GetParent(T element);

    boolean Contains(T element);

    Iterable<T> GetCommonElements(IHierarchy<T> other);
}
