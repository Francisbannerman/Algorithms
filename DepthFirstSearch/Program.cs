using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        Node root = new Node(1);
        Node node2 = new Node(2);
        Node node3 = new Node(3);
        Node node4 = new Node(4);
        Node node5 = new Node(5);
        Node node6 = new Node(6);
        Node node7 = new Node(7);
        Node node8 = new Node(8);
        Node node9 = new Node(9);
        Node node10 = new Node(10);
        root.children.Add(node2);
        root.children.Add(node3);
        root.children.Add(node4);
        node2.children.Add(node5);
        node2.children.Add(node6);
        node3.children.Add(node7);
        node4.children.Add(node8);
        node5.children.Add(node9);
        node5.children.Add(node10);


        Console.WriteLine("Preorder traversal:");
        PreorderDFS preorder = new PreorderDFS();
        preorder.Traversal(root);
        Console.WriteLine(preorder.SearchItem(root, 8));
        Console.WriteLine("----------------------------");

        Console.WriteLine("Post order traversal");
        PostOrderDFS postOrder = new PostOrderDFS();
        postOrder.Traversal(root);
        Console.WriteLine(postOrder.SearchItem(root,8));
        Console.WriteLine("----------------------------");

        Console.WriteLine("In order traversal");
        InOrderDFS inOrder = new InOrderDFS();
        inOrder.Traversal(root);
        Console.WriteLine(inOrder.SearchItem(root,8));
        Console.WriteLine("----------------------------");


        Console.WriteLine("DFS traversal implementation for a Graph");
        Graph g = new Graph(4);
        g.AddEdge(0, 1);
        g.AddEdge(0, 2);
        g.AddEdge(1, 2);
        g.AddEdge(2, 0);
        g.AddEdge(2, 3);
        g.AddEdge(3, 3);
        Console.WriteLine("Following is Depth First Traversal " +
                          "(starting from vertex 2)");
        g.DFS(2);
        Console.WriteLine();
        Console.WriteLine("------------------------------------------");
        Console.WriteLine();
        Console.WriteLine("DFS finding an item implementation for a Graph");
        Graph1 g1 = new Graph1(4);
        g1.AddEdge1(0, 1);
        g1.AddEdge1(0, 2);
        g1.AddEdge1(1, 2);
        g1.AddEdge1(2, 0);
        g1.AddEdge1(2, 3);
        g1.AddEdge1(3, 3);
        Console.WriteLine("Searching for item 3...");
        g1.DFS(2, 3);

        
        Console.ReadKey();
    }
}


//DFS implementation for a tree
public class Node
{
    public int value;
    public List<Node> children;
    public Node(int val)
    {
        value = val;
        children = new List<Node>();
    }
}

public class PreorderDFS
{
    public void Traversal(Node node)
    {
        if (node == null)
        {
            return;
        }

        Console.Write(node.value + " ");
        foreach (Node child in node.children)
        {
            Traversal(child);
        }
    }
    public Node SearchItem(Node node, int searchVal)
    {
        if (node == null)
        {
            return null;
        }

        if (node.value == searchVal)
        {
            return node;
        }

        foreach (Node child in node.children)
        {
            Node result = SearchItem(child, searchVal);
            if (result != null)
            {
                return result;
            }
        }

        return null;
    }

}

public class PostOrderDFS
{
    public void Traversal(Node node)
    {
        if (node == null)
        {
            return;
        }
        foreach (Node child in node.children)
        {
            Traversal(child);
        }
        Console.Write(node.value + " ");
    }

    public Node SearchItem(Node node, int searchVal)
    {
        if (node == null)
        {
            return null;
        }
        foreach (Node child in node.children)
        {
            Node result = SearchItem(child, searchVal);
            if (result != null)
            {
                return result;
            }
        }
        if (node.value == searchVal)
        {
            return node;
        }
        return null;
    }

}

public class InOrderDFS
{
    public void Traversal(Node node)
    {
        if (node == null)
        {
            return;
        }

        if (node.children.Count > 0)
        {
            Traversal(node.children[0]);
        }

        Console.Write(node.value + " ");

        for (int i = 1; i < node.children.Count; i++)
        {
            Traversal(node.children[i]);
        }
    }

    public Node SearchItem(Node node, int searchVal)
    {
        if (node == null)
        {
            return null;
        }

        if (node.children.Count > 0)
        {
            Node result = SearchItem(node.children[0], searchVal);
            if (result != null)
            {
                return result;
            }
        }

        if (node.value == searchVal)
        {
            return node;
        }

        for (int i = 1; i < node.children.Count; i++)
        {
            Node result = SearchItem(node.children[i], searchVal);
            if (result != null)
            {
                return result;
            }
        }

        return null;
    }
}



class Graph
{
    private int V;
    private List<int>[] adj;

    public Graph(int v)
    {
        V = v;
        adj = new List<int>[v];
        for (int i = 0; i < v; i++)
        {
            adj[i] = new List<int>();
        }
    }

    public void AddEdge(int v, int w)
    {
        adj[v].Add(w);
    }

    private void DFSUtil(int v, bool[] visited)
    {
        visited[v] = true;
        Console.Write(v + " ");

        foreach (int i in adj[v])
        {
            if (!visited[i])
            {
                DFSUtil(i, visited);
            }
        }
    }

    public void DFS(int v)
    {
        bool[] visited = new bool[V];
        DFSUtil(v, visited);
    }
}

class Graph1
{
    private int V;
    private List<int>[] adj;

    public Graph1(int v)
    {
        V = v;
        adj = new List<int>[v];
        for (int i = 0; i < v; i++)
        {
            adj[i] = new List<int>();
        }
    }

    public void AddEdge1(int v, int w)
    {
        adj[v].Add(w);
    }

    private bool DFSUtil(int v, bool[] visited, int item)
    {
        visited[v] = true;

        if (v == item)
        {
            Console.WriteLine("Item " + item + " found!");
            return true;
        }

        foreach (int i in adj[v])
        {
            if (!visited[i] && DFSUtil(i, visited, item))
            {
                return true;
            }
        }

        return false;
    }

    public void DFS(int v, int item)
    {
        bool[] visited = new bool[V];
        if (!DFSUtil(v, visited, item))
        {
            Console.WriteLine("Item " + item + " not found!");
        }
    }
}
