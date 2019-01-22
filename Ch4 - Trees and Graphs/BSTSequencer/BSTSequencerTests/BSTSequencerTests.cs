using System;
using System.Collections.Generic;
using System.Text;
using BSTSequencers;
using GraphsInfrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BSTSequencerTests
{
    [TestClass]
    public class BSTSequencerTests
    {
        [TestMethod]
        public void BSTSequencerTest()
        {
            IBSTSequencer sequencer = new BSTSequencer();
            RunTests(sequencer);
        }

        private void RunTests(IBSTSequencer sequencer)
        {
            RunNullTest(sequencer);
            RunSequenceTest(sequencer);
        }

        private void RunNullTest(IBSTSequencer sequencer)
        {
            BinaryTreeNode root = null;
            List<LinkedList<int>> result = sequencer.SequenceBST(root);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(0, result[0].Count);
        }

        private void RunSequenceTest(IBSTSequencer sequencer)
        {
            BinaryTreeNode root = GetTree();
            List<LinkedList<int>> result = sequencer.SequenceBST(root);
            Assert.AreEqual(true, result.Count > 0);
            foreach (LinkedList<int> sequenceList in result)
            {
                string sequence = GetSequence(sequenceList);
                Console.WriteLine(sequence);
            }
        }

        private string GetSequence(LinkedList<int> sequenceList)
        {
            StringBuilder sequence = new StringBuilder();
            foreach (int item in sequenceList)
            {
                sequence.Append(item);
                if (item != sequenceList.Last.Value)
                {
                    sequence.Append(", ");
                }
            }
            return sequence.ToString();
        }

        private BinaryTreeNode GetTree()
        {
            BinaryTreeNode root = new BinaryTreeNode
            {
                Value = 15,
                Left = new BinaryTreeNode
                {
                    Value = 9,
                    Left = new BinaryTreeNode
                    {
                        Value = 6,
                        Left = null,
                        Right = null
                    },
                    Right = new BinaryTreeNode
                    {
                        Value = 10,
                        Left = null,
                        Right = null
                    }
                },
                Right = new BinaryTreeNode
                {
                    Value = 21,
                    Left = new BinaryTreeNode
                    {
                        Value = 19,
                        Left = null,
                        Right = null
                    },
                    Right = new BinaryTreeNode
                    {
                        Value = 20,
                        Left = null,
                        Right = null
                    }
                }
            };
            return root;
        }
    }
}
