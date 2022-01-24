using System;
using System.Diagnostics.Contracts;


namespace ConsoleApp3
{
    [Serializable]
    public partial class QuadTree<T>
    {
        public readonly int MaximumElementsPerNode;
        private readonly Rectangle region;
        private readonly Node<T> root;

        public Rectangle Region
        {
            get { return region; }
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(MaximumElementsPerNode > 0);
        }

        public QuadTree(int maximumElementsPerNode, Rectangle region)
        {
            if (maximumElementsPerNode < 0) throw new ArgumentOutOfRangeException();

            MaximumElementsPerNode = maximumElementsPerNode;
            this.region = region;
            root = new Node<T>(region, null, maximumElementsPerNode);
        }

        public bool Add(Point point, T element)
        {
            if (element == null) throw new ArgumentNullException();

            var current = root;
            while (current.IsInRegion(point))
            {
                var node = current.GetContainingChild(point);
                if (node == null)
                {
                    current.Add(point, element);
                    break;
                }
                else
                {
                    current = node;
                }
            }

            return true;
        }

        public object FindNode(Point point)
        {
            foreach (var current in root.Value)
            {
                var node = current as Retailer;
                int xDecimalPoints = point.X.ToString().Split('.')[1].Length;
                int yDecimalPoints = point.Y.ToString().Split('.')[1].Length;
                if (Math.Round(point.X, xDecimalPoints) == Math.Round(node.XCoordinate, xDecimalPoints) && Math.Round(point.Y, yDecimalPoints) == Math.Round(node.YCoordinate, yDecimalPoints))
                {
                    return node;
                }
            }

            return null;
        }
    }
}
