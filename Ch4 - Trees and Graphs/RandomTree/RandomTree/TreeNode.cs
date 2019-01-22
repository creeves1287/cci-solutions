using GraphsInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomTree
{
    public class TreeNode : BinaryTreeNode<int>, IRandomTreeNode
    {
        public int Size { get; set; } = 0;
        public new TreeNode Left { get; set; }
        public new TreeNode Right { get; set; }

        public TreeNode(int data)
            : base (data)
        {
            Size = 1;
        }

        public TreeNode GetRandomNode()
        {
            int leftSize = (Left == null) ? 0 : Left.Size;
            Random random = new Random();
            int index = random.Next(Value);
            if (index <= leftSize)
            {
                return Left.GetRandomNode();
            }
            else if (index == leftSize)
            {
                return this;
            }
            else
            {
                return Right.GetRandomNode();
            }
        }

        public void InsertInOrder(int d)
        {
            if (d <= Value)
            {
                if (Left == null)
                    Left = new TreeNode(d);
                Left.InsertInOrder(d);
            }
            else
            {
                if (Right == null)
                    Right = new TreeNode(d);
                Right.InsertInOrder(d);
            }
            Size++;
        }
    }
}
