using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Roguelike.Components;

public class PlayerControlled : IComponent
{
    private const float PlayerWalkSpeed = 4f; // in tiles per second
    private double _playerLastMove;
    
    public void Process(Entity entity)
    {
        if (!(_playerLastMove + (1f / PlayerWalkSpeed) < GetTime()))
            return;
        
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

        if (dx == 0 && dy == 0)
            return;
        
        entity.Move(dx, dy);
        _playerLastMove = GetTime();
    }
}