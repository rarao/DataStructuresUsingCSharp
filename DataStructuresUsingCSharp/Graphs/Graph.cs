using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresUsingCSharp.Graphs
{
    //Adjacency matrix
    public class AmGraph
    {
        public int V;
        public int E;
        public int[][] am;
        public AmGraph(int v, int e)
        {
            V = v;
            E = e;

            for (int i = 0; i < v; i++)
            {
                for (int j = 0; j < e; j++)
                {
                    am[i][j] = 0;
                }
            }
        }
    }
    public class AlGraph
    {
        public int V;
        public int E;
        public List<LinkedList<int>> al;
        public AlGraph(int v, int e)
        {
            V = v;
            E = e;

            al = new List<LinkedList<int>>();
            for (int i = 0; i < v; i++)
            {
                LinkedList<int> list = new LinkedList<int>();
                al.Add(list);
            }
        }
    }
    public class Graph
    {
        public static AlGraph CreateAlGraph()
        {
            int v = Convert.ToInt32(Console.ReadLine().Split()[0]);
            int e = Convert.ToInt32(Console.ReadLine().Split()[1]);
            AlGraph gp = new AlGraph(v, e);

            for (int i = 0; i < e; i++)
            {
                int v1 = Convert.ToInt32(Console.ReadLine().Split()[0]);
                int v2 = Convert.ToInt32(Console.ReadLine().Split()[1]);
                gp.al[v1].AddFirst(v2);
            }

            return gp;
        }
        public static AmGraph CreateAmGraph()
        {
            int v = Convert.ToInt32(Console.ReadLine().Split()[0]);
            int e = Convert.ToInt32(Console.ReadLine().Split()[1]);
            AmGraph gp = new AmGraph(v, e);

            for (int i = 0; i < e; i++)
            {
                int v1 = Convert.ToInt32(Console.ReadLine().Split()[0]);
                int v2 = Convert.ToInt32(Console.ReadLine().Split()[1]);
                gp.am[v1][v2] = 1;
                gp.am[v2][v1] = 1; //Incase of undirected graph
            }

            return gp;
        }
    }
}
