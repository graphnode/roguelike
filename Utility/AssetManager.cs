using Raylib_cs;

namespace Roguelike.Utility;

public static class AssetManager
{
    public static string GetPath(string path)
    {
        return Path.Combine("Assets", path);
    }

    public static Texture2D LoadTexture(string path)
    {
        return Raylib.LoadTexture(GetPath(path));
    }
    
    public static Image LoadImage(string path)
    {
        return Raylib.LoadImage(GetPath(path));
    }
}