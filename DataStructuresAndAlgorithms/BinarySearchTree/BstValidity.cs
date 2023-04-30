namespace DataStructuresAndAlgorithms.BinarySearchTree;

public abstract class BstValidity
{
    public static bool IsValid(BST node)
    {
        return IsValid(node, int.MinValue, int.MaxValue);
    }

    private static bool IsValid(BST node, int minValue, int maxValue)
    {
        if (node.Value < minValue || node.Value >= maxValue)
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
}