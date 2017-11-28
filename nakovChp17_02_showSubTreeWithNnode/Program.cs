using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that displays the (number of) roots of those sub-trees of a tree,
//which have exactly k nodes, where k is an integer.

namespace nakovChp17_02_showSubTreeWithKnode
{

    class TreeNode<T>
    {
        private T value;
        private bool hasParent;
        private List<TreeNode<T>> childList;

        public TreeNode(T value)
        {
            if (value == null)
            { throw new ArgumentNullException("cannot insert null value"); }

            this.value = value;
            this.childList = new List<TreeNode<T>>();
        }

        public T Value
        {
            get
            { return this.value; }

            set
            { this.value = value; }
        }

       public int ChildrenCount
       {
            get
            { return this.childList.Count; }

       }


        public void AddChild(TreeNode<T> child)
        {
            if (child == null)
            { throw new ArgumentNullException("cannot insert null value"); }

            if (child.hasParent)
            { throw new ArgumentException("The node already has a parent!"); }

            child.hasParent = true;
            this.childList.Add(child);

        }

        public TreeNode<T> GetChild(int index)
        {
            return this.childList[index];
        }

    }

    class Tree<T>
    {
        private TreeNode<T> root;

        public Tree(T value)
        {
            if (value == null)
            { throw new ArgumentNullException("cannot insert null value"); }

            this.root = new TreeNode<T>(value);
        }

        public Tree(T value, params Tree<T>[] childList) : this(value)
        {
            foreach (Tree<T> child in childList)
            {
                this.root.AddChild(child.root);
            }
        }

        public TreeNode<T> Root
        {
            get { return this.root; }
        }
        
    }

    public class Main_Class
    {
        static int countNodes = 0;

        public static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>(1, new Tree<int>(2, new Tree<int>(3), new Tree<int>(4)), new Tree<int>(5), new Tree<int>(6, new Tree<int>(7)));

            int num = int.Parse(Console.ReadLine());

            ShowRootOfKNumNodes(tree, num);
            Console.WriteLine(countNodes);
  
        }

        static void ShowRootOfKNumNodes(Tree<int> tree, int num)
        {
            Stack<TreeNode<int>> nodeStack = new Stack<TreeNode<int>>();
            nodeStack.Push(tree.Root);

            while(nodeStack.Count > 0)
            {
                TreeNode<int> currentNode = nodeStack.Pop();
                for (int i = 0; i < currentNode.ChildrenCount; i++)
                {
                    TreeNode<int> childNode = currentNode.GetChild(i);
                    if (childNode.ChildrenCount == num)
                    { countNodes++;}

                    nodeStack.Push(childNode);
                }
            }
        }
    }

}
