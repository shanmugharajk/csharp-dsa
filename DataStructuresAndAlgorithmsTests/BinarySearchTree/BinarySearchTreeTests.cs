using DataStructuresAndAlgorithms.BinarySearchTree;
using NUnit.Framework;

namespace DataStructuresAndAlgorithmsTests.BinarySearchTree;

public class BinarySearchTreeNewTests
{
    [Test]
    public void UpdateExistingTree_Correctly_Forms_Tree()
    {
        var tree = new BinarySearchTree<int>();
        tree.AddRange(new List<int>() {10, 5, 15, 2, 5, 13, 22, 1, 14});

        tree.Insert(12);
        Assert.That(tree.Root?.Right?.Left?.Left?.Value, Is.EqualTo(12));

        tree.Remove(10);
        Assert.Multiple(() =>
        {
            Assert.That(tree.Root?.Value, Is.EqualTo(12));
            Assert.That(tree.Contains(15), Is.EqualTo(true));
        });
    }

    [Test]
    public void AddFromRoot_Creates_Valid_Tree()
    {
        var tree = new BinarySearchTree<int>();
        tree.AddRange(new List<int>() {10});
        tree.Insert(5);
        Assert.That(tree.Root?.Left?.Value, Is.EqualTo(5));

        tree.Insert(15);
        Assert.Multiple(() =>
        {
            Assert.That(tree.Root?.Right?.Value, Is.EqualTo(15));
            Assert.That(tree.Contains(10), Is.EqualTo(true));
            Assert.That(tree.Contains(5), Is.EqualTo(true));
            Assert.That(tree.Contains(15), Is.EqualTo(true));
            Assert.That(tree.Contains(1), Is.EqualTo(false));
        });

        tree.Remove(5);
        tree.Remove(15);
        Assert.Multiple(() =>
        {
            Assert.That(tree.Contains(5), Is.EqualTo(false));
            Assert.That(tree.Contains(15), Is.EqualTo(false));
        });

        tree.Remove(10);
        Assert.That(tree.Root?.Value, Is.EqualTo(null));
    }

    [Test]
    public void ChecksValidityOfTree()
    {
        var tree = new BinarySearchTree<int>();
        tree.AddRange(new List<int>() {10, 5, 15, 2, 5, 13, 22, 1, 14});

        Assert.That(tree.IsValid(), Is.EqualTo(true));
    }

    [Test]
    public void Return_InOrderTraversal_Correctly()
    {
        var tree = new BinarySearchTree<int>();
        tree.AddRange(new List<int>() {10, 5, 15, 2, 5, 22, 1});

        var actual = tree.GetValuesInOrder();
        var expected = new List<int>() {1, 2, 5, 5, 10, 15, 22};

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Return_PreOrderTraversal_Correctly()
    {
        var tree = new BinarySearchTree<int>();
        tree.AddRange(new List<int>() {10, 5, 15, 2, 5, 22, 1});

        var actual = tree.GetValuesPreOrder();
        var expected = new List<int>() {10, 5, 2, 1, 5, 15, 22};

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Return_PostOrderTraversal_Correctly()
    {
        var tree = new BinarySearchTree<int>();
        tree.AddRange(new List<int>() {10, 5, 15, 2, 5, 22, 1});

        var actual = tree.GetValuesPostOrder();
        var expected = new List<int>() {1, 2, 5, 5, 22, 15, 10};

        Assert.That(actual, Is.EqualTo(expected));
    }
}