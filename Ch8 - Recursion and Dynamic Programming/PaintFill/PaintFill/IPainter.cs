namespace PaintFill
{
    public interface IPainter
    {
        void Fill(string[,] canvas, Point p, string color);
    }
}