using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomTree;

namespace RandomTreeTests
{
    [TestClass]
    public class RandomTreeTests
    {
        [TestMethod]
        public void RandomTreeTest()
        {
            RunTests<TreeNode>();
        }

        private void RunTests<TRandomNode>() where TRandomNode : IRandomTreeNode, new()
        {

        }
    }
}
