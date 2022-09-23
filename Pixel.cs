using System.Drawing;
public class Pixel
{
    public Pixel(byte r, byte g, byte b)
    {
        R = r;
        G = g;
        B = b;
    }

    public Pixel(Color color)
    {
        R = color.R;
        G = color.G;
        B = color.B;
    }

    public byte R { get; }
    public byte G { get; }
    public byte B { get; }
}
