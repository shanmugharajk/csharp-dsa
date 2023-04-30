namespace DataStructuresAndAlgorithms.BinarySearchTree
{
    public class BinarySearchTree<TValue>
    {
        private readonly Comparer<TValue> comparer;

        public TValue Value;

        public BinarySearchTree<TValue>? Left;

        public BinarySearchTree<TValue>? Right;


        public BinarySearchTree(TValue value)
        {
            this.Value = value;
            this.comparer = Comparer<TValue>.Default;
        }

        public BinarySearchTree(TValue value, Comparer<TValue> comparer)
        {
            this.Value = value;
            this.comparer = comparer;
        }

        public BinarySearchTree<TValue> Insert(TValue value)
        {
            var currentNode = this;

            while (currentNode != null)
            {
                var result = comparer.Compare(currentNode.Value, value);

                if (result > 0)
                {
                    if (currentNode.Left == null)
                    {
                        currentNode.Left = new BinarySearchTree<TValue>(value);
                        return this;
                    }

                    currentNode = currentNode.Left;
                }
                else
                {
                    if (currentNode.Right == null)
                    {
                        currentNode.Right = new BinarySearchTree<TValue>(value);
                        return this;
                    }

                    currentNode = currentNode.Right;
                }
            }

            return this;
        }

        public bool Contains(TValue value)
        {
            var currentNode = this;

            while (currentNode != null)
            {
                var result = comparer.Compare(currentNode.Value, value);

                if (result == 0)
                {
                    return true;
                }

                currentNode = result > 0 ? currentNode.Left : currentNode.Right;
            }

            return false;
        }

        public BinarySearchTree<TValue> Remove(TValue value, BinarySearchTree<TValue>? parent = null)
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

        public bool IsValid()
        {
            // TODO: Find the best way to get the min, max values.
            return IsValid(this, (TValue)(object)int.MinValue, (TValue)(object)int.MaxValue);
        }

        public TValue FindClosestValueInBst(TValue target)
        {
            dynamic closetValue = this.Value!;

            var currentNode = this;

            while (currentNode is not null)
            {
                var result = comparer.Compare(currentNode.Value, target);

                if (result == 0)
                {
                    return currentNode.Value;
                }

                dynamic currentNodeValue = currentNode.Value!;

                if (Math.Abs(target - closetValue) > Math.Abs(target - currentNodeValue))
                {
                    closetValue = currentNode.Value!;
                }

                currentNode = result > 0 ? currentNode.Left : currentNode.Right;
            }

            return closetValue;
        }

        public static IList<TValue> GetKeysInOrder(BinarySearchTree<TValue>? node)
        {
            if (node is null)
            {
                return new List<TValue>();
            }

            var result = new List<TValue>();
            result.AddRange(GetKeysInOrder(node.Left));
            result.Add(node.Value);
            result.AddRange(GetKeysInOrder(node.Right));
            return result;
        }

        public static IList<TValue> GetKeysPreOrder(BinarySearchTree<TValue>? node)
        {
            if (node is null)
            {
                return new List<TValue>();
            }

            var result = new List<TValue>();
            result.Add(node.Value);
            result.AddRange(GetKeysPreOrder(node.Left));
            result.AddRange(GetKeysPreOrder(node.Right));
            return result;
        }

        public static IList<TValue> GetKeysPostOrder(BinarySearchTree<TValue>? node)
        {
            if (node is null)
            {
                return new List<TValue>();
            }

            var result = new List<TValue>();
            result.AddRange(GetKeysPostOrder(node.Left));
            result.AddRange(GetKeysPostOrder(node.Right));
            result.Add(node.Value);
            return result;
        }

        private bool IsValid(BinarySearchTree<TValue> node, TValue minValue, TValue maxValue)
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


        private (BinarySearchTree<TValue>? node, BinarySearchTree<TValue>? parentNode) ParentNodeAndNode(TValue value)
        {
            BinarySearchTree<TValue>? parentNode = null;

            // ReSharper disable once SuggestVarOrType_SimpleTypes
            BinarySearchTree<TValue>? currentNode = this;

            while (currentNode != null)
            {
                var result = comparer.Compare(currentNode.Value, value);

                if (result == 0)
                {
                    return (currentNode, parentNode);
                }

                parentNode = currentNode;
                currentNode = result > 0 ? currentNode.Left : currentNode.Right;
            }

            return (null, null);
        }

        private TValue GetMinValue()
        {
            var currentNode = this;

            while (currentNode.Left != null)
            {
                currentNode = currentNode.Left;
            }

            return currentNode.Value;
        }
    }
}