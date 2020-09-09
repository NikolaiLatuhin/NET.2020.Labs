using System;
using System.Collections.Generic;

namespace BinarySearchTree.Core
{
    public class CompareTestStudent : IComparer<TestStudent>
    {
        public int Compare(TestStudent x, TestStudent y)
        {
            if (x is null || y is null)
            {
                throw new ArgumentNullException();
            }

            switch (string.CompareOrdinal(x.NameStudent, y.NameStudent))
            {
                case 1:
                    return 1;
                case 0:
                    return 0;
                default:
                    return -1;
            }
        }
    }
}
