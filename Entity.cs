using Raylib_cs;
using Roguelike.Components;

namespace Roguelike;

public class Entity
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public char Glyph { get; }
    public Color Color { get; }

    private readonly HashSet<IComponent> components = new();
    
    public Entity(int x, int y, char glyph, Color color, IEnumerable<IComponent>? newComponents = null)
    {
        X = x;
        Y = y;
        Glyph = glyph;
        Color = color;

        if (newComponents != null)
            foreach (var component in newComponents)
                components.Add(component);
    }

    public void Move(int dx, int dy)
    {
        X += dx;
        Y += dy;
    }

    public void Update()
    {
        foreach (var component in components)
            component.Process(this);
    }

    public bool AddComponent(IComponent component) => components.Add(component);
    public bool RemoveComponent(IComponent component) => components.Remove(component);
}