using System.Numerics;
using System.Text;
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

    public Rectangle GetRect(char c)
    {
        var tileX = c % 16;
        var tileY = c / 16;
        return GetRect(tileX, tileY);
    }
    
    public Rectangle GetRect(int tileX, int tileY)
    {
        return new Rectangle(tileX * TileSize.X, tileY * TileSize.Y, TileSize.X, TileSize.Y);
    }
}