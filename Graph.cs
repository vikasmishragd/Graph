using System;
using System.Collections.Generic;
using System.Text;

namespace Graph11
{
    public class Graph
    {

        Dictionary<string, List<string>> adjecencyList;
        public Graph()
        {
            adjecencyList = new Dictionary<string, List<string>>();
        }

        public void CreateConnection(string source, string destination)
        {   List<string> values;
            if(adjecencyList.ContainsKey(source))
            {
                adjecencyList.TryGetValue(source, out values);
                if (!values.Contains(destination))
                    values.Add(destination);
                adjecencyList.Remove(source);
                adjecencyList.Add(source, values);
            }
            else
                adjecencyList.Add(source, new List<string> { destination});
        }
        public void CreateConnectionUndirected(string source, string destination)
        {
            List<string> values;
            if (adjecencyList.ContainsKey(source))
            {
                adjecencyList.TryGetValue(source, out values);
                if (!values.Contains(destination))
                    values.Add(destination);
                adjecencyList.Remove(source);
                adjecencyList.Add(source, values);
            }
            else
            {
                if (source != null && !adjecencyList.ContainsKey(source))
                    adjecencyList.Add(source, new List<string> { destination });
            }
            if (destination != null && adjecencyList.ContainsKey(destination))
            {
                adjecencyList.TryGetValue(destination, out values);
                if (!values.Contains(source))
                    values.Add(source);
                adjecencyList.Remove(destination);
                adjecencyList.Add(destination, values);
            }
            else
            {
                if(destination != null && !adjecencyList.ContainsKey(destination) )
                adjecencyList.Add(destination, new List<string> { source });

                //adjecencyList.TryGetValue(destination, out values);
                //if (!values.Contains(source))
                //    values.Add(source);
                //adjecencyList.Remove(destination);
                //adjecencyList.Add(destination, values);
            }
        }

        public int GetConnectedComponent()
        {
            var visited = new List<string>();
            int count = 0;
            foreach(var node in adjecencyList)
            {
                var localConnectedCount = new List<string>();
                if (Explore(node.Key, visited, localConnectedCount))
                {
                    count += 1;
                    Console.WriteLine("Max count : "+localConnectedCount.Count);
                }
            }
            return count;
        }

        private bool Explore(string key, List<string> visited, List<string> localConnectedCount)
        {
            
            if (visited.Contains(key))
                return false;
            if (key == null)
                return false;

            visited.Add(key);
            localConnectedCount.Add(key);
            adjecencyList.TryGetValue(key, out List<string> neighoburs);
            foreach (var node in neighoburs)
            {
                Explore(node, visited,localConnectedCount);
            }
            return true;
        }

        public bool HasPathUndirected(string source, string destination, List<string> visited)
        {
            if (source == destination)
                return true;

            adjecencyList.TryGetValue(source, out List<string> neighoburs);

            if (visited.Contains(source))
                return false;
            visited.Add(source);

            foreach(var node in neighoburs)
            {
                if(node!=null && HasPathUndirected(node,destination,visited))
                {
                    return true;
                }
            }
            return false;
        }

        public void DFS(string startNode)
        {
            var stack = new Stack<string>();
            stack.Push(startNode);
            while (stack.Count > 0)
            {
                var current = stack.Pop();

                Console.WriteLine(current);
                adjecencyList.TryGetValue(current, out List<string> neighoburs);
                foreach (var nodes in neighoburs)
                {
                    if (nodes != null)
                        stack.Push(nodes);
                }

            }
        }

        public void BFS(string startNode)
        {
            var queue = new Queue<string>();
            queue.Enqueue(startNode);
            while(queue.Count >0)
            {
                var current = queue.Dequeue();
                Console.WriteLine(current);
                adjecencyList.TryGetValue(current, out List<string> neighoburs);
                foreach (var nodes in neighoburs)
                {
                    if (nodes != null)
                        queue.Enqueue(nodes);
                }

            }
        }

        public void DFSRecursion(string startNode)
        {
            Console.WriteLine(startNode);
            adjecencyList.TryGetValue(startNode, out List<string> neighoburs);
            foreach (var item in neighoburs)
            {
                if (item != null)
                    DFSRecursion(item);
            }
        }

        public bool PathExistsBetweenVertexs(string source, string destination)
        {
            var queue = new Queue<string>();
            queue.Enqueue(source);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                Console.WriteLine(current);
                adjecencyList.TryGetValue(current, out List<string> neighoburs);
                foreach (var nodes in neighoburs)
                {
                    if (nodes != null)
                        queue.Enqueue(nodes);

                    if(queue.Contains(destination))
                    {
                        return true;
                    }
                }

            }
            return false;
        }

        public bool PathExistsRecursion(string source, string detination)
        {
            if (source == detination)
                return true;
            adjecencyList.TryGetValue(source, out List<string> neighoburs);

            foreach(string node in neighoburs)
            {
                if(node != null && PathExistsRecursion(node,detination))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
