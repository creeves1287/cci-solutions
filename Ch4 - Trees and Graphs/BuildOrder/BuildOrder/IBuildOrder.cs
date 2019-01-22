namespace BuildOrder
{
    public interface IBuildOrder
    {
        string[] GetBuildOrder(string[] projects, string[][] dependencies);
    }
}