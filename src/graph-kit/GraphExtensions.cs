using System;
using System.Collections.Generic;

namespace graph_kit
{
    public class PreOrderConversionGraph<T> : IGraph<T>
    {
        private IGraph<T> _target;
        public PreOrderConversionGraph(IGraph<T> target) {
            _target = target;
        }
        
        /// <summary>
        ///  Reverses the adjacency list for the vertex.
        ///  It is important to call Pop for more effective garbage collection of popped items.
        /// </summary>
        public IEnumerable<T> GetAdjacent(T start)
        {
            var s = new Stack<T>(_target.GetAdjacent(start));
            while (s.TryPop(out var v)) {
                yield return v;
            }
        }
    }

    public static class GraphAlgorithms
    {
        public static IGraph<T> ConvertToPreOrder<T>(this IGraph<T> graph) {
                return new PreOrderConversionGraph<T>(graph);
        }

        public static IEnumerable<T> BreadthFirstSearch<T>(this IGraph<T> graph, IEnumerable<T> start, Func<T, bool> mark)
        {
            var s = new Queue<T>();
            foreach(var v in start)
            {
                s.Enqueue(v);
            }

            while (s.Count > 0)
            {
                var current = s.Dequeue();
                if (mark(current))
                {
                    yield return current;
                    foreach (var child in graph.GetAdjacent(current))
                    {
                        s.Enqueue(child);
                    }
                }
            }
        }

        public static IEnumerable<T> DepthFirstSearch<T>(this IGraph<T> graph, IEnumerable<T> start, Func<T, bool> mark)
        {
            var s = new Stack<T>();
            foreach(var v in start)
            {
                s.Push(v);
            }
            
            while (s.Count > 0)
            {
                var current = s.Pop();
                if (mark(current))
                {
                    yield return current;
                }
                foreach (var child in graph.GetAdjacent(current))
                {
                    s.Push(child);
                }
            }
        }
    }
}
