using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;


namespace ConsoleApp3
{
    public partial class QuadTree<T>
    {
        [Serializable]
        class Node<T>
        {
            private List<T> values = new List<T>();
            private readonly Rectangle region;
            public readonly int MaximumValuesPerNode;

            public IEnumerable<T> Value
            {
                get { return values.AsReadOnly(); }
            }
            public int Count
            {
                get { return values.Count; }
            }
            public Node<T> Parent { get; set; }
            internal Rectangle Region
            {
                get { return region; }
            }
            public Children<T> Children { get; set; }

            [ContractInvariantMethod]
            private void ObjectInvariant()
            {
                Contract.Invariant(values != null);
                Contract.Invariant(values.Count <= MaximumValuesPerNode);
            }

            public Node(Rectangle rectangle, Node<T> parent, int maximumValuesPerNode)
            {
                if (maximumValuesPerNode == 0) throw new ArgumentOutOfRangeException();

                Parent = parent;
                region = rectangle;
                this.MaximumValuesPerNode = maximumValuesPerNode;
                Children = new NullChildren<T>(parent);
            }
            public bool IsInRegion(Point p)
            {
                return region.IsInRectangle(p);
            }
            public Node<T> GetContainingChild(Point point)
            {
                return Children.GetContainingChild(point);
            }
            private void SplitRegionIntoChildNodes()
            {
                Children = new Children<T>(region, this, MaximumValuesPerNode);
            }

            public void Add(Point point, T element)
            {
                if (element == null) throw new ArgumentNullException();

                if (Count == MaximumValuesPerNode)
                {
                    SplitRegionIntoChildNodes();
                }
                else
                {
                    values.Add(element);
                }
            }

            public bool Equals(Node<T> otherNode)
            {
                if (otherNode == null)
                {
                    return false;
                }
                return values.Equals(otherNode.Value);
            }

            public override bool Equals(object obj)
            {
                var otherNode = obj as Node<T>;
                if (otherNode == null)
                {
                    return false;
                }
                return values.Equals(otherNode.Value);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    int hash = 17;
                    hash = hash * 23 + values.GetHashCode();
                    return hash;
                }
            }
        }
    }
}
