using Raylib_cs;

namespace Roguelike;

public class Entity
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public char Symbol { get; }
    public Color Color { get; }
    
    public Entity(int x, int y, char symbol, Color color)
    {
        X = x;
        Y = y;
        Symbol = symbol;
        Color = color;
    }

    public void Move(int dx, int dy)
    {
        X += dx;
        Y += dy;
    }
}