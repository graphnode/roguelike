using Roguelike.ECS.Components;
using static Raylib_cs.Raylib;

namespace Roguelike.ECS.Systems;

public class AISystem : System<Position, AIController>
{
    public override void Process(Entity e)
    {
        var aiController = e.Get<AIController>()!;

        if (!(aiController.LastMoveTime + (1f / aiController.Speed) < GetTime()))
            return;
        
        switch (aiController.Type)
        {
            case AIType.None:
                return;
            
            case AIType.Wandering:
                var dx = Random.Shared.Next(-1, 2);
                var dy = Random.Shared.Next(-1, 2);
                
                var position = e.Get<Position>()!;

                position.X += dx;
                position.Y += dy;

                aiController.LastMoveTime = GetTime();
                break;
        }
    }
}