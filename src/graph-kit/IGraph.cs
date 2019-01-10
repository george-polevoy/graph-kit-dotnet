using System;
using System.Collections.Generic;
using System.Linq;

namespace graph_kit
{
    public class LookupGraph<T> : IGraph<T>
    {
        private ILookup<T, T> _lookup;
        public IEnumerable<T> GetAdjacent(T start)
        {
            throw new NotImplementedException();
        }
    }
    public interface IGraph<T>
    {
        IEnumerable<T> GetAdjacent(T start);
    }
}
