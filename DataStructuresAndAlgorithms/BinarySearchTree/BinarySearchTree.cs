namespace DataStructuresAndAlgorithms.BinarySearchTree;

public class BinarySearchTree<TValue>
{
    private readonly Comparer<TValue> comparer;

    public BinarySearchTreeNode<TValue>? Root { get; private set; }

    public BinarySearchTree()
    {
        Root = null;
        comparer = Comparer<TValue>.Default;
    }

    public BinarySearchTree(Comparer<TValue> customComparer)
    {
        Root = null;
        comparer = customComparer;
    }

    public bool Contains(TValue value) => Search(Root, value) is not null;

    public ICollection<TValue> GetValuesInOrder() => GetValuesInOrder(Root);

    public ICollection<TValue> GetValuesPreOrder() => GetValuesPreOrder(Root);

    public ICollection<TValue> GetValuesPostOrder() => GetValuesPostOrder(Root);

    public bool IsValid()
    {
        if (this.Root is null)
        {
            return false;
        }

        return IsValid(this.Root, (TValue) (object) int.MinValue, (TValue) (object) int.MaxValue);
    }

    public void Insert(TValue value)
    {
        if (Root is null)
        {
            Root = new BinarySearchTreeNode<TValue>(value);
        }
        else
        {
            Insert(Root, value);
        }
    }

    public bool Remove(TValue value)
    {
        if (Root is null)
        {
            return false;
        }

        return Remove(Root, Root, value);
    }

    public void AddRange(IEnumerable<TValue> values)
    {
        foreach (var value in values)
        {
            Insert(value);
        }
    }

    private IList<TValue> GetValuesInOrder(BinarySearchTreeNode<TValue>? node)
    {
        if (node is null)
        {
            return new List<TValue>();
        }

        var result = new List<TValue>();
        result.AddRange(GetValuesInOrder(node.Left));
        result.Add(node.Value);
        result.AddRange(GetValuesInOrder(node.Right));
        return result;
    }

    private IList<TValue> GetValuesPreOrder(BinarySearchTreeNode<TValue>? node)
    {
        if (node is null)
        {
            return new List<TValue>();
        }

        var result = new List<TValue> {node.Value};
        result.AddRange(GetValuesPreOrder(node.Left));
        result.AddRange(GetValuesPreOrder(node.Right));
        return result;
    }

    private IList<TValue> GetValuesPostOrder(BinarySearchTreeNode<TValue>? node)
    {
        if (node is null)
        {
            return new List<TValue>();
        }

        var result = new List<TValue>();
        result.AddRange(GetValuesPostOrder(node.Left));
        result.AddRange(GetValuesPostOrder(node.Right));
        result.Add(node.Value);
        return result;
    }

    private bool IsValid(BinarySearchTreeNode<TValue> node, TValue minValue, TValue maxValue)
    {
        var leftComparisonResult = comparer.Compare(node.Value, minValue);
        var rightComparisonResult = comparer.Compare(node.Value, maxValue);

        if (leftComparisonResult < 0 || rightComparisonResult >= 0)
        {
            return false;
        }

        if (node.Left != null && !IsValid(node.Left, minValue, node.Value))
        {
            return false;
        }

        if (node.Right != null && !IsValid(node.Right, node.Value, maxValue))
        {
            return false;
        }

        return true;
    }

    private bool Remove(BinarySearchTreeNode<TValue>? parent, BinarySearchTreeNode<TValue>? node, TValue value)
    {
        if (parent is null || node is null)
        {
            return false;
        }

        var compareResult = comparer.Compare(node.Value, value);

        if (compareResult > 0)
        {
            return Remove(node, node.Left, value);
        }

        if (compareResult < 0)
        {
            return Remove(node, node.Right, value);
        }

        BinarySearchTreeNode<TValue>? replacementNode;

        // Case 0: Node has no children
        // Case 1: Node has one children
        if (node.Left is null || node.Right is null)
        {
            replacementNode = node.Left ?? node.Right;
        }

        // Case 2: Node has two children.
        else
        {
            var newParentNode = GetMin(node.Right);
            Remove(Root, Root, newParentNode.Value);
            replacementNode = new BinarySearchTreeNode<TValue>(newParentNode.Value)
            {
                Left = node.Left,
                Right = node.Right,
            };
        }

        // Replace the node
        if (node == Root)
        {
            Root = replacementNode;
        }
        else if (parent.Left == node)
        {
            parent.Left = replacementNode;
        }

        {
            parent.Right = replacementNode;
        }

        return true;
    }

    private BinarySearchTreeNode<TValue>? Search(BinarySearchTreeNode<TValue>? node, TValue value)
    {
        if (node is null)
        {
            return default;
        }

        var compareResult = comparer.Compare(node.Value, value);

        if (compareResult > 0)
        {
            return Search(node.Left, value);
        }

        if (compareResult < 0)
        {
            return Search(node.Right, value);
        }

        return node;
    }

    private BinarySearchTreeNode<TValue> GetMin(BinarySearchTreeNode<TValue> node)
    {
        return node.Left is null ? node : GetMin(node.Left);
    }

    private void Insert(BinarySearchTreeNode<TValue> node, TValue value)
    {
        var compareResult = comparer.Compare(node.Value, value);

        if (compareResult > 0)
        {
            if (node.Left is null)
            {
                var newNode = new BinarySearchTreeNode<TValue>(value);
                node.Left = newNode;
            }
            else
            {
                Insert(node.Left, value);
            }
        }
        else
        {
            if (node.Right is null)
            {
                var newNode = new BinarySearchTreeNode<TValue>(value);
                node.Right = newNode;
            }
            else
            {
                Insert(node.Right, value);
            }
        }
    }
}