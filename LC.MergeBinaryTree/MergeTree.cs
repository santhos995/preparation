using ConstructBinaryTree;
using System;
using System.Collections.Generic;

namespace LC.MergeBinaryTree
{
    class MergeTree
    {
        static void Main(string[] args)
        {
            var node1 = BinaryTree.Construct(new int[] { 1, 3, 2, 5 });
            var node2 = BinaryTree.Construct(new int[] { 2, 1, 3, int.MinValue, 4, int.MinValue, 7 });

            var res = new Solution().MergeTrees(node1, node2);
        }

        public class Solution
        {
            public TreeNode MergeTrees(TreeNode root1, TreeNode root2)
            {
                if (root1 == null) return root2;
                if (root2 == null) return root1;

               return dfs(root1, root2);
            }
            private TreeNode dfs(TreeNode l, TreeNode r)
            {
                if (l == null) return r;
                else if (r == null) return l;
                else
                {
                    l.left = dfs(l.left, r.left);
                    l.val += r.val;
                    l.right = dfs(l.right, r.right);
                    return l;
                }
            }
            private TreeNode parseNode(TreeNode l, TreeNode r)
            {
                if (l == null) return r;
                else if (r == null) return l;
                else
                {
                    l.val = r.val;
                    return l;
                }
            }
        }
    }
}
