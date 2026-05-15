namespace PlayersGuide.Level24.Catacombs;

public class Color
{
    public byte R { get; }
    public byte G { get; }
    public byte B { get; }

    public Color(byte red, byte green, byte blue)
    {
        R = red;
        G = green;
        B = blue;
    }

    public static Color White { get; } = new(255, 255, 255);
    public static Color Black { get; } = new(0, 0, 0);
    public static Color Red { get; } = new(255, 0, 0);
    public static Color Orange { get; } = new(255, 165, 0);
    public static Color Yellow { get; } = new(255, 255, 0);
    public static Color Green { get; } = new(0, 128, 0);
    public static Color Blue { get; } = new(0, 0, 255);
    public static Color Purple { get; } = new(128, 0, 128);
}
