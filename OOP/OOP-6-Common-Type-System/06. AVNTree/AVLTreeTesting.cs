namespace _06.AVNTree
{
    using System;

    public class AVLTreeTesting
    {
        public static void Main()
        {
            AvlTree<int> tree1 = new AvlTree<int>();

            tree1.AddElement(10);
            tree1.AddElement(5);
            tree1.AddElement(15);
            tree1.AddElement(6);
            tree1.AddElement(4);
            tree1.AddElement(16);
            tree1.AddElement(14);
            tree1.AddElement(19);

            Console.WriteLine(tree1);

            foreach (var item in tree1)
            {
                //same as item.Value
                Console.WriteLine(item);
            }

            var copy = tree1.Clone();

            Console.WriteLine(copy);

            Console.WriteLine(tree1.FindElement(17));

            Console.WriteLine(tree1.FindElement(16));

            tree1.RemoveElement(19);

            Console.WriteLine(tree1);
        }
    }
}
