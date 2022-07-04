using System.Globalization;
using Raylib_cs;

namespace Roguelike.Extensions;

public static class ColorEx
{
    public static string ToHexString(this Color c)
    {
        return $"#{c.r:X2}{c.g:X2}{c.b:X2}";
    }
    
    /// <summary>
    /// Implicitly converts hex string to color.
    /// </summary>
    /// <param name="str">The hex string to convert.</param>
    /// <returns>A Color instance.</returns>
    public static Color FromHexString(string str)
    {
        var hex = str.Replace("#", string.Empty);
        const NumberStyles numberStyle = NumberStyles.HexNumber;
        
        var r = byte.Parse(hex[..2], numberStyle);
        var g = byte.Parse(hex[2..4], numberStyle);
        var b = byte.Parse(hex[4..6], numberStyle);

        return new Color(r, g, b, byte.MaxValue);
    }
    
    public static Color DARKESTGRAY = new Color(32, 32, 32, (int)byte.MaxValue);
}
