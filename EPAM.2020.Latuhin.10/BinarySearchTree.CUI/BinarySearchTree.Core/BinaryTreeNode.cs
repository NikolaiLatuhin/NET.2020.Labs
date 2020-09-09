using System;

namespace BinarySearchTree.Core
{
    public class BinaryTreeNode<TNodeTree> : IComparable<TNodeTree> where TNodeTree : IComparable
    {
        public BinaryTreeNode<TNodeTree> Left { get; set; }
        public BinaryTreeNode<TNodeTree> Right { get; set; }
        public TNodeTree Value { get; set; }

        public BinaryTreeNode(TNodeTree nodeValue)
        {
            Value = nodeValue;
        }

        public int CompareTo(TNodeTree other)
        {
            var resultCompare = Value.CompareTo(other);
            return resultCompare;
        }
    }
}
