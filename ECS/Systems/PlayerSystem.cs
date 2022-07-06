using Raylib_cs;
using Roguelike.ECS.Components;
using static Raylib_cs.Raylib;

namespace Roguelike.ECS.Systems;

public class PlayerSystem : ISystem
{
    public void Process(Entity e)
    {
        var position = e.Get<Position>();
        var playerController = e.Get<PlayerController>();
        
        if (position == null || playerController == null)
            return;
        
        if (!(playerController.LastMoveTime + (1f / playerController.Speed) < GetTime()))
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

        position.X += dx;
        position.Y += dy;

        playerController.LastMoveTime = GetTime();
    }
}