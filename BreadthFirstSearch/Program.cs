using System;
using System.Collections.Generic;

namespace SearchingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            
            // //BFS iterative approach for a tree
            // BinaryTree tree = new BinaryTree();
            // tree.root = new Node(1);
            // tree.root.left = new Node(2);
            // tree.root.right = new Node(3);
            // tree.root.left.left = new Node(4);
            // tree.root.left.right = new Node(5);
            //
            // int target = 3;
            // if (tree.BFS(target))
            //     Console.WriteLine($"Value {target} found in binary tree");
            // else
            //     Console.WriteLine($"Value {target} not found in binary tree");
            // Console.WriteLine();
            // //-------------------------------------------------------------------------------
            // Console.WriteLine();
            // //BFS iterative approach for a graph
            // Graph g = new Graph(4);
            // g.AddEdge(0, 1);
            // g.AddEdge(0, 2);
            // g.AddEdge(1, 2);
            // g.AddEdge(2, 0);
            // g.AddEdge(2, 3);
            // g.AddEdge(3, 3);
            //
            // int target2 = 3;
            // if (g.BFS(2, target2))
            //     Console.WriteLine($"Value {target2} found in graph");
            // else
            //     Console.WriteLine($"Value {target2} not found in graph");
            ////-------------------------------------------------------------------------------------
            Tree t = new Tree();
            //BFS recursive approach for a Tree

            t.Insert(4);
            t.Insert(2);
            t.Insert(1);
            t.Insert(3);
            t.Insert(5);

            int target = 3;
            if (t.BFS(target))
                Console.WriteLine($"Value {target} found in tree");
            else
                Console.WriteLine($"Value {target} not found in tree");
            Console.WriteLine();
            //-------------------------------------------------------------------------------
            Graph g = new Graph(4);
            //BFS recursive approach for a graph
            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 3);

            Console.WriteLine("Following is Breadth First Traversal (starting from vertex 2)");

            bool found = g.BFS(2, 3);

            Console.WriteLine();

            if (found)
                Console.WriteLine("3 is found in the graph!");
            else
                Console.WriteLine("3 is not found in the graph.");

            Console.ReadKey();
        }
    }

    class SearchingAlgos
    {
        private void Info()
        {
            //Linear Search - also known as sequential search is a method of finding 
            // a target value within a list. BigO(n)
            
            //Binary Search - A BigO(log n). divides the data and searches the item
            //based on the items value as compared to the divided data's values to the
            //left or to the right. This Happens when the data is sorted such that, 
            //data to the left of the division are lesser that data to the right of the
            //division. 
            
            //Graph/Tree Traversals - BigO(n). In case the tree isn't sorted or we have a graph
            // or any tree or graph structure that the data isn't, we can use a different
            //approach that will let us go thru the whole data which is the BFS/DFS.
            
            //Breadth First Search - Starts from the root node, and moves from left to
            //right on the first level after the node and then to the next level also from
            //left to right till we either find the item being search for or the graph/tree
            //ends. uses additional memory.
            
            //Depth First Search - uses lower memory as compared to breadth first search.
            //The search follows one branch path a long as possible until the item is found
            //or that branch path is exhausted. Then it goes to each ancestor before is and
            //explores any other child node not already explored till the whole tree or 
            //graph is exhausted. The search starts from the left most branch path
            
            //BFS vrs DFS = All have a BigO(n). BFS has Shortest path to finding an item. Also
            //has closer nodes but uses more memory. 
            //                                                 DFS uses less memory than BFS but can 
            //get slower.
            //If there is additional info about the location of the search item, it helps as
            //an item that is in the upper part of a tree or graph is best for BFS and items
            //expected to be in the lower part of a tree are best for DFS.
        }
    }
    public class Graph //BFS Graph search iterative approach
    {
        private int V; // number of vertices
        private List<int>[] adj; // adjacency list

        public Graph(int v)
        {
            V = v;
            adj = new List<int>[V];
            for (int i = 0; i < V; i++)
                adj[i] = new List<int>();
        }

        public void AddEdge(int v, int w)
        {
            adj[v].Add(w);
        }

        public bool BFS(int s, int target)
        {
            bool[] visited = new bool[V];
            Queue<int> queue = new Queue<int>();

            visited[s] = true;
            queue.Enqueue(s);

            while (queue.Count != 0)
            {
                s = queue.Dequeue();
                //Console.Write(s + " ");

                if (s == target)
                    return true;

                foreach (int i in adj[s])
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
                        queue.Enqueue(i);
                    }
                }
            }

            return false;
        }
    }
    
    public class Node //BFS Tree  search1 iterative approach
    {
        public int data;
        public Node left, right;
        public Node(int item)
        {
            data = item;
            left = right = null;
        }
    }
    public class BinaryTree //BFS Tree  search2 iterative approach
    {
        public Node root;
        public bool BFS(int target)
        {
            if (root == null)
                return false;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                Node tempNode = queue.Dequeue();
                if (tempNode.data == target)
                    return true;

                if (tempNode.left != null)
                    queue.Enqueue(tempNode.left);

                if (tempNode.right != null)
                    queue.Enqueue(tempNode.right);
            }
            return false;
        }
    }
    
    
    public class Node1
{
    public int Value;
    public Node1 Left;
    public Node1 Right;

    public Node1(int val)
    {
        Value = val;
        Left = null;
        Right = null;
    }
} //BFS implementation on a tree with a recursive approach. This is its node
    public class Tree
    {
        private Node1 root;
        public Tree()
        {
            root = null;
        }
        public bool BFS(int target)
        {
            Queue<Node1> queue = new Queue<Node1>();
            queue.Enqueue(root);

            return BFSHelper(queue, target);
        }
        private bool BFSHelper(Queue<Node1> queue, int target)
        {
            if (queue.Count == 0)
                return false;

            Node1 node = queue.Dequeue();
            //Console.Write(node.Value + " ");

            if (node.Value == target)
                return true;

            if (node.Left != null)
                queue.Enqueue(node.Left);

            if (node.Right != null)
                queue.Enqueue(node.Right);

            return BFSHelper(queue, target);
        }
        public void Insert(int val)
        {
            root = InsertHelper(root, val);
        }
        private Node1 InsertHelper(Node1 node, int val)
        {
            if (node == null)
                return new Node1(val);

            if (val < node.Value)
                node.Left = InsertHelper(node.Left, val);
            else if (val > node.Value)
                node.Right = InsertHelper(node.Right, val);

            return node;
        }
    } //BFS implementation on a tree with a recursive approach
    
    class Graph1 //BFS implementation on a graph with a recursive approach
    {
        private int V; // number of vertices
        private List<int>[] adj; // adjacency list
        
        public Graph1(int v)
        {
            V = v;
            adj = new List<int>[V];
            for (int i = 0; i < V; i++)
                adj[i] = new List<int>();
        }
        public void AddEdge(int v, int w)
        {
            adj[v].Add(w);
        }
        public bool BFS(int start, int target)
        {
            bool[] visited = new bool[V];
            return BFSRecursive(start, target, visited);
        }
        private bool BFSRecursive(int s, int target, bool[] visited)
        {
            if (s == target)
                return true;
            visited[s] = true;
            //Console.Write(s + " ");
            foreach (int i in adj[s])
            {
                if (!visited[i])
                {
                    if (BFSRecursive(i, target, visited))
                        return true;
                }
            }
            return false;
        }
    }
}