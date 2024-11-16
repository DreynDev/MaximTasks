using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximTasks.SortingAlgorithms
{
    public class TreeNode
    {
        public char Value;
        public TreeNode Left;
        public TreeNode Right;

        public TreeNode(char value)
        {
            Value = value;
            Left = null;
            Right = null;
        }

        public void Insert(char value)
        {
            if (value < Value)
            {
                if (Left == null)
                    Left = new TreeNode(value);
                else
                    Left.Insert(value);
            }
            else
            {
                if (Right == null)
                    Right = new TreeNode(value);
                else
                    Right.Insert(value);
            }
        }

        public void InOrderTraversal(List<char> result)
        {
            if (Left != null)
                Left.InOrderTraversal(result);

            result.Add(Value);

            if (Right != null)
                Right.InOrderTraversal(result);
        }
    }

    public class TreeSortClass
    {
        public static string SortedString(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            TreeNode root = new TreeNode(input[0]);

            for (int i = 1; i < input.Length; i++)
            {
                root.Insert(input[i]);
            }

            List<char> sortedList = new List<char>();
            root.InOrderTraversal(sortedList);

            return new string(sortedList.ToArray());
        }
    }
}
