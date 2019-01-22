using GraphsInfrastructure;
using System.Collections.Generic;

namespace BSTSequencers
{
    public interface IBSTSequencer
    {
        List<LinkedList<int>> SequenceBST(BinaryTreeNode root);
    }
}