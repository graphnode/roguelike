namespace Roguelike.ECS.Components;

public class AIController : IComponent
{
    public float Speed { get; set; } = 2f; // in tiles per second
    public double LastMoveTime { get; set; }
    
    public AIType Type { get; set; } = AIType.None;
}

public enum AIType
{
    None,
    Wandering
}