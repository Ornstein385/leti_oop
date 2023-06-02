using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int[,] matrix = new int[,]{
                {0,20,0,0,27,0,0,0,0,0},
                {0,0,28,0,0,19,0,0,0,0},
                {0,0,0,0,0,31,27,0,0,0},
                {0,0,0,0,16,0,0,22,0,0},
                {0,0,0,0,0,13,0,17,18,0},
                {0,0,0,0,0,0,30,0,24,29},
                {0,0,0,0,0,0,0,0,0,26},
                {0,0,0,0,0,0,0,0,29,0},
                {0,0,0,0,0,0,0,0,0,25},
                {0,0,0,0,0,0,0,0,0,0}
            };

        int[,] matrix1 = new int[,]{
                {0,3,1,2,0,0,0,0},
                {0,0,0,0,4,0,0,0},
                {0,0,0,10,0,0,0,0},
                {0,0,0,0,20,0,0,0},
                {0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,5,0},
                {0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0},
            };

        MST mst = new MST(matrix);
        mst.Prim();
        mst.PrintGraph();
        Console.WriteLine();
        mst.PrintEdgeList();
        Console.WriteLine("количество остовных деревьев: " + mst.CountOfTrees);
    }
}