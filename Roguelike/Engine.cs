using System.Numerics;
using System.Reflection;
using Raylib_cs;
using Roguelike.ECS;
using Roguelike.ECS.Components;
using Roguelike.ECS.Systems;
using Roguelike.Utilities;
using static Raylib_cs.Raylib;

namespace Roguelike;

public class Engine
{ 
    private Tileset? _tileset;
    private ColorPalette? _palette;

    private World? _world;
    
    private void Initialize()
    {
        _tileset = new Tileset(AssetManager.LoadTexture("16x16-RogueYun-AgmEdit.png"), new Vector2(16, 16));
        _palette = ColorPalette.LoadFromJson("AfterglowTheme.json");

        _world = new World();

        _world.AddSystems(
            new PlayerSystem(),
            new AISystem(),
            new RenderingSystem(_tileset)
        );

        _world.CreateAndAddEntity(
            new Position { X = 20, Y = 20 },
            new Renderable { Glyph = '@', ForegroundColor = _palette["White"] },
            new AIController { Type = AIType.Wandering }
        );
        
        _world.CreateAndAddEntity(
            new Position { X = 15, Y = 20 },
            new Renderable { Glyph = '@', ForegroundColor = _palette["Yellow"] },
            new PlayerController()
        );
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
            BeginDrawing();
            ClearBackground(_palette!["Background"]);

            _world!.Run();
            
            EndDrawing();
            
            running = !IsKeyPressed(KeyboardKey.KEY_ESCAPE) && !WindowShouldClose();
        }
        
        CloseWindow();
    }
    
    private static string GenerateTitle()
    {
        const string baseTitle = "Roguelike";
        var version = Assembly.GetEntryAssembly()?.GetName().Version;
        return version == null ? baseTitle : $"{baseTitle} v{version.ToString(3)}";
    }
}