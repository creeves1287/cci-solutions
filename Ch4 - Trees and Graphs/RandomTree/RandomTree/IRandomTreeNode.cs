namespace RandomTree
{
    public interface IRandomTreeNode
    {
        TreeNode Left { get; set; }
        TreeNode Right { get; set; }
        TreeNode GetRandomNode();
        void InsertInOrder(int d);
    }
}