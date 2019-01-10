using System;
using System.Collections.Generic;
using System.Linq;
using NUnit;
using NUnit.Framework;

namespace graph_kit.tests
{
    public class Class1
    {
        abstract class RightVertex {
        }

        class GroupVertex : RightVertex {
        }

        class PrincipalVertex : RightVertex {
        }

        class SubjectVertex : RightVertex {
        }

        class RightsGraph
        {
        }

        class SomeGraph : IGraph<int>
        {
            public IEnumerable<int> GetAdjacent(int vertex)
            {
                switch (vertex)
                {
                    case 1:
                        yield return 11; yield return 12;
                        break;
                    case 11:
                        yield return 111; yield return 112;
                        break;
                    case 12:
                        yield return 121; yield return 122;
                        break;
                }
            }
        }

        [Test]
        public void TestBreadthFirstSearch()
        {
            var g = new SomeGraph();
            CollectionAssert.AreEqual(new[] { 1, 11, 12, 111, 112, 121, 122 }, g.BreadthFirstSearch(Enumerable.Repeat(1, 1), new HashSet<int>().Add));
        }

        [Test]
        public void TestDepthFirstSearch()
        {
            var g = new SomeGraph();
            var vertices = g
                .ConvertToPreOrder()
                .DepthFirstSearch(Enumerable.Repeat(1,1), new HashSet<int>().Add).ToList();
            foreach (var v in vertices) {
                TestContext.WriteLine(v);
            }
            CollectionAssert.AreEqual(new[] { 1, 11, 111, 112,  12, 121, 122 }, vertices);
        }
    }
}
