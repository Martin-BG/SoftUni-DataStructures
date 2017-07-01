package main;

import java.util.*;
import java.util.stream.Collectors;

public class Hierarchy<T> implements IHierarchy<T> {

    private Node<T> root;

    private LinkedHashMap<T,Node<T>> nodes;

    public Hierarchy(T element){
        Node<T> elementNode = new Node<T>(element);
        this.setRoot(elementNode);
        this.nodes = new LinkedHashMap<>();
        this.nodes.put(element,elementNode);
    }

    private Node<T> getRoot() {
        return root;
    }

    private void setRoot(Node<T> root) {
        this.root = root;
    }

    public void Add(T parent, T child){
        if(!this.nodes.containsKey(parent)){
            throw new IllegalArgumentException("Parent does not exist!");
        }

        if(this.nodes.containsKey(child)){
            throw new IllegalArgumentException("Child element cannot have 2 parents!");
        }

        Node<T> parentNode = this.nodes.get(parent);
        Node<T> childNode = new Node<T>(child,parentNode);
        parentNode.getChildren().add(childNode);
        this.nodes.put(child,childNode);
    }

    public int getCount() {
        return this.nodes.size();
    }

    public void Remove(T element){
        if(!this.nodes.containsKey(element)){
            throw new IllegalArgumentException("Element does not exist!");
        }
        Node<T> elementNode = this.nodes.get(element);
        if(elementNode.getParent() == null){
            throw new IllegalStateException("Cannot delete the Root!");
        }

        Node<T> parent = elementNode.getParent();
        List<Node<T>> children = elementNode.getChildren();
        for (Node<T> child : children) {
            child.setParent(parent);
        }

        parent.getChildren().addAll(children);

        this.nodes.remove(element);
        parent.getChildren().remove(elementNode);
    }

    public boolean Contains(T element){
        return this.nodes.containsKey(element);
    }

    public T GetParent(T element){
        if(!this.nodes.containsKey(element)){
            throw new IllegalArgumentException("Element does not exist!");
        }

        Node<T> elementNode = this.nodes.get(element);
        if(elementNode.getParent() == null){
            return null;
        }

        return elementNode.getParent().getValue();
    }

    public Iterable<T> GetChildren(T element){
        if(!this.nodes.containsKey(element)){
            throw new IllegalArgumentException("Element does not exist!");
        }

        Node<T> elementNode = this.nodes.get(element);
        return elementNode.getChildren().stream().map(x->x.getValue()).collect(Collectors.toList());
    }

    public Iterable<T> GetCommonElements(IHierarchy<T> other){
        List<T> result = new ArrayList<T>();
        for (T key : this.nodes.keySet()) {
            if(other.Contains(key)){
                result.add(key);
            }
        }

        return result;
    }

    @Override
    public Iterator<T> iterator() {
        TreeIterator<T>it = new TreeIterator<>(getRoot());
        return it;
    }
}
