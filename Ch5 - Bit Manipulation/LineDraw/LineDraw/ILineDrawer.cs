namespace LineDraw
{
    public interface ILineDrawer
    {
        void DrawLine(byte[] screen, int width, int x1, int x2, int y);
    }
}