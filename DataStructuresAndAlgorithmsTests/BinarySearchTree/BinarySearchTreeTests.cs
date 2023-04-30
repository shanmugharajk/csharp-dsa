using DataStructuresAndAlgorithms.BinarySearchTree;
using NUnit.Framework;

namespace DataStructuresAndAlgorithmsTests.BinarySearchTree;

public class BinarySearchTreeTests
{
    [Test]
    public void UpdateExistingTree_Correctly_Forms_Tree()
    {
        var root = new BinarySearchTree<int>(10);
        root.Left = new BinarySearchTree<int>(5);
        root.Left.Left = new BinarySearchTree<int>(2);
        root.Left.Left.Left = new BinarySearchTree<int>(1);
        root.Left.Right = new BinarySearchTree<int>(5);
        root.Right = new BinarySearchTree<int>(15);
        root.Right.Left = new BinarySearchTree<int>(13);
        root.Right.Left.Right = new BinarySearchTree<int>(14);
        root.Right.Right = new BinarySearchTree<int>(22);

        root.Insert(12);
        Assert.That(root.Right?.Left?.Left?.Value, Is.EqualTo(12));

        root.Remove(10);
        Assert.Multiple(() =>
        {
            Assert.That(root.Value, Is.EqualTo(12));
            Assert.That(root.Contains(15), Is.EqualTo(true));
        });
    }

    [Test]
    public void AddFromRoot_Creates_Valid_Tree()
    {
        var root = new BinarySearchTree<int>(10);
        root.Insert(5);
        Assert.That(root.Left?.Value, Is.EqualTo(5));

        root.Insert(15);
        Assert.Multiple(() =>
        {
            Assert.That(root.Right?.Value, Is.EqualTo(15));
            Assert.That(root.Contains(10), Is.EqualTo(true));
            Assert.That(root.Contains(5), Is.EqualTo(true));
            Assert.That(root.Contains(15), Is.EqualTo(true));
            Assert.That(root.Contains(1), Is.EqualTo(false));
        });

        root.Remove(5);
        root.Remove(15);
        Assert.Multiple(() =>
        {
            Assert.That(root.Contains(5), Is.EqualTo(false));
            Assert.That(root.Contains(15), Is.EqualTo(false));
        });

        // Removing root node which doesn't have any children.
        // In this case the node will not be deleted.
        root.Remove(10);
        Assert.That(root.Value, Is.EqualTo(10));
    }

    [Test]
    public void ChecksValidityOfTree()
    {
        var root = new BinarySearchTree<int>(10);
        root.Left = new BinarySearchTree<int>(5);
        root.Left.Left = new BinarySearchTree<int>(2);
        root.Left.Left.Left = new BinarySearchTree<int>(1);
        root.Left.Right = new BinarySearchTree<int>(5);
        root.Right = new BinarySearchTree<int>(15);
        root.Right.Left = new BinarySearchTree<int>(13);
        root.Right.Left.Right = new BinarySearchTree<int>(14);
        root.Right.Right = new BinarySearchTree<int>(22);

        Assert.That(root.IsValid(), Is.EqualTo(true));
    }

    [Test]
    public void FindClosestValueInBst_Correctly()
    {
        var root = new BinarySearchTree<int>(10);
        root.Left = new BinarySearchTree<int>(5);
        root.Left.Left = new BinarySearchTree<int>(2);
        root.Left.Left.Left = new BinarySearchTree<int>(1);
        root.Left.Right = new BinarySearchTree<int>(5);
        root.Right = new BinarySearchTree<int>(15);
        root.Right.Left = new BinarySearchTree<int>(13);
        root.Right.Left.Right = new BinarySearchTree<int>(14);
        root.Right.Right = new BinarySearchTree<int>(22);

        Assert.That(root.FindClosestValueInBst(12), Is.EqualTo(13));
    }
}