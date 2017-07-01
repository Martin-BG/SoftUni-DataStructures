package main;

import java.util.ArrayList;
import java.util.List;

public class Node<T>{

    T value;
    Node<T> parent;
    List<Node<T>> children;

    public Node(T value){
        this.setValue(value);
        this.setParent(null);
        this.setChildren(new ArrayList<Node<T>>());
    }

    public Node(T value, Node<T> parent){
        this.setValue(value);
        this.setParent(parent);
        this.setChildren(new ArrayList<Node<T>>());
    }

    public Node<T> getParent() {
        return parent;
    }

    public void setParent(Node<T> parent) {
        this.parent = parent;
    }

    private void setChildren(List<Node<T>> children) {
        this.children = children;
    }

    public List<Node<T>> getChildren() {
        return this.children;
    }

    public T getValue() {
        return value;
    }

    public void setValue(T value) {
        this.value = value;
    }



}