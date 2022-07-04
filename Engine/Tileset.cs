using System.Numerics;
using Raylib_cs;

namespace Roguelike;

public class Tileset
{
    internal readonly Texture2D Texture;
    internal readonly Vector2 TileSize;

    public Tileset(Texture2D texture, Vector2 tileSize)
    {
        this.Texture = texture;
        this.TileSize = tileSize;
    }

    public Rectangle GetRect(uint tileX, uint tileY)
    {
        return new Rectangle(tileX * TileSize.X, tileY * TileSize.Y, TileSize.X, TileSize.Y);
    }
}