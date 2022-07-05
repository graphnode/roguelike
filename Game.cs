using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;
using Raylib_cs;
using Roguelike.Utility;
using static Raylib_cs.Raylib;

namespace Roguelike;

internal class Game
{
    private static Vector2 TileSize => new(16, 16);

    private readonly Tileset _tileset;
    private readonly ColorPalette _palette;
    
    private const float PlayerWalkSpeed = 4f; // in tiles per second
    private double _playerLastMove;

    private readonly Entity player;
    private readonly List<Entity> entities = new();
    
    private Game()
    {
        _tileset = new Tileset(AssetManager.LoadTexture("16x16-RogueYun-AgmEdit.png"), TileSize);
        _palette = ColorPalette.LoadFromJson("AfterglowTheme.json");

        player = new Entity(15, 20, '@', _palette["Yellow"]);
        entities.Add(player);
        entities.Add(new Entity(20, 20, '@', _palette["White"]));
    }

    private void Update()
    {
        if (_playerLastMove + (1f/PlayerWalkSpeed) < GetTime())
        {
            var dx = 0;
            var dy = 0;
            
            if (IsKeyDown(KeyboardKey.KEY_LEFT) || IsKeyDown(KeyboardKey.KEY_A))
                dx = -1;
            if (IsKeyDown(KeyboardKey.KEY_RIGHT) || IsKeyDown(KeyboardKey.KEY_D))
                dx = 1;
            if (IsKeyDown(KeyboardKey.KEY_UP) || IsKeyDown(KeyboardKey.KEY_W))
                dy = -1;
            if (IsKeyDown(KeyboardKey.KEY_DOWN) || IsKeyDown(KeyboardKey.KEY_S))
                dy = 1;

            if (dx != 0 || dy != 0)
            {
                player.Move(dx, dy);
                _playerLastMove = GetTime();
            }
        }

        if (IsKeyPressed(KeyboardKey.KEY_ESCAPE))
            Environment.Exit(0);
    }

    private void Draw()
    {
        foreach (var entity in entities)
        {
            DrawTextureRec(_tileset.Texture,  _tileset.GetRect(entity.Symbol), new Vector2(entity.X, entity.Y) * TileSize, entity.Color);
        }
    }
    
    private static void Main()
    {
        var title = "Roguelike";
        var version = Assembly.GetEntryAssembly()?.GetName().Version;
        title = version == null ? title : $"{title} v{version.ToString(3)}";
        
        TraceLog(TraceLogLevel.LOG_INFO, "Starting Roguelike");

        InitWindow(800, 640, title);
        
        var iconImg = AssetManager.LoadImage("icon.png");
        
        SetWindowIcon(iconImg);
        
        SetTargetFPS(60);
        SetExitKey(KeyboardKey.KEY_NULL);
        
        var running = true;
        
        var game = new Game();
        
        while (running)
        {
            game.Update();
            
            BeginDrawing();
            ClearBackground(game._palette["Background"]);
            game.Draw();
            EndDrawing();
            
            running = !IsKeyPressed(KeyboardKey.KEY_ESCAPE) && !WindowShouldClose();
        }
        
        CloseWindow();
    }
}