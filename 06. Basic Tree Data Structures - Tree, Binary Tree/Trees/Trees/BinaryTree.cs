using System;

public class BinaryTree<T>
{
    public T Value { get; set; }
    public BinaryTree<T> LeftChild { get; set; }
    public BinaryTree<T> RightChild { get; set; }

    public BinaryTree(T value, 
        BinaryTree<T> leftChild = null, 
        BinaryTree<T> rightChild = null)
    {
        this.Value = value;
        this.LeftChild = leftChild;
        this.RightChild = rightChild;
    }

    public void PrintIndentedPreOrder(int indent = 0)
    {
        Console.WriteLine(new String(' ', indent) + this.Value);

        if (this.LeftChild != null)
        {
            this.LeftChild.PrintIndentedPreOrder(indent + 2);
        }

        if (this.RightChild != null)
        {
            this.RightChild.PrintIndentedPreOrder(indent + 2);
        }
    }

    public void EachInOrder(Action<T> action)
    {
        this.EachInOrder(this, action);
    }

    private void EachInOrder(BinaryTree<T> node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        EachInOrder(node.LeftChild, action);
        action(node.Value);
        EachInOrder(node.RightChild, action);
    }

    public void EachPostOrder(Action<T> action)
    {
        this.EachPostOrder(this, action);
    }

    private void EachPostOrder(BinaryTree<T> node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        EachPostOrder(node.LeftChild, action);
        EachPostOrder(node.RightChild, action);
        action(node.Value);
    }
}
