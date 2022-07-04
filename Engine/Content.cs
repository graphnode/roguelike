namespace Roguelike;

public static partial class Engine
{
    public static string GetAssetPath(string path)
    {
        return Path.Combine("Assets", path);
    }

}