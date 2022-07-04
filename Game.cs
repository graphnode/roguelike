using System.Numerics;
using System.Reflection;
using Raylib_cs;
using Roguelike.Utility;
using static Raylib_cs.Raylib;

namespace Roguelike;

internal class Game
{
    private static Vector2 TileSize => new(16, 16);

    private readonly Tileset _tileset;
    private readonly ColorPalette _palette;

    private Vector2 _playerPosition;

    private const float PlayerWalkSpeed = 4f; // in tiles per second
    private double _playerLastMove;
    
    private Game()
    {
        _tileset = new Tileset(LoadTexture(Engine.GetAssetPath("16x16-RogueYun-AgmEdit.png")), TileSize);
        _palette = ColorPalette.LoadFromJson("AfterglowTheme.json");
    }

    private void Update()
    {
        if (_playerLastMove + (1f/PlayerWalkSpeed) < GetTime())
        {
            var playerMove = new Vector2();
            
            if (IsKeyDown(KeyboardKey.KEY_LEFT) || IsKeyDown(KeyboardKey.KEY_A))
                playerMove.X = -1;
            if (IsKeyDown(KeyboardKey.KEY_RIGHT) || IsKeyDown(KeyboardKey.KEY_D))
                playerMove.X = 1;
            if (IsKeyDown(KeyboardKey.KEY_UP) || IsKeyDown(KeyboardKey.KEY_W))
                playerMove.Y = -1;
            if (IsKeyDown(KeyboardKey.KEY_DOWN) || IsKeyDown(KeyboardKey.KEY_S))
                playerMove.Y = 1;

            if (playerMove.X != 0 || playerMove.Y != 0)
            {
                _playerPosition += new Vector2(playerMove.X * TileSize.X, playerMove.Y * TileSize.Y);
                _playerLastMove = GetTime();
            }
        }

        if (IsKeyPressed(KeyboardKey.KEY_ESCAPE))
            Environment.Exit(0);
    }

    private void Draw()
    {
        DrawTextureRec(_tileset.Texture,  _tileset.GetRect(0, 4), _playerPosition, _palette["Yellow"]);
    }
    
    private static void Main()
    {
        var title = "Roguelike";
        var version = Assembly.GetEntryAssembly()?.GetName().Version;
        title = version == null ? title : $"{title} v{version.ToString(3)}";

        InitWindow(800, 640, title);

        var iconImg = LoadImage(Engine.GetAssetPath("icon.png"));
        
        SetWindowIcon(iconImg);
        
        SetTargetFPS(60);
        
        var game = new Game();
        
        while (!WindowShouldClose())
        {
            game.Update();
            
            BeginDrawing();
            ClearBackground(game._palette["Background"]);
            game.Draw();
            EndDrawing();
        }
        
        CloseWindow();
    }
}