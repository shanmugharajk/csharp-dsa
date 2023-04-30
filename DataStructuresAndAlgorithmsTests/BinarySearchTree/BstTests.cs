using DataStructuresAndAlgorithms.BinarySearchTree;
using NUnit.Framework;

// ReSharper disable UseObjectOrCollectionInitializer

namespace DataStructuresAndAlgorithmsTests.BinarySearchTree;

// ReSharper disable once InconsistentNaming
public class BstTests
{
    [Test]
    public void InsertAndDelete()
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
    public void BuildFromRoot()
    {
        var root = new Bst(10);
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
    }

    [Test]
    public void BuildFromRootAndRemove()
    {
        var root = new Bst(10);
        root.Insert(5);
        root.Insert(15);

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
}