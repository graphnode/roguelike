namespace Roguelike.ECS.Components;

public class PlayerController : IComponent
{
    public float Speed { get; set; } = 4f; // in tiles per second
    public double LastMoveTime { get; set; }
}
