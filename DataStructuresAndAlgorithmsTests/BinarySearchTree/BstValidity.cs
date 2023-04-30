using DataStructuresAndAlgorithms.BinarySearchTree;
using NUnit.Framework;

namespace DataStructuresAndAlgorithmsTests.BinarySearchTree;

public class BstValidityTests
{
    [Test]
    public void IsValid()
    {
        var root = new BST(10);
        root.Left = new BST(5);
        root.Left.Left = new BST(2);
        root.Left.Left.Left = new BST(1);
        root.Left.Right = new BST(5);
        root.Right = new BST(15);
        root.Right.Left = new BST(13);
        root.Right.Left.Right = new BST(14);
        root.Right.Right = new BST(22);

        var expected = true;
        var actual = BstValidity.IsValid(root);
        Assert.That(actual, Is.EqualTo(expected));
    }
}