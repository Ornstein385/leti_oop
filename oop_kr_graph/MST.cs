using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

class MST
{
    private Dictionary<int, HashSet<int>> graph;
    private int[,] adjacencyMatrix;

    private int countOfMST = 0;

    public int CountOfTrees
    {
        get { return countOfMST; }
    }

    private static void DiagRefl(int[,] a)
    {
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = i + 1; j < a.GetLength(0); j++)
            {
                a[j, i] = a[i, j];
            }
        }
    }

    public MST(int[,] matrix)
    {
        this.adjacencyMatrix = matrix;
        DiagRefl(this.adjacencyMatrix);
    }

    public void Prim()
    {
        HashSet<int> unmarkedVertexes = new HashSet<int>();
        for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
        {
            unmarkedVertexes.Add(i);
        }
        PriorityQueue<Edge> edges = new PriorityQueue<Edge>();
        graph = new Dictionary<int, HashSet<int>>();
        countOfMST = 0;
        while (unmarkedVertexes.Count > 0)
        {
            if (edges.Count == 0)
            {
                countOfMST++;
                int vertex = unmarkedVertexes.FirstOrDefault();
                for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
                {
                    if (adjacencyMatrix[vertex, i] > 0)
                    {
                        edges.Enqueue(new Edge(adjacencyMatrix[vertex, i], vertex, i));
                    }
                }
                unmarkedVertexes.Remove(vertex);
            }
            while (edges.Count > 0)
            {
                Edge e = edges.Dequeue();
                if (unmarkedVertexes.Contains(e.v1) ^ unmarkedVertexes.Contains(e.v2))
                {
                    int vertex = -1;
                    if (unmarkedVertexes.Contains(e.v1))
                    {
                        vertex = e.v1;
                        if (!graph.ContainsKey(e.v2))
                        {
                            graph[e.v2] = new HashSet<int>();
                        }
                        graph[e.v2].Add(e.v1);
                    }
                    else
                    {
                        vertex = e.v2;
                        if (!graph.ContainsKey(e.v1))
                        {
                            graph[e.v1] = new HashSet<int>();
                        }
                        graph[e.v1].Add(e.v2);
                    }
                    for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
                    {
                        if (adjacencyMatrix[vertex, i] > 0)
                        {
                            edges.Enqueue(new Edge(adjacencyMatrix[vertex, i], vertex, i));
                        }
                    }
                    unmarkedVertexes.Remove(vertex);
                    break;
                }
            }
        }
    }

    public void PrintEdgeList()
    {
        long sum = 0;
        Console.WriteLine("ребра графа:");
        foreach (int i in graph.Keys)
        {
            foreach (int j in graph[i])
            {
                Console.WriteLine((char)('A' + i) + " <-> " + (char)('A' + j) + "  |" + adjacencyMatrix[i, j] + "|");
                sum += adjacencyMatrix[i, j];
            }
        }
        Console.WriteLine("сумма ребер: {0}", sum);
    }

    public void PrintGraph()
    {
        HashSet<int> unmarkedVertexes = new HashSet<int>();
        for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
        {
            unmarkedVertexes.Add(i);
        }
        while (unmarkedVertexes.Count > 0)
        {
            int ver = unmarkedVertexes.FirstOrDefault();
            PrintRec(ver, -1, unmarkedVertexes);
        }
    }

    private void PrintRec(int ver, int prev, HashSet<int> unmarkedVertexes)
    {
        unmarkedVertexes.Remove(ver);
        Console.Write("{ " + (char)('A' + ver));
        if (graph.ContainsKey(ver))
        {
            Console.Write(" -> ");
            foreach (int i in graph[ver])
            {
                PrintRec(i, ver, unmarkedVertexes);
            }
        }
        if (prev > -1)
        {
            Console.Write(" |" + adjacencyMatrix[ver, prev] + "|");
        }
        Console.Write(" } ");
    }
}
