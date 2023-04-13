using System;

// class BellmanFord {
//     //Basic Bellman Ford Implementation
//     static void Main() {
//         int V = 5; // number of vertices
//         int E = 8; // number of edges
//
//         int[,] edges = { // edges and weights
//             {0, 1, -1},
//             {0, 2, 4},
//             {1, 2, 3},
//             {1, 3, 2},
//             {1, 4, 2},
//             {3, 2, 5},
//             {3, 1, 1},
//             {4, 3, -3}
//         };
//
//         int[] dist = new int[V];
//         for (int i = 0; i < V; i++) {
//             dist[i] = int.MaxValue;
//         }
//         dist[0] = 0;
//
//         for (int i = 0; i < V - 1; i++) {
//             for (int j = 0; j < E; j++) {
//                 int u = edges[j, 0];
//                 int v = edges[j, 1];
//                 int w = edges[j, 2];
//                 if (dist[u] != int.MaxValue && dist[u] + w < dist[v]) {
//                     dist[v] = dist[u] + w;
//                 }
//             }
//         }
//
//         Console.WriteLine("Vertex   Distance from Source");
//         for (int i = 0; i < V; i++) {
//             Console.WriteLine("{0}\t {1}", i, dist[i]);
//         }
//     }
// }



class BellmanFord {
    //Bellman-Ford implementation to finding the shortest  route between two vertices
    static void Main() {
        int V = 5; // number of vertices

        int[,] edges = { {0, 1, 10}, {0, 3, 5}, {1, 2, 1}, {1, 3, 2}, {2, 4, 4}, {3, 1, 3}, {3, 2, 9}, {3, 4, 2}, {4, 0, 7}, {4, 2, 6} };
        int E = edges.GetLength(0);

        int[] dist = new int[V];
        for (int i = 0; i < V; i++) {
            dist[i] = int.MaxValue;
        }
        dist[0] = 0;

        for (int i = 0; i < V - 1; i++) {
            for (int j = 0; j < E; j++) {
                int u = edges[j, 0];
                int v = edges[j, 1];
                int weight = edges[j, 2];
                if (dist[u] != int.MaxValue && dist[u] + weight < dist[v]) {
                    dist[v] = dist[u] + weight;
                }
            }
        }

        Console.WriteLine();
        Console.WriteLine("Shortest distance from vertex 0 to vertex 4: {0}", dist[4]);

        Console.ReadKey();
    }
}
