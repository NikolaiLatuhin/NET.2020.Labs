using System;
using System.Collections;
using System.Collections.Generic;

namespace BinarySearchTree.Core
{
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable
    {
        private BinaryTreeNode<T> _root;
        private IComparer<T> _comparer;

        public void Insert(T nodeValue)
        {
            if (_root == null)
            {
                _root = new BinaryTreeNode<T>(nodeValue);
            }
            else
            {
                InsertNode(_root, nodeValue);
            }
        }

        private void InsertNode(BinaryTreeNode<T> node, T value)
        {
            // добавляется значение меньше значения узла
            if (value.CompareTo(node.Value) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new BinaryTreeNode<T>(value);
                }
                else
                {
                    InsertNode(node.Left, value);
                }
            }
            // добавляется значение больше или равно значению узла.
            else
            {
                if (node.Right == null)
                {
                    node.Right = new BinaryTreeNode<T>(value);
                }
                else
                {
                    InsertNode(node.Right, value);
                }
            }
        }

        public BinaryTree(IEnumerable<T> collectionElements, IComparer<T> comparer)
        {
            if (collectionElements is null)
            {
                throw new ArgumentNullException();
            }

            _comparer = comparer ?? Comparer<T>.Default;

            foreach (var elem in collectionElements)
            {
                Insert(elem);
            }
        }


        public IEnumerator<T> GetEnumerator()
        {
            return OrderSort().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<T> OrderSort() => OrderSort(_root);

        private IEnumerable<T> OrderSort(BinaryTreeNode<T> node)
        {
            while (true)
            {
                if (node == null)
                {
                    yield break;
                }

                foreach (var el in OrderSort(node.Left))
                {
                    yield return el;
                }

                yield return node.Value;
                node = node.Right;
            }
        }
    }
}
