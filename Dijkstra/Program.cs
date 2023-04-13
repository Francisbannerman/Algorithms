using System;
using System.Collections.Generic;

// class Dijkstra {
//     //Basic Dijkstra Implementation
//     static void Main() {
//         int V = 5; // number of vertices
//
//         List<KeyValuePair<int, int>>[] adj = new List<KeyValuePair<int, int>>[V];
//         for (int i = 0; i < V; i++) {
//             adj[i] = new List<KeyValuePair<int, int>>();
//         }
//
//         // add edges and weights to adjacency list
//         adj[0].Add(new KeyValuePair<int, int>(1, 10));
//         adj[0].Add(new KeyValuePair<int, int>(3, 5));
//         adj[1].Add(new KeyValuePair<int, int>(2, 1));
//         adj[1].Add(new KeyValuePair<int, int>(3, 2));
//         adj[2].Add(new KeyValuePair<int, int>(4, 4));
//         adj[3].Add(new KeyValuePair<int, int>(1, 3));
//         adj[3].Add(new KeyValuePair<int, int>(2, 9));
//         adj[3].Add(new KeyValuePair<int, int>(4, 2));
//         adj[4].Add(new KeyValuePair<int, int>(0, 7));
//         adj[4].Add(new KeyValuePair<int, int>(2, 6));
//
//         int[] dist = new int[V];
//         bool[] visited = new bool[V];
//         for (int i = 0; i < V; i++) {
//             dist[i] = int.MaxValue;
//             visited[i] = false;
//         }
//         dist[0] = 0;
//
//         for (int i = 0; i < V - 1; i++) {
//             int u = MinDistance(dist, visited);
//             visited[u] = true;
//             foreach (KeyValuePair<int, int> v in adj[u]) {
//                 if (!visited[v.Key] && dist[u] != int.MaxValue && dist[u] + v.Value < dist[v.Key]) {
//                     dist[v.Key] = dist[u] + v.Value;
//                 }
//             }
//         }
//
//         Console.WriteLine("Vertex   Distance from Source");
//         for (int i = 0; i < V; i++) {
//             Console.WriteLine("{0}\t {1}", i, dist[i]);
//         }
//     }
//
//     static int MinDistance(int[] dist, bool[] visited) {
//         int min = int.MaxValue, minIndex = -1;
//         for (int i = 0; i < dist.Length; i++) {
//             if (!visited[i] && dist[i] < min) {
//                 min = dist[i];
//                 minIndex = i;
//             }
//         }
//         return minIndex;
//     }
// }


class Dijkstra {
    //Dijkstra implementation to finding the shortest  route between two vertices
    static void Main() {
        int V = 5; // number of vertices

        List<KeyValuePair<int, int>>[] adj = new List<KeyValuePair<int, int>>[V];
        for (int i = 0; i < V; i++) {
            adj[i] = new List<KeyValuePair<int, int>>();
        }

        // add edges and weights to adjacency list
        adj[0].Add(new KeyValuePair<int, int>(1, 10));
        adj[0].Add(new KeyValuePair<int, int>(3, 5));
        adj[1].Add(new KeyValuePair<int, int>(2, 1));
        adj[1].Add(new KeyValuePair<int, int>(3, 2));
        adj[2].Add(new KeyValuePair<int, int>(4, 4));
        adj[3].Add(new KeyValuePair<int, int>(1, 3));
        adj[3].Add(new KeyValuePair<int, int>(2, 9));
        adj[3].Add(new KeyValuePair<int, int>(4, 2));
        adj[4].Add(new KeyValuePair<int, int>(0, 7));
        adj[4].Add(new KeyValuePair<int, int>(2, 6));

        int[] dist = new int[V];
        int[] prev = new int[V];
        bool[] visited = new bool[V];
        for (int i = 0; i < V; i++) {
            dist[i] = int.MaxValue;
            prev[i] = -1;
            visited[i] = false;
        }
        dist[0] = 0;

        for (int i = 0; i < V - 1; i++) {
            int u = MinDistance(dist, visited);
            visited[u] = true;
            foreach (KeyValuePair<int, int> v in adj[u]) {
                if (!visited[v.Key] && dist[u] != int.MaxValue && dist[u] + v.Value < dist[v.Key]) {
                    dist[v.Key] = dist[u] + v.Value;
                    prev[v.Key] = u;
                }
            }
        }

        Console.WriteLine("Shortest path from vertex 0 to vertex 4:");
        if (dist[4] == int.MaxValue) {
            Console.WriteLine("No path found.");
        } else {
            List<int> path = new List<int>();
            for (int i = 4; i != -1; i = prev[i]) {
                path.Add(i);
            }
            path.Reverse();
            Console.Write("0");
            foreach (int vertex in path) {
                Console.Write(" -> {0}", vertex);
            }
            Console.WriteLine("\nShortest distance: {0}", dist[4]);
        }
    }

    static int MinDistance(int[] dist, bool[] visited) {
        int min = int.MaxValue, minIndex = -1;
        for (int i = 0; i < dist.Length; i++) {
            if (!visited[i] && dist[i] < min) {
                min = dist[i];
                minIndex = i;
            }
        }
        return minIndex;
    }
}
