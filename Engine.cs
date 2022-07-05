using System.Numerics;
using System.Reflection;
using Raylib_cs;
using Roguelike.Components;
using Roguelike.Utility;

using static Raylib_cs.Raylib;

namespace Roguelike;

public class Engine
{
    private static Vector2 TileSize => new(16, 16);
    
    private readonly HashSet<Entity> entities = new();
    private Tileset? _tileset;
    private ColorPalette? _palette;

    private void Initialize()
    {
        _tileset = new Tileset(AssetManager.LoadTexture("16x16-RogueYun-AgmEdit.png"), TileSize);
        _palette = ColorPalette.LoadFromJson("AfterglowTheme.json");
        
        entities.Add(new Entity(20, 20, '@', _palette["White"]));
        entities.Add(new Entity(15, 20, '@', _palette["Yellow"], new [] { new PlayerControlled() }));
    }
    
    private void Update()
    {
        foreach (var entity in entities)
            entity.Update();

        if (IsKeyPressed(KeyboardKey.KEY_ESCAPE))
            Environment.Exit(0);
    }

    private void Draw()
    {
        foreach (var entity in entities)
            DrawTextureRec(_tileset!.Texture,  _tileset.GetRect(entity.Glyph), new Vector2(entity.X, entity.Y) * TileSize, entity.Color);
    }

    private string GenerateTitle()
    {
        const string baseTitle = "Roguelike";
        var version = Assembly.GetEntryAssembly()?.GetName().Version;
        return version == null ? baseTitle : $"{baseTitle} v{version.ToString(3)}";
    }
    
    public void Run()
    {
        var title = GenerateTitle();

        TraceLog(TraceLogLevel.LOG_INFO, $"Starting {title}");

        InitWindow(800, 640, title);
        SetWindowIcon(AssetManager.LoadImage("icon.png"));
        SetTargetFPS(60);
        SetExitKey(KeyboardKey.KEY_NULL);
        
        Initialize();
        
        var running = true;
        while (running)
        {
            Update();
            
            BeginDrawing();
            ClearBackground(_palette!["Background"]);
            
            Draw();
            
            EndDrawing();
            
            running = !IsKeyPressed(KeyboardKey.KEY_ESCAPE) && !WindowShouldClose();
        }
        
        CloseWindow();
    }
}