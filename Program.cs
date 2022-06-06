using System;

namespace Graph11
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();


            //graph.CreateConnection("A", "C");
            //graph.CreateConnection("A", "B");
            //graph.CreateConnection("B", "D");
            //graph.CreateConnection("C", "E");
            //graph.CreateConnection("D", "F");
            //graph.CreateConnection("E", null);
            //graph.CreateConnection("F", null);
            //           A
            //          / \
            //         B   C
            //        /     \
            //       D      E
            //      /
            //     F
            //graph.CreateConnection("F", "G");
            //graph.CreateConnection("F", "I");
            //graph.CreateConnection("G", "H");
            //graph.CreateConnection("H", null);
            //graph.CreateConnection("I", "G");
            //graph.CreateConnection("I", "K");
            //graph.CreateConnection("J", "I");
            //graph.CreateConnection("K", null);


            graph.CreateConnectionUndirected("F", "G");
            graph.CreateConnectionUndirected("F", "I");
            graph.CreateConnectionUndirected("G", "H");
            graph.CreateConnectionUndirected("H", null);
            graph.CreateConnectionUndirected("I", "G");
            graph.CreateConnectionUndirected("I", "K");
            graph.CreateConnectionUndirected("J", "I");
            graph.CreateConnectionUndirected("K", null);


            // graph.BFS("A");
            // Console.WriteLine(graph.PathExistsBetweenVertexs("J", "F"));
           // Console.WriteLine(graph.PathExistsRecursion("J","H"));
        }
    }
}
