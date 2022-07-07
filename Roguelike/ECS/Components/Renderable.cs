using Raylib_cs;

namespace Roguelike.ECS.Components;

public class Renderable : IComponent
{
    public char Glyph { get; set; }
    public Color ForegroundColor { get; set; }
    public Color BackgroundColor { get; set; }
}