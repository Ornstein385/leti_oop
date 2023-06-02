using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Edge : IComparable<Edge>
{
    public int weight;
    public int v1, v2;

    public Edge(int weight, int v1, int v2)
    {
        this.weight = weight;
        this.v1 = v1;
        this.v2 = v2;
    }

    public int CompareTo(Edge o)
    {
        return weight - o.weight;
    }
}
