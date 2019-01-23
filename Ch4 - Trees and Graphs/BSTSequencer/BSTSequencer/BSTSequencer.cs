using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphsInfrastructure;

namespace BSTSequencers
{
    public class BSTSequencer : IBSTSequencer
    {
        public List<LinkedList<int>> SequenceBST(BinaryTreeNode root)
        {
            List<LinkedList<int>> results = new List<LinkedList<int>>();
            if (root == null)
            {
                LinkedList<int> result = new LinkedList<int>();
                results.Add(result);
                return results;
            }
            LinkedList<int> prefix = new LinkedList<int>();
            prefix.AddFirst(root.Value);
            List<LinkedList<int>> leftSequences = SequenceBST(root.Left);
            List<LinkedList<int>> rightSequences = SequenceBST(root.Right);
            foreach (LinkedList<int> left in leftSequences)
            {
                foreach (LinkedList<int> right in rightSequences)
                {
                    List<LinkedList<int>> weaved = new List<LinkedList<int>>();
                    WeaveLists(left, right, weaved, prefix);
                    results.AddRange(weaved);
                }
            }
            return results;
        }

        private void WeaveLists(LinkedList<int> left, LinkedList<int> right,
            List<LinkedList<int>> results, LinkedList<int> prefix)
        {
            if (left.Count == 0 || right.Count == 0)
            {
                LinkedList<int> result = new LinkedList<int>();
                AddAll(prefix, result);
                AddAll(left, result);
                AddAll(right, result);
                results.Add(result);
                return;
            }
            PrefixAndWeave(left, right, results, prefix);
            PrefixAndWeave(right, left, results, prefix);
        }

        private void PrefixAndWeave(LinkedList<int> listToPrefix, LinkedList<int> listToWeave, List<LinkedList<int>> weaved, LinkedList<int> prefix)
        {
            int headLeft = listToPrefix.First.Value;
            listToPrefix.RemoveFirst();
            prefix.AddLast(headLeft);
            WeaveLists(listToPrefix, listToWeave, weaved, prefix);
            prefix.RemoveLast();
            listToPrefix.AddFirst(headLeft);
        }

        private void AddAll(LinkedList<int> source, LinkedList<int> destination)
        {
            foreach (int data in source)
            {
                destination.AddLast(data);
            }
        }
    }
}
