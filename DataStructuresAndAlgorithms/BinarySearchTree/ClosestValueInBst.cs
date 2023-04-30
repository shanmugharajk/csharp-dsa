namespace DataStructuresAndAlgorithms.BinarySearchTree;

public abstract class ClosestValueInBst
{
    public static int FindClosestValueInBst(BST tree, int target)
    {
        var closetValue = tree.Value;
        var currentNode = tree;

        while (currentNode != null)
        {
            if (currentNode.Value == target)
            {
                return currentNode.Value;
            }

            if (Math.Abs(target - closetValue) > Math.Abs(target - currentNode.Value))
            {
                closetValue = currentNode.Value;
            }

            currentNode = currentNode.Value > target ? currentNode.Left : currentNode.Right;
        }

        return closetValue;
    }
}