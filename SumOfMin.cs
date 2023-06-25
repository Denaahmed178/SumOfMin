using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    public static class SumOfMin
    {
        static bool [] visited ;
        #region YOUR CODE IS HERE
        //Your Code is Here:
        //==================
        /// <summary>
        /// Given an UNDIRECTED Graph, calculate the sum of the min value in each connected component
        /// </summary>
        /// <param name="valuesOfVertices">value of each vertex (vertices are named from 0 to |V| - 1)</param>
        /// <param name="edges">array of edges in the graph</param>
        /// <returns>sum of the min value in each component of the graph</returns>
        public static int CalcSumOfMinInComps(int[] valuesOfVertices, KeyValuePair<int, int>[] edges)
        {
            //REMOVE THIS LINE BEFORE START CODING
            //throw new NotImplementedException();
            visited = new bool[valuesOfVertices.Length];
            var graph = CreateAdjacencyList(valuesOfVertices, edges);
            var sums = new List<int>();
           
            for (int i = 0; i < valuesOfVertices.Length; i++)
            {
                if (graph[i].Count == 0)
                {
                    sums.Add(valuesOfVertices[i]);
                }
                else if (graph[i].Count != 0 && !visited[i])
                {
                    sums.Add(bfs(i, graph, valuesOfVertices));
                }
            }

            // Calculate and return the sum of minimum values
            return sums.Sum();
        }
        public static int bfs(int vertex, List<int>[] graph, int[] valuesOfVertices)
        {
            var q = new Queue<int>();
            var minVal = int.MaxValue;
            q.Enqueue(vertex);
            visited[vertex] = true;
            while (q.Count > 0)
            {
                var node = q.Dequeue();
                
                minVal = Math.Min(minVal, valuesOfVertices[node]);
                foreach(var i in graph[node])
                {
                    if (!visited[i]) { q.Enqueue(i);
                        visited[i] = true;
                    }
                }
               
            }

            return minVal;
        }
        public static List<int>[] CreateAdjacencyList(int[] valuesOfVertices, KeyValuePair<int, int>[] edges)
        {
            // Build the graph
            var graph = new List<int>[valuesOfVertices.Length];
           // var graph = new Dictionary<int, List<int>>();
            for (int i = 0; i < valuesOfVertices.Length; i++)
            {
               graph[i] = new List<int> { };
                visited[i] = false;
            }
            for (int j = 0; j < edges.Length; j++)
            {
                graph[edges[j].Key].Add(edges[j].Value);
                graph[edges[j].Value].Add(edges[j].Key);
            }

            return graph;
            //edges.
        }
        #endregion
    }
}