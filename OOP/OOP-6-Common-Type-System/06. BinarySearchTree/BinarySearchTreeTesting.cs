namespace _06.BinarySearchTree
{
    using System;

    class BinarySearchTreeTesting
    {
        static void Main()
        {
            BinarySearchTree<int> tree1 = new BinarySearchTree<int>(10);

            tree1.AddElement(5);
            tree1.AddElement(15);
            tree1.AddElement(5);
            tree1.AddElement(15);
            tree1.AddElement(5);
            tree1.AddElement(15);

            tree1.PrintTree();
        }
    }
}

