using System.Numerics;
using Roguelike.ECS.Components;
using Roguelike.Utilities;

namespace Roguelike.ECS.Systems;

using static Raylib_cs.Raylib;

public class RenderingSystem : System<Position, Renderable>
{
    private readonly Tileset tileset;

    public RenderingSystem(Tileset tileset)
    {
        this.tileset = tileset;
    }
    
    public override void Process(Entity e)
    {
        var position = e.Get<Position>()!;
        var renderable = e.Get<Renderable>()!;
        
        DrawTextureRec(tileset.Texture,  tileset.GetRect(renderable.Glyph), new Vector2(position.X, position.Y) * tileset.TileSize, renderable.ForegroundColor);
    }
}