namespace DataStructuresAndAlgorithms.BinarySearchTree;

public class BinarySearchTreeNode<TValue>
{
    public BinarySearchTreeNode(TValue value) => Value = value;

    public TValue Value { get; set; }

    public BinarySearchTreeNode<TValue>? Left { get; set; }

    public BinarySearchTreeNode<TValue>? Right { get; set; }
}