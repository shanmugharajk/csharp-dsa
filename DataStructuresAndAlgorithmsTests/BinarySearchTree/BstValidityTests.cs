using DataStructuresAndAlgorithms.BinarySearchTree;
using NUnit.Framework;

namespace DataStructuresAndAlgorithmsTests.BinarySearchTree;

public class BstValidityTests
{
    [Test]
    public void IsValid()
    {
        var root = new Bst(10);
        root.Left = new Bst(5);
        root.Left.Left = new Bst(2);
        root.Left.Left.Left = new Bst(1);
        root.Left.Right = new Bst(5);
        root.Right = new Bst(15);
        root.Right.Left = new Bst(13);
        root.Right.Left.Right = new Bst(14);
        root.Right.Right = new Bst(22);

        var expected = true;
        var actual = BstValidity.IsValid(root);
        Assert.That(actual, Is.EqualTo(expected));
    }
}