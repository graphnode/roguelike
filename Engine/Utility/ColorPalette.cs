using System.Text.Json;
using System.Text.Json.Serialization;
using Raylib_cs;
using Roguelike.Extensions;

namespace Roguelike.Utility;

//#pragma warning disable IL2026

public class ColorPalette
{
    private Dictionary<string, Color> _colors = new();

    public Color this[string key] => _colors.TryGetValue(key, out var value) ? value : default;
    
    public static ColorPalette LoadFromJson(string assetPath)
    {
        var path = AssetManager.GetPath(assetPath);
        var jsonString = File.ReadAllText(path);
        
        var options = new JsonSerializerOptions();
        options.Converters.Add(new ColorJsonConverter());
        
        var colors = JsonSerializer.Deserialize<Dictionary<string, Color>>(jsonString, options) ?? new Dictionary<string, Color>();
        
        return new ColorPalette
        {
            _colors = colors
        };
    }
}

internal class ColorJsonConverter : JsonConverter<Color>
{
    public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return ColorEx.FromHexString(reader.GetString()!);
    }

    public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToHexString());
    }
}