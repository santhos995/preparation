using System;
using System.Collections.Generic;

namespace ConstructBinaryTree
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    public class BinaryTree
    {
        public static TreeNode Construct(List<string> values)
        {
            int[] ar = new int[values.Count];
            for (int i = 0; i < values.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(values[i]))
                    ar[i] = int.MinValue;
                else
                    ar[i] = Convert.ToInt32(values[i]);
            }
            return Construct(ar, 0);
        }
        public static TreeNode Construct(int[] ar)
        {
            return Construct(ar, 0);
        }

        private static TreeNode Construct(int[] ar, int i)
        {
            if (i < ar.Length && ar[i] != int.MinValue)
            {
                var node = new TreeNode(ar[i]);
                node.left = Construct(ar, (2 * i) + 1);
                node.right = Construct(ar, (2 * i) + 2);
                return node;
            }
            return null;
        }

    }
}
