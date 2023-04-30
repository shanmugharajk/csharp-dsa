namespace DataStructuresAndAlgorithms.BinarySearchTree;

// ReSharper disable once InconsistentNaming
public class BST
{
    public int Value;

    public BST? Left;

    public BST? Right;

    public BST(int value)
    {
        this.Value = value;
    }

    public BST Insert(int value)
    {
        var currentNode = this;

        while (currentNode != null)
        {
            if (currentNode.Value > value)
            {
                if (currentNode.Left == null)
                {
                    currentNode.Left = new BST(value);
                    return this;
                }

                currentNode = currentNode.Left;
            }
            else
            {
                if (currentNode.Right == null)
                {
                    currentNode.Right = new BST(value);
                    return this;
                }

                currentNode = currentNode.Right;
            }
        }

        return this;
    }

    public bool Contains(int value)
    {
        var currentNode = this;

        while (currentNode != null)
        {
            if (currentNode.Value == value)
            {
                return true;
            }

            currentNode = currentNode.Value > value ? currentNode.Left : currentNode.Right;
        }

        return false;
    }

    public BST Remove(int value, BST? parent = null)
    {
        // Finding the node, parent node
        var (node, parentNode) = this.ParentNodeAndNode(value);

        if (node == null)
        {
            return this;
        }

        // Both nodes are there
        if (node is { Left: not null, Right: not null })
        {
            node.Value = node.Right.GetMinValue();
            node.Right.Remove(node.Value, parentNode);
            return this;
        }

        // If it's root node
        if (parentNode == null)
        {
            // Only left child
            if (node.Left != null)
            {
                node.Value = node.Left.Value;
                node.Right = node.Left.Right;
                node.Left = node.Left.Left;
            }
            // Only right child
            else if (node.Right != null)
            {
                node.Value = node.Right.Value;
                node.Left = node.Right.Left;
                node.Right = node.Right.Right;
            }

            return this;
        }

        // Left node
        if (parentNode.Left == node)
        {
            parentNode.Left = node.Left ?? node.Right;
            return this;
        }

        // Right Node
        if (parentNode.Right == node)
        {
            parentNode.Right = node.Left ?? node.Right;
            return this;
        }

        return this;
    }

    private (BST? node, BST? parentNode) ParentNodeAndNode(int value)
    {
        BST? parentNode = null;

        // ReSharper disable once SuggestVarOrType_SimpleTypes
        BST? currentNode = this;

        while (currentNode != null)
        {
            if (currentNode.Value == value)
            {
                return (currentNode, parentNode);
            }

            parentNode = currentNode;
            currentNode = currentNode.Value > value ? currentNode.Left : currentNode.Right;
        }

        return (null, null);
    }

    private int GetMinValue()
    {
        var currentNode = this;

        while (currentNode.Left != null)
        {
            currentNode = currentNode.Left;
        }

        return currentNode.Value;
    }
}